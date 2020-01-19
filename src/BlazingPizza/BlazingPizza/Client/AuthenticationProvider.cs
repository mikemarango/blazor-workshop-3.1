using BlazingPizza.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazingPizza.Client
{
    public class AuthenticationProvider : AuthenticationStateProvider
    {
        private readonly HttpClient httpClient;

        public AuthenticationProvider(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userInfo = await httpClient.GetJsonAsync<UserInfo>("user"); ;

            var identity = userInfo.IsAuthenticated
                ? new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userInfo.Name) }, "serverauth")
                : new ClaimsIdentity();

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }
    }
}
