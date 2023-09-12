using ParkingManager.App.Constants;
using ParkingManager.App.Enums;
using ParkingManager.App.Exceptions;
using ParkingManager.App.Interfaces;
using ParkingManager.App.Models;

namespace ParkingManager.App
{
    public class ParkingSlotManager : IParkingSlotManager
    {
        private List<ParkingSlot> slots;

        public ParkingSlotManager()
        {
            InitializParkingSlots();
        }

        private void InitializParkingSlots()
        {
            // Initialize parking slots
            slots = new List<ParkingSlot>();

            for (int i = 1; i <= 100; i++)
            {
                SlotSize size;
                if (i <= ParkingSlotCounts.SMALL_PARKING_SLOTS)
                {
                    size = SlotSize.Small;
                }
                else if (i <= 80)
                {
                    size = SlotSize.Medium;
                }
                else
                {
                    size = SlotSize.Large;
                }

                slots.Add(new ParkingSlot { Number = i, Size = size });
            }
        }

        public int AssignSlot(Vehicle vehicle)
        {
            SlotSize requiredSlotSize = GetSlotSizeAsPerVehicle(vehicle.Type);
            ParkingSlot allocatedSlot = FindAvailableSlot(requiredSlotSize);

            if (allocatedSlot != null)
            {
                allocatedSlot.ParkedVehicle = vehicle;
                Console.WriteLine($"Assigned slot  number {allocatedSlot.Number} for {vehicle.Type} vehicle with number: {vehicle.VehicleNumber}.");
                return allocatedSlot.Number;
            }

            Console.WriteLine($"No slot available for {requiredSlotSize} slot. Assigning a larger slot.");

            for (SlotSize largerSlot = requiredSlotSize + 1; largerSlot <= SlotSize.Large; largerSlot++)
            {
                allocatedSlot = FindAvailableSlot(largerSlot);
                if (allocatedSlot != null)
                {
                    allocatedSlot.ParkedVehicle = vehicle;
                    Console.WriteLine($"Assigned slot  number {allocatedSlot.Number} for {vehicle.Type} vehicle with number: {vehicle.VehicleNumber}.");
                    return allocatedSlot.Number;
                }
            }

            Console.WriteLine($"No slots available for {vehicle.Type} vehicle.");
            return -1;
        }

        public void FreeParkingSlot(int slotNumber)
        {
            ParkingSlot deallocatedSlot = slots.Find(slot => slot.Number == slotNumber);

            if (deallocatedSlot != null && deallocatedSlot.ParkedVehicle != null)
            {
                Console.WriteLine($"Freed slot {deallocatedSlot.Number}.");
                deallocatedSlot.ParkedVehicle = null;
            }
            else
            {
                Console.WriteLine($"Invalid slot number {slotNumber}.");
                throw new InvalidParkingSlotException("Invalid Slot Number");
            }
        }

        private SlotSize GetSlotSizeAsPerVehicle(VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleType.Hatchback:
                    return SlotSize.Small;
                case VehicleType.SedanCompactSUV:
                    return SlotSize.Medium;
                case VehicleType.SUVLarge:
                    return SlotSize.Large;
                default:
                    throw new ArgumentException("Invalid vehicle type.");
            }
        }

        private ParkingSlot FindAvailableSlot(SlotSize size)
        {
            return slots.Find(slot => slot.Size == size && slot.ParkedVehicle == null);
        }
    }
}
