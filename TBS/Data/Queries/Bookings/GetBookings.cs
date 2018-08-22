using System;
using System.Collections.Generic;
using System.Linq;
using TBS.Entities;

namespace TBS.Data.Queries.Bookings
{
    public class GetBookings : IQuery<IList<Booking>>
    {
        private readonly DateTime _date;

        public GetBookings(DateTime fromdate, DateTime? todate = null)
        {
            _date = new DateTime(fromdate.Year, fromdate.Month, fromdate.Day);
            if (todate == null)
            {
                todate = _date.AddDays(1);
            }
            else
            {
                todate = new DateTime(todate.Year, toate.Month, todate.Day);
            }
        }

        public IList<Booking> Execute(ISession session)
        {
            return session.Query<Booking>("select * from Bookings where StartTime >= @FromDate and StartTime < @ToDate", new { FromDate = _date, ToDate = todate }).ToList();
        }
    }

}
