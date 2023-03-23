namespace SensorData.Models
{
    public class Frequency
    {
        public int Id { get; set; }
        public int Sensor_Id { get; set; }
        public float Frl1 { get; set;}
        public float Frl2 { get; set;}
        public float Frl3 { get; set;}
        public DateTime ReadDateTime { get; set;} = DateTime.Now.ToLocalTime();
    }
}
