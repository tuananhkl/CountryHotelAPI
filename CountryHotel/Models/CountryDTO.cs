using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CountryHotel.Model
{
    public class CreateCountryDTO
    {
        [Required]
        [StringLength(50, ErrorMessage = "Country Name is too long")]
        public string Name { get; set; }
        [Required]
        [StringLength(2, ErrorMessage = "Short Country Name is too long")]
        public string ShortName { get; set; }
    }
    public class CountryDTO : CreateCountryDTO
    {
        public int Id { get; set; }
        public IList<HotelDTO> Hotels { get; set; }
    }
}