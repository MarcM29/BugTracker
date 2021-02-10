using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BugTracker.Models;

namespace BugTracker.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BugTracker.Models.Ticket> Ticket { get; set; }
        public DbSet<BugTracker.Models.Dev> Dev { get; set; }
        public DbSet<BugTracker.Models.ResolvedTicket> ResolvedTicket { get; set; }

    }
}
