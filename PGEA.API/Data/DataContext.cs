using System;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using PGEA.shared.Entities;

namespace PGEA.API.Data
{
	public class DataContext: DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<ProgramEvent> ProgramEvents { get; set; }
        public DbSet<AcademicEvent> AcademicEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProgramEvent>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Attendee>().HasKey(x => x.Cedula);
            modelBuilder.Entity<Attendee>()
                .Property(x => x.Cedula)
                .ValueGeneratedNever();
            modelBuilder.Entity<AcademicEvent>().HasIndex(x => x.Name).IsUnique();

        }


    }
}

