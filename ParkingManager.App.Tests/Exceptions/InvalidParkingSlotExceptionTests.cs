using NUnit.Framework;
using ParkingManager.App.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManager.App.UnitTests.Exceptions
{
    [TestFixture]
    public class InvalidParkingSlotExceptionTests
    {
        [Test]
        public void InvalidParkingSlotException_Creates_Default_Instance()
        {
            InvalidParkingSlotException exception = new InvalidParkingSlotException();

            Assert.IsNotNull(exception);
        }

        [Test]
        public void InvalidParkingSlotException_WithMessage()
        {
            InvalidParkingSlotException exception = new InvalidParkingSlotException("Invalid slot");

            Assert.IsNotNull(exception);
            Assert.AreEqual("Invalid slot", exception.Message);
        }

        [Test]
        public void InvalidParkingSlotException_WithInnerException_CreatesInstanceWithInnerException()
        {
            Exception innerException = new Exception("Inner exception");

            InvalidParkingSlotException exception = new InvalidParkingSlotException("Invalid slot", innerException);

            // Assert
            Assert.IsNotNull(exception);
            Assert.AreEqual("Invalid slot", exception.Message);
            Assert.AreEqual(innerException, exception.InnerException);
        }

    }
}
