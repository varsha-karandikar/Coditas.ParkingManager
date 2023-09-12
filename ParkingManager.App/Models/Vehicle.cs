using ParkingManager.App.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.App.Models
{
    public class Vehicle
    {
        public string VehicleNumber { get; set; }
        public VehicleType Type { get; set; }
    }
}
