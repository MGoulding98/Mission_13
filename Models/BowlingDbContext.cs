using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_13.Models
{
    public class BowlingDbContext : DbContext
    {
        public BowlingDbContext(DbContextOptions<BowlingDbContext> options) : base(options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; }
    }
}
