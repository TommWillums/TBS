using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TBS.Entities;
using TBS.Repository;

namespace TBS.Test
{
    [TestClass]
    public class BookingRepositoryTests
    {
        BookingRepository _repository;

        [TestInitialize]
        public void Init()
        {
            _repository = new BookingRepository();
        }

        [TestCleanup]
        public void Cleanup()
        {
            //_unitOfWork.Dispose();
        }

        [TestMethod]
        public void booking_test_crud_on_database()
        {
            TBS_Test_Helper.TestPrepareDBToAddBooking();
            var repo = new CourtRepository();
            var court = repo.GetCourts(2).First();

            // Create with Minutes between 0 and 30 
            DateTime starttime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 12, DateTime.Now.Second);
            var item = new BookingDTO() { CourtId = court.Id, BookingTypeId = 1, UserId = 10000, StartTime = starttime, Duration = 60 };
            _repository.Save(item);

            // Read
            Booking booking = _repository.GetBookings(DateTime.Today).First();
            Assert.AreEqual(booking.CourtName, "Testbane");
            Assert.AreEqual(booking.BookingType, "Fast");
            Assert.AreEqual(booking.StartTime.Second, 0);

            // Update
            booking.BookingTypeId = 2;
            _repository.Save(booking);
            Booking booking2 = _repository.GetBooking(booking.Id);
            Assert.AreEqual(booking2.BookingType, "Medlem");

            // Delete
            _repository.Delete(booking.Id);
            Booking noBooking = _repository.GetBooking(booking.Id);
            Assert.AreEqual(noBooking, null);
        }

    }
}