namespace deployWebAPI.Dtos
{
    public class WeatherReadDto
    {
        public int Id { get; set; }

        public string? City { get; set; }

        public double? Temperature { get; set; }

        public double? Humidity { get; set; }

        public DateTime DateTime { get; set; }
    }
}