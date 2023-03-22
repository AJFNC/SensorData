namespace SensorData.Models
{
    public class Spot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Lat { get; set; }
        public string? Long { get; set; }
        public float A { get; set; }
        public float B { get; set; }
        public float R2 { get; set; }
        public int Sensor_Id { get; set; }
    }
}
