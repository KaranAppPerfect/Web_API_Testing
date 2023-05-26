using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MyMinimalApi.Tests
{
    public class PeopleTests
    {
        [Fact]
        public async Task CreatePerson()
        {
            await using var application = new TestingApplication();

            var client = application.CreateClient();

            var result = await client.PostAsJsonAsync("/people", new Person
            {
                FirstName = "Maarten",
                LastName = "Balliauw",
                Email = "maarten@jetbrains.com"
            });

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal("\"It works!\"", await result.Content.ReadAsStringAsync());

        }

        [Fact]
        public async Task CreatePersonValidatesObject()
        {
            await using var application = new WebApplicationFactory<Program>();

            var client = application.CreateClient();

            var result = await client.PostAsJsonAsync("/people", new Person());

            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);

            var validationResult = await result.Content.ReadFromJsonAsync<HttpValidationProblemDetails>();
            Assert.NotNull(validationResult);
            Assert.Equal("The FirstName field is required.", validationResult!.Errors["FirstName"][0]);
            Assert.Equal("The LastName field is required.", validationResult!.Errors["LastName"][0]);
            Assert.Equal("The Email field is required.", validationResult!.Errors["Email"][0]);
        }
    }
}
