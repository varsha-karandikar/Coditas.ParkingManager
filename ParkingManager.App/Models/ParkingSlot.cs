using ParkingManager.App.Enums;

namespace ParkingManager.App.Models
{
    public class ParkingSlot
    {
        public int Number { get; set; }
        public SlotSize Size { get; set; }
        public Vehicle ParkedVehicle { get; set; }

    }
}
