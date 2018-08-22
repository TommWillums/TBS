using System;
using System.Collections.Generic;
using System.Linq;
using TBS.Entities;

namespace TBS.Data.Queries.Bookings
{
    public class GetBookings : IQuery<IList<Booking>>
    {
        private readonly DateTime _date;

        public GetBookings(DateTime date)
        {
            _date = date;
        }

        public IList<Booking> Execute(ISession session)
        {
            return session.Query<Booking>("select * from Bookings where StartTime >= @Date and StartTime < @Date + 1", new { Date = _date }).ToList();
        }
    }

}
