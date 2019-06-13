using System.Threading.Tasks;
using BikeDashboard.DTO;
using BikeDashboard.Models;
using BikeDashboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeDashboard.Controllers
{
	[Route("api/[controller]")]
	public class FavoriteStationController : Controller
	{
		private readonly IStationService _stationService;
		private readonly IWeatherService _weatherService;

		public FavoriteStationController(IStationService stationService, IWeatherService weatherService)
		{
			_stationService = stationService;
			_weatherService = weatherService;
		}

		[HttpGet]
		public async Task<StationWeatherDTO> GetAsync([FromQuery(Name = "stationName")] string stationName)
		{
			FavoriteStation station;
			WeatherForecastReport weatherForecast;
			var showingClosestStationWithBikes = false;
			var originalStationName = "";
			
			if (string.IsNullOrEmpty(stationName))
			{
				station = await _stationService.GetFavoriteStation();
			}
			else
			{
				station = await _stationService.GetFavoriteStation(stationName);
			}

			if ( station.AvailableBikes == 0 )
			{
				originalStationName = station.Name;
				showingClosestStationWithBikes = true;
				station = await _stationService.GetClosestAvailableStation(station);
			}
			
			if (_weatherService.FeatureEnabled)
			{
                weatherForecast = await _weatherService.GetDailyForeCastAsync(station.StationCoordinates);
	        }
			else
			{
				weatherForecast = new WeatherForecastReport(new WeatherForecast[] { });
			}
			return new StationWeatherDTO
			{
				Station = station,
				OriginalStationName = originalStationName,
				ShowingClosestStationWithBikes = showingClosestStationWithBikes,
				ForecastReport = weatherForecast
			};
		}
	}
}
