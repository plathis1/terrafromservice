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
        private readonly AppDbContext dbContext;
        public WeatherRepo(AppDbContext context)
        {
            this.dbContext = context;
        }
        public void CreateWeatherDetails(Weather weather)
        {
            if(weather == null)
            {
                throw new ArgumentNullException(nameof(weather));
            }

            this.dbContext.WeatherData.Add(weather);
        }

        public IEnumerable<Weather> GetAllWeatherDetails()
        {
            return this.dbContext.WeatherData.ToList();
        }

        public Weather GetWeatherDetailsById(int id)
        {
            return this.dbContext.WeatherData.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateWeatherDetails(WeatherCreateDto weatherParam, int id)
        {
            Weather weather = this.dbContext.WeatherData.FirstOrDefault(p => p.Id == id);
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
            Weather weather = this.dbContext.WeatherData.FirstOrDefault(p => p.Id == id);
            if(weather != null)
            {
                this.dbContext.WeatherData.Remove(weather);
            }
        }

        public bool SaveChanges()
        {
            return (this.dbContext.SaveChanges() >= 0);
        }
    }
}