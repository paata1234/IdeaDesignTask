using IdeaDesignTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdeaDesignTask.Data
{
    public class Appdbcontext : DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options) : base (options)
        {

        }

        public DbSet<Physicalusers> Physicalusers { get; set; }

        public DbSet<Company> Company { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Physicalusers>()
                .HasMany(c => c.Company)
                .WithMany(c => c.Users);
        }


    }
}
