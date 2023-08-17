using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deployWebAPI.Dtos;
using deployWebAPI.Models;

namespace deployWebAPI.Data
{
    public interface IWeatherRepo
    {
        bool SaveChanges();

        IEnumerable<Weather> GetAllWeatherDetails();
        Weather GetWeatherDetailsById(int id);
        void CreateWeatherDetails(Weather weather);

        void UpdateWeatherDetails(WeatherCreateDto weatherParam, int id);

        void DeleteWeatherDetails(int id);
    }
}