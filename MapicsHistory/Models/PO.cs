using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MapicsHistory.Models
{

    public class PO
    {
        [Key]
        public String? PartNum { get; set; }
        [Required]
        public String? PartDescription { get; set; }
        [Required]
        public String? PONumber { get; set; }
        [Required]
        public String? VendorID { get; set; }
        [Required]
        public String? Name { get; set; }
        public DateOnly? OrderDate { get; set; }

        public Decimal? QtyOrdered { get; set; }
    }
}
