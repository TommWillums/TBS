using System;
using System.Collections.Generic;
using System.Linq;
using TBS.Entities;

namespace TBS.Data.Queries.Bookings
{
    public class GetBooking : IQuery<Booking>
    {
        private readonly int _id;

        public GetBooking(int id)
        {
            _id = id;
        }

        public Booking Execute(ISession session)
        {
            const string sql = @"
            select 
                b.Id, b.CourtId, c.Name,
                b.BookingTypeId, t.Description,
                b.UserId, u.Name, b.DisplayAs,
                b.StartTime, b.Duration,
                b.Created, b.Deleted
            from Bookings b
                join Courts c on c.Id = b.CourtId
                join Users u on u.Id = b.UserId
                join BookingTypes t on t.Id = b.BookingTypeId
            where Id = @Id";

            Booking item = new Booking();
            session.Query<Court, User, BookingType, Booking>(sql,
                (court, user, bookingtype) =>
                {
                    item.Court = court;
                    item.User = user;
                    //item.BookingType = bookingtype;
                    return item;
                },
                new { Id = _id }).SingleOrDefault();

            return item;
        }
    }
}
