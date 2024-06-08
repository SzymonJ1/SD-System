using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SdSystem.Models;
using System.Collections.Generic;

namespace SdSystem.Data
{
    public class SdSystemContext : IdentityDbContext<ApplicationUser>
    {
        public SdSystemContext(DbContextOptions<SdSystemContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
    }
}
