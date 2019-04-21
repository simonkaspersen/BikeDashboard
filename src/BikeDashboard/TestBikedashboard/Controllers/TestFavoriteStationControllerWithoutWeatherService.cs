using BikeDashboard.Services;
using Microsoft.Extensions.DependencyInjection;

namespace TestBikedashboard.Controllers
{
    public class TestFavoriteStationControllerWithoutWeatherService : TestBase
    {
        public TestFavoriteStationControllerWithoutWeatherService(IServiceCollection services)
        {
            base.ConfigureTestServices(services);
            services.AddSingleton<IWeatherService>(new WeatherService("InvalidUri"));
        }


    }
}
