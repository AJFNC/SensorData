using System.ComponentModel.DataAnnotations;

namespace SensorData.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public int Ar1 { get; set; }
        public int Ar2 { get; set; } 
        public int Ar3 { get; set; }
        public int H2o1 { get; set; }
        public int H2o2 { get; set; }
        public int H2o3 { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CalDateTime { get; set; }
    }
}
