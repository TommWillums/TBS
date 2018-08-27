using System.Data;
using System.Linq;
using Dapper;
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

        public Booking Execute(IDbConnection conn)
        {
            const string sql = @"
            select Id, CourtId, CourtName, BookingTypeId, BookingType, UserId, UserName, DisplayAs, StartTime, Duration
            from Bookings_v
            where Id = @Id";

            return conn.QuerySingleOrDefault<Booking>(sql, new { Id = _id });
        }
    }
}
