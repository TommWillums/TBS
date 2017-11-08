using System;

namespace TBS.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public BookingType Type { get; set; }   // T,S,M,X -- Fast-time/trening(blå), Standard,Medlem/Ikke-medlem(grønn), Mesterskap(gul), Annet/utleie/sperret(rød) 
        public User User { get; set; }
        public Court Court { get; set; }        // Or only the Court Id?
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }       // Minutes
        public string DisplayName { get; set; }
        public DateTime Created { get; set; }

        //public Booking(BookingType, UserId, CourtId, StartTime, DisplayName) { }
        
    }

}
