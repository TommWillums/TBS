using System;

namespace TBS.Domain
{
    public enum Weekday { Mon, Tue, Wed, Thu, Fri, Sat, Sun }
    public enum Sex { Male, Female }

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

    public class Court
    {
        public int Id { get; set; }
        public string Name { get; set; }        // Bane 2 Ute
        public int ClubId { get; set; }         // 100-PTK
        public int CourtGroup { get; set; }     // Ute, Inne
        public bool Active { get; set; }
        public string CourtType { get; set; }   // Hardcourt
        public string Location { get; set; }    // Bjørntvedt / Tennishallen
        public string VisibleFor { get; set; }  // Klubb, Årskort, Member, Non-Member
        public DateTime Created { get; set; }
    }

    /* 
     * GROUP: Only collection of users
     */

    public class Booking
    {
        public int Id { get; set; }
        public BookingType Type { get; set; }   // Fast(grønn), Medlem(gul), Mesterskap(blå), Annet(rød)
        public User User { get; set; }      
        public Court Court { get; set; }        // Or only the Court Id?
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }       // Minutes
        public string DisplayAs { get; set; }
        public DateTime Created { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public Membership Membership { get; set; }  // Senior+Årskort
        public UserType UserType { get; set; }      // Coach
        public UserGroup Group { get; set; }        // Id? Senior/1800-1930
        public DateTime Birthdate { get; set; }
        public Sex Sex { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Mobile { get; set; }
        public string Contact1 { get; set; }    // Name, Phone, Email 
        public string Contact2 { get; set; }    // Name, Phone, Email 
        public DateTime Created { get; set; }
    }

    public class Membership
    {
        public string Id { get; set; }
        public string MemberNumber { get; set; }
        public string MemberType { get; set; }  // junior, senior, member, non-member, ...
        public Product Product { get; set; }    // Årskort
        public DateTime Created { get; set; }
        public DateTime Expires { get; set; }
        public bool Active { get; set; }
    }

    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }    // Barn 8-10 år
        public DateTime Created { get; set; }
    }

    // membership, ballmachine, personal-trainer, 
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductType ProductType { get; set; }
        public DateTime Created { get; set; }
    }


}
