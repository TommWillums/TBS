using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TBS.Data;
using TBS.Entities;
using TBS.Repository;

namespace TBS.Test
{
    [TestClass]
    public class BookingRepositoryTests
    {
        UnitOfWork _unitOfWork;
        BookingRepository _repository;

        [TestInitialize]
        public void Init()
        {
            //_unitOfWork = new UnitOfWork(Util.AppSettings.TestDatabaseConnection);
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
            var court = new CourtRepository().GetCourts(2).First();

            // Create with Minutes between 0 and 30 
            DateTime starttime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, 12, DateTime.Now.Second);
            var item = new BookingDTO() { CourtId = court.Id, BookingTypeId = 1, UserId = 10000, StartTime = DateTime.Now, Duration = 60 };
            _repository.Save(item);

            // Read
            Booking booking = _repository.GetBookings(DateTime.Today).First();
            Assert.AreEqual(booking.CourtName, "Testbane");
            Assert.AreEqual(booking.BookingType, "Fast");
            Assert.AreEqual(booking.StartTime.Second, 0);
/*
            // Update
            booking2.Name = "TBSX booking";
            _repository.Save(booking2);
            Booking booking3 = _repository.GetBooking(booking2.Id);
            Assert.AreEqual(booking2.Name, booking3.Name);

            // Delete
            booking3.Deleted = true;
            _repository.Save(booking3);
            Booking noBooking = _repository.GetBooking(booking3.Id);
            Assert.AreEqual(noBooking, null);
*/
        }

    }
}