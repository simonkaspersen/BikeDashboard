﻿using System;
using System.Linq;
using System.Threading.Tasks;
using BikeDashboard.Services;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using TestBikedashboard.DTO;
using Xunit;

namespace TestBikedashboard.HealthChecks
{
    public class TestWeatherServiceHealthCheckFailure : TestBase
    {

        protected override void ConfigureTestServices(IServiceCollection services)
        {
            base.ConfigureTestServices(services);
            services.AddSingleton<IWeatherService>(new WeatherService("InvalidUri"));
        }

        [Fact]
        public async Task CheckHealthAsync_GivenInvalidWeatherService_ReturnsDegraded()
        {
            var response = await Factory.CreateClient().GetAsync("/api/health");

            var content = await response.Content.ReadAsStringAsync();
            var healthCheckStatus = JsonConvert
            .DeserializeObject<HealthCheckDTO>(content)
                .Checks.FirstOrDefault(check => check.Service.Equals("testWeatherService")).Status;

            response.EnsureSuccessStatusCode();
            Assert.Equal("Degraded", healthCheckStatus);
        }
    }
}
