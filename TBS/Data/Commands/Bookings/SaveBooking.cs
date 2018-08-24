﻿using System.Data;
using Dapper;
using TBS.Entities;

namespace TBS.Data.Commands.Bookings
{
    public class SaveBooking : ICommand
    {
        private readonly BookingDTO _booking;

        public SaveBooking(BookingDTO booking)
        {
            _booking = booking;
        }

        public void Execute(IDbConnection session)
        {
            if (_booking.Id > 0)
            {
                session.Execute("update Bookings_Tbl set CourtId = @CourtId, BookingType = @BookingTypeId, UserId = @UserId, " +
                                "StartTime = @StartTime, Duration = @Duration, DisplayAs = @DisplayAs, Deleted = @Deleted where Id = @Id", 
                    new { _booking.Id,
                          _booking.CourtId,
                          _booking.BookingTypeId,
                          _booking.UserId, 
                          _booking.StartTime,
                          _booking.Duration,
                          _booking.DisplayAs,
                          _booking.Deleted });
                return;
            }

            session.Execute("insert into Bookings_Tbl (CourtId, BookingTypeId, UserId, StartTime, Duration, DisplayAs) " +
                            "values (@CourtId, @BookingTypeId, @UserId, @StartTime, @Duration, @DisplayAs)",
                new
                {
                    _booking.CourtId,
                    _booking.BookingTypeId,
                    _booking.UserId,
                    _booking.StartTime,
                    _booking.Duration,
                    _booking.DisplayAs
                });
        }
    }

}
