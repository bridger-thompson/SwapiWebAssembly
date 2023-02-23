using AngleSharp;
using WebAssemblyTest.Client.Pages;
using WebAssemblyTest.Client.Services;
using Bunit;
using NUnit.Framework;
using AngleSharp.Dom;
using RichardSzalay.MockHttp;
using System.Collections.Generic;
using WebAssemblyTest.Shared;

namespace WebAssemblyTestProj;

/// <summary>
/// These tests are written entirely in C#.
/// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
/// </summary>
public class CounterCSharpTests : BunitTestContext
{
	[Test]
	public void HomePageComponentRenders()
	{
		using var ctx = new Bunit.TestContext();

		var comp = ctx.RenderComponent<Home>();

		comp.MarkupMatches("<div class=\"container\">\r\n\t<h1>SWAPI</h1>\r\n\t" +
            "<div>Hello! Welcome to the great universe of <b>STAR WARS!</b> " +
            "Step into a world of starships, blasters, and lots of money. The best part? " +
            "It's as easy as 1 click to get! Login and have a look around to see all the great things you can do!</div>\r\n</div>");
	}
	
	[Test]
	public void CreditsStartAtZero()
	{
		using var ctx = new Bunit.TestContext();
        var mock = ctx.Services.AddMockHttpClient();
        ctx.Services.AddScoped<SwapiService>();
        mock.When("*api/Swapi/user/1").RespondJson("{ \"id\":\"EthanW\",\"person\":null,\"credits\":0,\"starships\":[],\"vehicles\":[],\"clickRate\":1,\"autoclickRate\":0}");

		var authContex = ctx.AddTestAuthorization();
		authContex.SetAuthorizing();

		var comp = ctx.RenderComponent<Play>();
		var smallElmnt = comp.WaitForElement(@"h3").TextContent;

		smallElmnt.MarkupMatches(@"<h3>Total Credits: </h3>");
	}
}
