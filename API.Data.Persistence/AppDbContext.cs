using APITemplate.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Data
{
   public class AppDbContext : DbContext
    {
        public DbSet<Application> Applications { get; set; }
        public DbSet<ApplicationContact> Contacts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //TODO :Move this code to separate class under Schema Folder.
            modelBuilder.Entity<Application>().ToTable("Applications");
            modelBuilder.Entity<Application>().HasKey(p => p.Id);
            modelBuilder.Entity<Application>().Property(p => p.Id)
                                                .IsRequired()
                                                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Application>().Property(p => p.AppName)
                                                .HasMaxLength(100);

            modelBuilder.Entity<Application>().Property(p => p.Description)
                                                .HasMaxLength(250);
            modelBuilder.Entity<Application>().HasMany(p => p.Contacts).WithOne(p => p.Application);
            modelBuilder.Entity<Application>().HasData(
                new Application { Id = 1, AppName = "Web API App", Description = "This is Service exposed to other application." },
                new Application { Id = 2, AppName = "Angular UI App", Description = "This is front end part of the application " }
                );

            modelBuilder.Entity<ApplicationContact>().ToTable("Contacts");
            modelBuilder.Entity<ApplicationContact>().HasKey(p => p.ID);
            modelBuilder.Entity<ApplicationContact>().Property(p => p.ID).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<ApplicationContact>().Property(p => p.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<ApplicationContact>().Property(p => p.Designation).HasMaxLength(250);
        }
    }
}
