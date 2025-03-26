using System.ComponentModel.DataAnnotations;

namespace MapicsHistory.Models
{
    public class BOM
    {
        [Key]
        public String? ParPart { get; set; }
        
        public String? Desc1 { get; set; }
        
        public String? ExtDesc1 { get; set; }
        
        public String? ExtDesc2 { get; set; }
        
        public Boolean? CheckBox01 { get; set; }
        
        public String? N4 { get; set; }
        
        public String Part { get; set; }
        
        public String? Descr { get; set; }
        
        public String? Ext1 { get; set; }
        
        public String? Ext2 { get; set; }
        
        public String? OpSeq { get; set; }
        
        public Decimal QtyPer { get; set; }
        
        public DateOnly? EffFrom { get; set; }
        
        public DateOnly? EffTo { get; set; }
        
        public String? OptCode { get; set; }
        
        public String? Numbr { get; set; }
        
        public Decimal LeadAdj { get; set; }
        
        public Decimal PlanFactor { get; set; }
        
        public Decimal CostFactor { get; set; }
        
        public String? UserText { get; set; }
    }
}
