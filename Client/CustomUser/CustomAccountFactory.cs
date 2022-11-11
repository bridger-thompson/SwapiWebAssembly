using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using WebAssemblyTest.Shared;

namespace WebAssemblyTest.Client.CustomUser
{
    public class CustomAccountFactory : AccountClaimsPrincipalFactory<CustomUserAccount>
    {
        private readonly HttpClient client;

        public CustomAccountFactory(NavigationManager navigationManager, IAccessTokenProviderAccessor accessor) : base(accessor)
        {
            client = new HttpClient { BaseAddress = new Uri(navigationManager.BaseUri) };
        }

        public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
            CustomUserAccount account, RemoteAuthenticationUserOptions options)
        {
            var initialUser = await base.CreateUserAsync(account, options);

            if (initialUser.Identity.IsAuthenticated)
            {
                //foreach (var value in account.AuthenticationMethod)
                //{
                //    ((ClaimsIdentity)initialUser.Identity)
                //        .AddClaim(new Claim("amr", value));
                //}

                var tokenResponse = await TokenProvider.RequestAccessToken();
                if (tokenResponse.TryGetToken(out var token))
                {
                    var id = initialUser.Identity.Name;
                    var request = new HttpRequestMessage(HttpMethod.Post, $"api/Swapi/addUser/{id}");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
                    await client.SendAsync(request);
                }
            }
            return initialUser;
        }
    }
}
