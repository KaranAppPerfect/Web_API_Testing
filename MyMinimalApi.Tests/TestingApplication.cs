using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MyMinimalApi.Tests
{
    class TestingApplication : WebApplicationFactory<Person>
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                services.AddScoped<IPeopleService, TestPeopleService>();
            });

            return base.CreateHost(builder);
        }
    }
}
