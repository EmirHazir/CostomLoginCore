using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CostumLogin.Model
{
    public class OurDbContext : DbContext
    {
        public OurDbContext(DbContextOptions<OurDbContext> options):base (options)
        {

        }
        public DbSet<UserAccount> UserAccount { get; set; }
    }
}
