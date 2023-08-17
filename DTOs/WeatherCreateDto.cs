using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace deployWebAPI.Dtos;

public class WeatherCreateDto
{
    [Required]
    public string? City { get; set; }

    [Required]
    public double? Temperature { get; set; }

    [Required]
    public double? Humidity { get; set; }

    [Required]
    public DateTime DateTime { get; set; }
}
