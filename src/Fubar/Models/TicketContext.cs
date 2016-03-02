using System;
using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Fubar.Models
{
    public class TicketContext : IdentityDbContext<FubarUser>
    {
        public TicketContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
    }
}