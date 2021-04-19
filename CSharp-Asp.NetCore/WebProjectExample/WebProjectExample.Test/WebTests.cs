using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace WebProjectExample.Test
{
    public class WebTests
    {
        [Fact]
        public async Task HomePageShouldContainWelcomeNikola()
        {
            // Simulate web server
            var webApplicationFactory = new WebApplicationFactory<Startup>();

            // Create httpClient to send requests
            HttpClient client = webApplicationFactory.CreateClient();

            // Get the httpResponse from route on our app (currently home page "/")
            var response = await client.GetAsync("/");

            
            // Get the html from the body in the response
            var html = await response.Content.ReadAsStringAsync();

            // Check if the html contains what we want to Compare
            Assert.Contains("<h2 class=\"display-4\">Welcome, Nikola</h2>", html);

            // This should be moved to another test with same logic -> check if the header contains "x-info-action-name"
            Assert.True(response.Headers.Contains("x-info-action-name"));

            // This should be moved to another test with same logic -> Ensure that the status code is 200
            response.EnsureSuccessStatusCode();

            // If we want to test post request
            //client.PostAsync("/Contacts/Index (write route)", new FormUrlEncodedContent("parameter"-> "value"));
        }
    }
}
