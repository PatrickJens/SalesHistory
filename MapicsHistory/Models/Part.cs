using System.ComponentModel.DataAnnotations;

namespace MapicsHistory.Models
{
    
    public class Part
    {
        [Key]
        public String? PartNum { get; set; }
        [Required]
        public String? PartDescription { get; set; }
        [Required]
        public String? ProdCode {  get; set; }
        [Required]
        public String? ClassID { get; set; }
        [Required]
        public String? IUM { get; set; }
        [Required]
        public String? PUM { get; set; }
        [Required]
        public String? TypeCode { get; set; }
        [Required]
        public String? PurComment { get; set; }
        [Required]
        public String? MfgComment { get; set; }
    }
}
