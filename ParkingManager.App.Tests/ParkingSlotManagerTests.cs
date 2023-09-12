using NUnit.Framework;
using ParkingManager.App.Enums;
using ParkingManager.App.Exceptions;
using ParkingManager.App.Interfaces;

namespace ParkingManager.App.Tests
{
    [TestFixture]
    public class ParkingSlotManagerTests
    {
        private IParkingSlotManager slotManager;

        [SetUp]
        public void Setup()
        {
            slotManager = new ParkingSlotManager();

        }

        [Test]
        public void AllVehicleTypes_Should_Get_Allocated_With_ParkingSlot()
        {

            // Allocate parking slots for different vehicle types
            int slot1 = slotManager.AssignSlot(new Models.Vehicle() { VehicleNumber = "ABC1", Type = VehicleType.Hatchback });
            int slot2 = slotManager.AssignSlot(new Models.Vehicle() { VehicleNumber = "ABC2", Type = VehicleType.SedanCompactSUV });
            int slot3 = slotManager.AssignSlot(new Models.Vehicle() { VehicleNumber = "ABC3", Type = VehicleType.SUVLarge });

            Assert.That(slot1, Is.Not.EqualTo(-1));
            Assert.AreNotEqual(-1, slot2);
            Assert.AreNotEqual(-1, slot3);
        }

        [Test]
        public void InvalidSlotNumberInFreeParkingSlot_Throws_Exception()
        {
            var invalidParkingSlot = 101;
            Assert.Throws<InvalidParkingSlotException>(() => slotManager.FreeParkingSlot(invalidParkingSlot));
        }

        [Test]
        public void Deallocate_Slot_Is_Success()
        {
            int slot1 = slotManager.AssignSlot(new Models.Vehicle() { VehicleNumber = "ABC123", Type = VehicleType.Hatchback });
            slotManager.FreeParkingSlot(slot1);

            int slot2 = slotManager.AssignSlot(new Models.Vehicle() { VehicleNumber = "ABC456", Type = VehicleType.Hatchback });
            Assert.AreEqual(slot1, slot2);
        }

        [Test]
        public void WhenSmallSlotsGetsFilled_MediumSlots_Can_Be_Assigned_To_Small_Cars()
        {
            for (int i = 1; i <= 50; i++)
            {
                slotManager.AssignSlot(new Models.Vehicle() { VehicleNumber = "ABC" + i, Type = VehicleType.Hatchback });
            }

            int mediumSlot = slotManager.AssignSlot(new Models.Vehicle() { VehicleNumber = "ABC123", Type = VehicleType.Hatchback });

            Assert.AreNotEqual(-1, mediumSlot);
        }

    }
}