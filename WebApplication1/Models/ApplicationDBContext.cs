using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ApplicationDBContext:DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //https://entityframeworkcore.com/knowledge-base/50202735/how-to-tell-entity-framework-that-my-id-column-is-auto-incremented--aspnet-core-2-0-plus-postgresql--
            modelBuilder.Entity<Bid>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
            //modelBuilder.Entity<BidDetail>()
            //   .Property(p => p.Id)
            //   .ValueGeneratedOnAdd();
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=usersdb;Username=postgres;Password=postgres");
        //}
        public DbSet<Bid> Bids { get; set; }
        public DbSet<BidDetail> Details { get; set; }
    }
}
