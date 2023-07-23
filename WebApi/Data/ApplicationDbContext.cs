using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Model.DbEntities;

namespace Data
{
    public class ApplicationDbContext:DbContext
    {
   
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }


        public virtual DbSet<Clinic> Clinics { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Permanence> Permanence { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(log => Console.WriteLine(log),
                new[] { DbLoggerCategory.Database.Command.Name },
                LogLevel.Information)
               .EnableSensitiveDataLogging();

        }

       
    }
}