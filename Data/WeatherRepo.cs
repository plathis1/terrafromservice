using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deployWebAPI.Dtos;
using deployWebAPI.Models;

namespace deployWebAPI.Data
{
    public class WeatherRepo : IWeatherRepo
    {
        private readonly AppDbContext context;
        public WeatherRepo(AppDbContext context)
        {
            this.context = context;
        }
        public void CreateWeatherDetails(Weather weather)
        {
            if(weather == null)
            {
                throw new ArgumentNullException(nameof(weather));
            }

            this.context.WeatherData.Add(weather);
        }

        public IEnumerable<Weather> GetAllWeatherDetails()
        {
            return this.context.WeatherData.ToList();
        }

        public Weather GetWeatherDetailsById(int id)
        {
            return this.context.WeatherData.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateWeatherDetails(WeatherCreateDto weatherParam, int id)
        {
            Weather weather = this.context.WeatherData.FirstOrDefault(p => p.Id == id);
            if(weather != null)
            {
                weather.City = weatherParam.City;
                weather.Temperature = weatherParam.Temperature;
                weather.Humidity = weatherParam.Humidity;
                weather.DateTime = weatherParam.DateTime;
            }
        }

        public void DeleteWeatherDetails(int id)
        {
            Weather weather = this.context.WeatherData.FirstOrDefault(p => p.Id == id);
            if(weather != null)
            {
                this.context.WeatherData.Remove(weather);
            }
        }

        public bool SaveChanges()
        {
            return (this.context.SaveChanges() >= 0);
        }
    }
}