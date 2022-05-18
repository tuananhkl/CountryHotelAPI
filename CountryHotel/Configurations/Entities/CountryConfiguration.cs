using System.Collections.Generic;
using CountryHotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountryHotel.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
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
        }
    }
}