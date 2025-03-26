using System.ComponentModel.DataAnnotations;

namespace MapicsHistory.Models
{
    public class POVendor
    {
        [Key]
        public String? PONumber { get; set; }
        [Required]
        public String? VendorID { get; set; }
        [Required]
        public String? Name { get; set; }
        public Decimal Amount { get; set; }
        public DateOnly? OrderDate { get; set; }

    }
}
