using AutoMapper;
using deployWebAPI.Dtos;
using deployWebAPI.Models;

namespace deployWebAPI.Profiles
{
    public class WeathersProfile : Profile
    {
        public WeathersProfile()
        {
            // Source -> Target
            CreateMap<Weather, WeatherReadDto>();
            CreateMap<WeatherCreateDto, Weather>();   
        }
    }
}