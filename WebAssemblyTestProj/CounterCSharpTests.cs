using AngleSharp;
using WebAssemblyTest.Client.Pages;
using WebAssemblyTest.Client.Services;
using TestContext = Bunit.TestContext;

namespace WebAssemblyTestProj;

/// <summary>
/// These tests are written entirely in C#.
/// Learn more at https://bunit.dev/docs/getting-started/writing-tests.html#creating-basic-tests-in-cs-files
/// </summary>
public class CounterCSharpTests : BunitTestContext
{
	
	[Test]
	public void CreditsStartAtZero()
	{
		var ctx = new TestContext();

		ctx.Services.AddScoped<SwapiService>();

		// Arrange
		var comp = ctx.RenderComponent<Play>();

		// Assert that content of the paragraph shows counter at zero
		comp.Find("h3").MarkupMatches("<h3>Total Credits: 0</h3>");
	}

	//[Test]
	//public void ClickingButtonIncrementsCounter()
	//{
	//	// Arrange
	//	var cut = RenderComponent<Counter>();

	//	// Act - click button to increment counter
	//	cut.Find("button").Click();

	//	// Assert that the counter was incremented
	//	cut.Find("p").MarkupMatches("<p>Current count: 1</p>");
	//}
}
