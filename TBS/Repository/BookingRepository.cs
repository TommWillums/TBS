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
        IEnumerable<Booking> GetBookings(DateTime date);
        void Save(BookingDTO item);
    }

    public class BookingRepository : RepositoryBase, IBookingRepository
    {
        public Booking GetBooking(int id)
        {
            return QueryCmdHandler.Query(new GetBooking(id));
        }

        public IEnumerable<Booking> GetBookings(DateTime date)
        {
            date = new DateTime(date.Year, date.Month, date.Day);
            return QueryCmdHandler.Query(new GetBookings(date)).ToList();
        }

        public void Delete(int id)
        {
            QueryCmdHandler.Execute(new DeleteBooking(id));
        }

        public void Save(Booking bk)
        {
            var item = new BookingDTO() { Id = bk.Id, CourtId = bk.CourtId, BookingTypeId = bk.BookingTypeId, UserId = bk.UserId, StartTime = bk.StartTime, Duration = bk.Duration };
            Save(item);
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
