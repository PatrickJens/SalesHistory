using System.ComponentModel.DataAnnotations;

namespace MapicsHistory.Models
{
    public class ParentPart
    {
        [Key]
        public String Part { get; set; }
        [Required]
        public String? Description { get; set; }
    }
}
