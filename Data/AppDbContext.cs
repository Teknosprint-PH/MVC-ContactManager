using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using tech_challenge.Models;

namespace tech_challenge.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Contact_Info> tblContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed one data
            modelBuilder.Entity<Contact_Info>().HasData(
                new Contact_Info
                {
                    contact_id = 1,
                    contact_lastname = "Codilla",
                    contact_firstname = "Antonio",
                    contact_middlename = "Fabillar",
                    contact_address = "Tipolo, Mandaue City",
                    contact_no = "1234-567890123",
                    location_lat = 12.8797,
                    location_long = 121.7740,
                    contact_status = "AC",
                    created_by = "JCASO",
                    created_dt = DateTime.Now
                });
        }
    }
}
