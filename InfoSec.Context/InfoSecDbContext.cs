using InfoSec.Context.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSec.Context
{
    public class InfoSecDbContext : DbContext
    {
        public InfoSecDbContext() : base("InfoSecDbConnectionString")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasMany(x => x.ActivityModerators)
                .WithRequired(x => x.Moderator)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(x => x.ActivityJuries)
                .WithMany(x => x.Juries);
        }
    }
}
