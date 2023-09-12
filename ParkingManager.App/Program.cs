using ParkingManager.App.Enums;
using ParkingManager.App.Interfaces;
using ParkingManager.App.Models;

namespace ParkingManager.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IParkingSlotManager parkingSlotManager = new ParkingSlotManager();

            // Allocate parking slots for different vehicle types
            Vehicle hatchback = new Vehicle { VehicleNumber = "ABC123", Type = VehicleType.Hatchback };
            Vehicle sedan = new Vehicle { VehicleNumber = "ABC456", Type = VehicleType.SedanCompactSUV };
            Vehicle suv = new Vehicle { VehicleNumber = "ABC789", Type = VehicleType.SUVLarge };

            // Assign parking slots
            int slot1 = parkingSlotManager.AssignSlot(hatchback);
            int slot2 = parkingSlotManager.AssignSlot(sedan);
            int slot3 = parkingSlotManager.AssignSlot(suv);

            // Deallocate parking slots
            parkingSlotManager.FreeParkingSlot(slot1);
            parkingSlotManager.FreeParkingSlot(slot2);
            parkingSlotManager.FreeParkingSlot(slot3);
        }
    }
}