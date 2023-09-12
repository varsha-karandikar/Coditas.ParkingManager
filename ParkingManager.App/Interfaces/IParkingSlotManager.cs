using ParkingManager.App.Models;

namespace ParkingManager.App.Interfaces
{
    public interface IParkingSlotManager
    {
        int AssignSlot(Vehicle vehicle);

        void FreeParkingSlot(int slotNumber);
    }
}
