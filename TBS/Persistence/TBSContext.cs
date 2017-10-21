using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TBS.Persistence
{
    public class TBSContext : DbContext
    {
        public TBSContext (DbContextOptions<TBSContext> options = null)
            : base(options)
        {
        }

        public DbSet<Domain.Club> Clubs { get; set; }
    }
}
