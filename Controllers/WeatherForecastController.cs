using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using deployWebAPI.Data;
using deployWebAPI.Dtos;
using deployWebAPI.Models;

namespace deployWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherRepo repository;
        private readonly IMapper mapper;

        public WeatherController(IWeatherRepo repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetAllWeatherDetails")]
        public ActionResult<IEnumerable<WeatherReadDto>> GetAllWeatherDetails()
        {
            Console.WriteLine("--> Getting Weather Details....");

            IEnumerable<Weather> weatherItems = this.repository.GetAllWeatherDetails();

            return Ok(this.mapper.Map<IEnumerable<WeatherReadDto>>(weatherItems));
        }

        [HttpGet("{id}", Name = "GetWeatherDetailsById")]
        public ActionResult<WeatherReadDto> GetWeatherDetailsById(int id)
        {
            Console.WriteLine("--> getting Weather Details based on id....");
            Weather weatherItem = this.repository.GetWeatherDetailsById(id);

            if(weatherItem != null)
            {
                return Ok(this.mapper.Map<WeatherReadDto>(weatherItem));
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult<WeatherReadDto> CreateWeatherDetails(WeatherCreateDto weatherCreateDto)
        {
            Console.WriteLine("--> creating Weather Details....");
            Weather weather = this.mapper.Map<Weather>(weatherCreateDto);
            this.repository.CreateWeatherDetails(weather);
            this.repository.SaveChanges();
            
            WeatherReadDto weatherReadDto = this.mapper.Map<WeatherReadDto>(weather);

            // Send Sync Message
            return CreatedAtRoute(nameof(GetWeatherDetailsById), new { id = weatherReadDto.Id }, weatherReadDto);
            
        }

        [HttpPatch("{id}")]
        public ActionResult<WeatherReadDto> UpdateWeatherDetails(WeatherCreateDto weatherCreateDto, int id)
        {
            Console.WriteLine("--> Updating Weather Details based on id....");

            this.repository.UpdateWeatherDetails(weatherCreateDto,id);

            this.repository.SaveChanges();

            return CreatedAtRoute(nameof(GetWeatherDetailsById), new { id = id }, weatherCreateDto);
        }

        /*[HttpDelete("{id}")]
        public ActionResult<IEnumerable<WeatherReadDto>> DeleteWeatherDetails(int id)
        {
            Console.WriteLine("--> Deleting Weather Details based on id....");

            this.repository.DeleteWeatherDetails(id);
            this.repository.SaveChanges();

            IEnumerable<Weather> weatherItems = this.repository.GetAllWeatherDetails();

            return Ok(this.mapper.Map<IEnumerable<WeatherReadDto>>(weatherItems));
        }*/
    }
}