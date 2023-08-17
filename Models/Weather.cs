using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace deployWebAPI.Models;

public class Weather
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string? City { get; set; }

    [Required]
    public double? Temperature { get; set; }

    [Required]
    public double? Humidity { get; set; }

    [Required]
    public DateTime DateTime { get; set; }
}
