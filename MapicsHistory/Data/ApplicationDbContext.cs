using MapicsHistory.Models;
using Microsoft.EntityFrameworkCore;

namespace MapicsHistory.Data
{
    public class ApplicationDbContext : DbContext
    {
        /* PartSet represents the query result set */
        public DbSet<Part> Part { get; set; }
        public DbSet<PO> PO { get; set; }
        public DbSet<POVendor> POVendor { get; set; }
        public DbSet<ParentPart> ParentPart { get; set; }
        public DbSet<BOM> BOM { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
