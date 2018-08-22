using System;

/*
TODO: Separate into WriteModel and ReadModel  (Model.Write, Model.Read)?
*/

namespace TBS.Entities
{
    public enum Weekday { Mon, Tue, Wed, Thu, Fri, Sat, Sun }
    public enum Sex { Male, Female }

    public class Club
    {
        public int Id { get; set; }
        public string ClubName { get; set; }
        public string ShortName { get; set; }
        public string Contact { get; set; }
        public  int CustomerId { get; set; }

        //public string Address { get; set; }
        //public int MaxCourts { get; set; }
        //public string Subscription { get; set; }
        //public decimal Price { get; set; }
        //public bool AutoRenewal { get; set; }
        //public DateTime NextRenewalDate { get; set; }

        public bool Active { get; set; }
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
    }

    public class Court
    {
        public int Id { get; set; }
        public string Name { get; set; }        // Bane 2 Ute
        public int ClubId { get; set; }         // 1-Prod, 2-Test
        public int CourtGroup { get; set; }     // Ute, Inne
        public bool Active { get; set; }
        public string CourtType { get; set; }   // Hardcourt
        public string Location { get; set; }    // Bjørntvedt / Tennishallen
        public string VisibleFor { get; set; }  // Klubb, Årskort, Member, Non-Member
        public DateTime Created { get; set; }
        public bool Deleted { get; set; }
    }

    /* 
     * GROUP: Only collection of users
     */

    public class Booking
    {
        public int Id { get; set; }
        public BookingType Type { get; set; }   // Use only Id in write-model 
        public User User { get; set; }      
        public Court Court { get; set; }        // Use only CourtId in Write model
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }       // Minutes
        public string DisplayAs { get; set; }
        public DateTime Created { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClubId { get; set; }
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
        public bool Deleted { get; set; }
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
