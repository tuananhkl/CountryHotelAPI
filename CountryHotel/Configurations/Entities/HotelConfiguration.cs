using System.Collections.Generic;
using CountryHotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CountryHotel.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasData(
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