using System;
namespace BikeDashboard.Models
{
	public class WeatherForecast
	{
		public Rain Rain {get;}
		public Temperature Temperature { get; }
		public Wind Wind { get; }
		public string Description { get; }
		public string WeatherGroup { get; }
		public DateTime ForecastTime { get; }

		public WeatherForecast(Rain rain, Temperature temperature, Wind wind, string description, string weatherGroup, DateTime forecastTime)
        {
			Rain = rain;
			Temperature = temperature;
			Wind = wind;
			Description = description;
			WeatherGroup = weatherGroup;
			ForecastTime = forecastTime;
		}
    }
}
