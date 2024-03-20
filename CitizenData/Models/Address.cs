using System.ComponentModel.DataAnnotations;

namespace CitizenData.Models
{
    public class Address
    {
        [Key]
        public string? AddressLine { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}