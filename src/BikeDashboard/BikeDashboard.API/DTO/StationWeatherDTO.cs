using System;
using BikeDashboard.Models;
using Newtonsoft.Json;

namespace BikeDashboard.DTO
{
	public class StationWeatherDTO
	{
		public bool ShowingClosestStationWithBikes { get; set; }
		public string OriginalStationName { get; set; }
		
		public FavoriteStation Station { get; set; }

        [JsonProperty("forecastReport")]
		public WeatherForecastReport ForecastReport { get; set; }
	}
}