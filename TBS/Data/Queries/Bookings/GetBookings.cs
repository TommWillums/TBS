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
            _fromdate = fromdate;
            _todate = _fromdate.AddDays(1);
        }

        public IList<Booking> Execute(IDbConnection conn)
        {
            const string sql = @"
            select Id, CourtId, CourtName, BookingTypeId, BookingType, UserId, UserName, DisplayAs, StartTime, Duration
            from Bookings_v
            where StartTime >= @FromDate and StartTime < @ToDate";

            return conn.Query<Booking>(sql, new { FromDate = _fromdate, ToDate = _todate }).ToList();
        }
    }

}
