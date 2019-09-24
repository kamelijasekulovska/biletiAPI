using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BiletiApp.API.Models
{
    public class BiletiDbContext : DbContext
    {
        public BiletiDbContext(DbContextOptions<BiletiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<BiletiEvent> BiletiEvents { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BiletiEvent>()
            .HasOne(o => o.Organization)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<BiletiEvent>()
            .HasOne(v => v.Venue)
            .WithMany()
            .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Organization>()
                .HasMany(c => c.Contacts)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Organization>()
                .HasMany(g => g.Gallery)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Sector>()
                .HasMany(s => s.Seats)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Ticket>()
                .HasOne(e => e.Event)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Transaction>()
                .HasOne(t => t.Ticket)
                .WithMany()
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<User>()
                .HasOne(o => o.Organization)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Venue>()
                .HasMany(c => c.Contacts)
                .WithOne()
                .OnDelete(DeleteBehavior.SetNull);

            builder.Entity<Venue>()
                .HasMany(s => s.Sectors)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            

                
               
        }

    }

}
