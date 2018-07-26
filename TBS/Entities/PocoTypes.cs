using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TBS.Entities
{
    public class UserType
    {
        public string Type { get; set; }  // user, coach, manager, administrator
        public string Description { get; set; } 
    }

    public class BookingType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CourtType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ClubType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ProductType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GroupType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
