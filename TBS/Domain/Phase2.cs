using System;

namespace TBS.Domain
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public int Courts { get; set; }
        public string SubscriptionType { get; set; }
        public bool AutomaticRenewal { get; set; }
        public DateTime NextRenewalDate { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
    }

    public class ClubPayment
    {
        public int Id { get; set; }
        public Club Club { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
    }

    public class OpeningHours
    {
        // TODO:
    }

    // Søk på: Navn, Kursgruppe, Ansvarlig
    public class Course
    {
        public string CourseName { get; set; }
        public int ParticipantCount { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Grouping { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Discount_Week { get; set; }
        public int MaxParticipants { get; set; }
        public string CancellationTerms { get; set; } // ikke tillatt, senest 1-14 dager før
        public string Responsible { get; set; }
        public string VisibleTo { get; set; }
        public bool Active { get; set; }
        public DateTime Created { get; set; }
    }

    // Consider Court prices as well:
    // Bane 1, Fredag, Årskort, Tid1, Beløp
    // Bane 2, Lørdag, Non-member, Tid2, Beløp
    public class Price
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public UserType UserType { get; set; }
        public DateTime Created { get; set; }
    }

    public class UserPayment
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
        public DateTime Created { get; set; }
    }


}
