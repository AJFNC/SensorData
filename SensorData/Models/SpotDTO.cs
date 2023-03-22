namespace SensorData.Models
{
    public class SpotDTO
    {
        public string Name { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public float A { get; set; }
        public float B { get; set; }
        public float R2 { get; set; }
        public int Sensor_Id { get; set; }
    }
}
