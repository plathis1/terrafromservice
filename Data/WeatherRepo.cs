using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using deployWebAPI.Models;

namespace deployWebAPI.Data
{
    public class WeatherRepo : IWeatherRepo
    {
        private readonly AppDbContext _context;
        public WeatherRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateWeatherDetails(Weather plat)
        {
            if(plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }

            _context.WeatherData.Add(plat);
        }

        public IEnumerable<Weather> GetAllWeatherDetails()
        {
            return _context.WeatherData.ToList();
        }

        public Weather GetWeatherDetailsById(int id)
        {
            return _context.WeatherData.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}