using System.ComponentModel.DataAnnotations;

namespace CitizenData.Models
{
    public class Date
    {
        [Key]
        public string? DateType { get; set; }
        public DateTime? DateValue { get; set; }
    }
}
