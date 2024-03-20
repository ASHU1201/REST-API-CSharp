using System.ComponentModel.DataAnnotations;

namespace CitizenData.Models
{
    public class Name
    {
        [Key]
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? Surname { get; set; }
    }

}