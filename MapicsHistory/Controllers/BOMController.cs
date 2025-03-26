using MapicsHistory.Data;
using MapicsHistory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MapicsHistory.Controllers
{
    public class BOMController : Controller
    {

        private readonly ILogger<BOMController> _logger;


        private readonly ApplicationDbContext _db;


        private ParentPartBOM _ParentPartBOM = new ParentPartBOM();

        public BOMController(ApplicationDbContext db, ILogger<BOMController> logger)
        {
            _db = db;
            _logger = logger;
        }
        public IActionResult BOMIndex()
        {
            return View("BOMIndex");
        }
        public IActionResult ParentPartSearch(String search_phrase, String search_field)
        {
            search_phrase = "%" + search_phrase + "%";
            IQueryable<ParentPart> spParentPart;
            switch (search_field)
            {
                case "PartNum":
                    spParentPart = _db.ParentPart.FromSqlRaw($"EXEC spBOMp1 @prmPartNum = N'{search_phrase}'").AsNoTracking();
                    break;
                case "PartDescription":
                    spParentPart = _db.ParentPart.FromSqlRaw($"EXEC spBOMp2 @prmDesc = N'{search_phrase}'").AsNoTracking();
                    break;
                default:
                    spParentPart = null;
                    break;
            }
            List<ParentPart> spParentPartList = spParentPart.ToList();
            _ParentPartBOM.ParentPartList = spParentPartList;
            return View("BOMIndex", _ParentPartBOM);
        }

        public IActionResult BOMSearch(String parent_part_num)
        {
            //IQueryable<ParentPart> spParentPart = _db.ParentPart.FromSqlRaw($"EXEC spBOMp1 @prmPartNum = N'{parent_part_num}'").AsNoTracking();
            //List<ParentPart> spParentPartList = spParentPart.ToList();
            //ParentPart original_parent_part = spParentPartList.Find(pp => pp.Part.Equals(parent_part_num));
            IQueryable<BOM> spBOM = _db.BOM.FromSqlRaw($"EXEC spBOMLookup @prmPartNum = N'{parent_part_num}'").AsNoTracking();
            List<BOM> spBOMList = spBOM.ToList();
            spBOMList = spBOMList.OrderBy(part => part.Part).ToList();
            _ParentPartBOM.BomList = spBOMList;


            return View("BOMIndex", _ParentPartBOM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
