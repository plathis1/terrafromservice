using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deployWebAPI.Models;

namespace deployWebAPI.Data
{
    public interface IWeatherRepo
    {
        bool SaveChanges();

        IEnumerable<Weather> GetAllWeatherDetails();
        Weather GetWeatherDetailsById(int id);
        void CreateWeatherDetails(Weather plat);
    }
}