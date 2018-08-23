using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<Booking> Execute(ISession session)
        {
            return session.Query<Booking>("select * from Bookings where StartTime >= @FromDate and StartTime < @ToDate", new { FromDate = _fromdate, ToDate = _todate }).ToList();
        }
    }

}
