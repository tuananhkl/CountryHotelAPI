using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CountryHotel.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new List<Country>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Viet Nam",
                        ShortName = "VN"
                    },
                    new()
                    {
                        Id = 2,
                        Name = "The United State of America",
                        ShortName = "USA"
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Japan",
                        ShortName = "JP"
                    }
                }
                );

            builder.Entity<Hotel>().HasData(
                new List<Hotel>
                {
                    new()
                    {
                        Id = 1,
                        Name = "Hilton Hotels in Hanoi",
                        Address = "Hanoi",
                        Rating = 4.5,
                        CountryId = 1
                    },
                    new()
                    {
                        Id = 2,
                        Name = "Shinagawa Prince Hotel",
                        Address = "Tokyo",
                        Rating = 3.8,
                        CountryId = 3
                    },
                    new()
                    {
                        Id = 3,
                        Name = "Pod Time Square",
                        Address = "NewYork",
                        Rating = 4.3,
                        CountryId = 2
                    }
                }
            );
        }
    }
}