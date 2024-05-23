using Domain.Entities;
using Domain.Entities.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class AppDbContext:IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<RegionOfCity > RegionOfCities { get; set; }
        public DbSet<City> Citys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
          

            modelBuilder.Entity<Property>()
               .HasOne<Owner>(s => s.Owner)
               .WithMany(ta => ta.Properties)
               .HasForeignKey(u => u.OwnerId)
               .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Property>()
              .HasOne<RegionOfCity>(s => s.RegionOfCity)
              .WithMany(ta => ta.Properties)
              .HasForeignKey(u => u.RegionOfCityId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Property>()
              .HasOne<Agent>(s => s.Agent)
              .WithMany(ta => ta.Properties)
              .HasForeignKey(u => u.AgentId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Property>()
          .HasOne<Category>(s => s.Category)
          .WithMany(ta => ta.Properties)
          .HasForeignKey(u => u.CategoryId)
          .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RegionOfCity>()
              .HasOne<City>(s => s.City)
              .WithMany(ta => ta.RegionOfCities)
              .HasForeignKey(u => u.CityId)
              .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Image>()
             .HasOne<Property>(s => s.Property)
             .WithMany(ta => ta.Images)
             .HasForeignKey(u => u.PropertyId)
             .OnDelete(DeleteBehavior.NoAction);


            




        }

    }
}

