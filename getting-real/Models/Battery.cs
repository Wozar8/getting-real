using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace getting_real
{
    class Battery
    {
        public DateTime RegistrationDate { get; set; }
        public string BatteryType { get; set; }
        public double MaxCapacity { get; set; }
        public string MountingType { get; set; }
    }
}
