using System.Data;
using System.Linq;
using TBS.Entities;
using Dapper;

namespace TBS.Data.Queries.Bookings
{
    public class GetBooking : IQuery<Booking>
    {
        private readonly int _id;

        public GetBooking(int id)
        {
            _id = id;
        }

        public Booking Execute(IDbConnection session)
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
            where Id = @Id";

            Booking item = session.Query<Booking, Court, User, BookingType, Booking>(
                sql,
                (booking, court, user, type) =>
                {
                    booking.Court = court;
                    booking.User = user;
                    booking.Type = type;
                    return booking;
                },
                new { Id = _id }).SingleOrDefault();

            return item;
        }
    }
}
