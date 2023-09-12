using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.App.Exceptions
{
    public class InvalidParkingSlotException : Exception
    {
        public InvalidParkingSlotException() { }
        public InvalidParkingSlotException(string message) : base(message) { }
        public InvalidParkingSlotException(string message, Exception innerException) : base(message, innerException) { }
    }

}
