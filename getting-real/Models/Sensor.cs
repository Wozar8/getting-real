using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace getting_real
{
    public class Sensor
    {
        public Guid Id { get; }
        public string Type { get; set; }
        public string Keys { get; set; }
        public string SensorType { get; set; }
        public string ConnectionType { get; set; }

        public Sensor(string type, string keys, string sensorType, string connectionType)
        {
            Id = Guid.NewGuid();
            Type = type;
            Keys = keys;
            SensorType = sensorType;
            ConnectionType = connectionType;
        }
    }
}