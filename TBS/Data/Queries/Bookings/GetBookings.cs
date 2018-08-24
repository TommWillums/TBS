using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TBS.Entities;

namespace TBS.Data.Queries.Bookings
{
    public class GetBookings : IQuery<IList<Booking>>
    {
        private readonly DateTime _fromdate;
        private readonly DateTime _todate;

        public GetBookings(DateTime fromdate)
        {
            _fromdate = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day);
            _todate = _fromdate.AddDays(1);
        }

        public IList<Booking> Execute(IDbConnection session)
        {
            const string sql = @"
            select 
                b.Id, 
                b.CourtId, 
                b.BookingTypeId, 
                b.UserId, 
                b.DisplayAs,
                b.StartTime, 
                b.Duration,
                b.Created, 
                c.Name,
                u.Name, 
                t.Description
            from Bookings b
                join Courts c on c.Id = b.CourtId
                join Users u on u.Id = b.UserId
                join BookingTypes t on t.Id = b.BookingTypeId
            where StartTime >= @FromDate and StartTime < @ToDate";

            return session.Query<Booking, Court, User, BookingType, Booking>(
                sql,
                (booking, court, user, type) =>
                {
                    booking.Court = court;
                    booking.User = user;
                    booking.Type = type;
                    return booking;
                },
                new { FromDate = _fromdate, ToDate = _todate }).ToList();
        }
    }

}
