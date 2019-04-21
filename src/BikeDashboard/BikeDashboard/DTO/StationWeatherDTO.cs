using System;
using BikeDashboard.Models;
using Newtonsoft.Json;

namespace BikeDashboard.DTO
{
    //TODO refactor, used to serialize favoriteStation and weather for FavoriteStationController
	public class StationWeatherDTO
	{
		public FavoriteStation Station { get; set; }

        [JsonProperty("forecastReport")]
		public WeatherForecastReport ForecastReport { get; set; }
	}
}