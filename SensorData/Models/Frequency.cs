using System.ComponentModel;

namespace SensorData.Models
{
    public class Frequency
    {
        public int Id { get; set; }

        [DisplayName("Sensor")]
        public int Sensor_Id { get; set; }

        [DisplayName("SS: 0 - 20")]
        public float Frl1 { get; set;}

        [DisplayName("SS: 20 - 40")]
        public float Frl2 { get; set;}
        [DisplayName("SS: 40 - 60")]
        public float Frl3 { get; set;}

        [DisplayName("Hora")]
        public DateTime ReadDateTime { get; set;} = DateTime.Now.ToLocalTime();

    }
}
