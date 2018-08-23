using System;
using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Bookings;
using TBS.Data.Queries.Bookings;
using TBS.Entities;

namespace TBS.Repository
{
    public interface IBookingRepository
    {
        Booking GetBooking(int id);
        IEnumerable<Booking> GetBookings(int clubId);
        void Save(Booking user);
    }

    public class BookingRepository : RepositoryBase //, IBookingRepository
    {
        public BookingRepository(UnitOfWork unitOfWork = null) : base(unitOfWork) { }

        public Booking GetBooking(int id)
        {
            return QueryCmdHandler.Query(new GetBooking(id));
        }

        public IEnumerable<Booking> GetBookings(DateTime date)
        {
            return QueryCmdHandler.Query(new GetBookings(date)).ToList();
        }

        public void Save(BookingDTO dto)
        {
            if (dto.StartTime.Minute < 30)
            {
                dto.StartTime = new DateTime(dto.StartTime.Year, dto.StartTime.Month, dto.StartTime.Day, dto.StartTime.Hour, 0, 0);
            }
            else
            {
                dto.StartTime = new DateTime(dto.StartTime.Year, dto.StartTime.Month, dto.StartTime.Day, dto.StartTime.Hour, 30, 0);
            }

            QueryCmdHandler.Execute(new SaveBooking(dto));
        }

    }
}
