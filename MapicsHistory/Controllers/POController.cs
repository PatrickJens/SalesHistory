using MapicsHistory.Data;
using MapicsHistory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace MapicsHistory.Controllers
{
    public class POController : Controller
    {
        private readonly ApplicationDbContext _db;
        private POPOVendor _POPOVendor = new POPOVendor();

        public POController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult POIndex()
        {
            return View();
        }
        public IActionResult POSearch(String search_phrase, String search_field)
        {
            search_phrase = "%" + search_phrase + "%";
            IQueryable<PO> spPO = null;
            List<PO> spPOList = null;
            IQueryable<POVendor> spPOVendor = null;
            List<POVendor> spPOVendorList = null;
            Console.WriteLine("phrase= " + search_phrase + "  " + "search_fields= " + search_field);
            switch (search_field)
            {
                case "PONum":
                    spPO = _db.PO.FromSqlRaw($"EXEC spPOLookup @prmPONum = N'{search_phrase}'").AsNoTracking();
                    break;
                case "PartNum":
                    spPO = _db.PO.FromSqlRaw($"EXEC spPOLookupPart @prmPartNum = N'{search_phrase}'").AsNoTracking();
                    break;
                case "VendID":
                    spPOVendor = _db.POVendor.FromSqlRaw($"EXEC spPOLookupVendID @prmVendID = N'{search_phrase}'").AsNoTracking();
                    break;
                case "VendName":
                    spPOVendor = _db.POVendor.FromSqlRaw($"EXEC spPOLookupVendName @prmVendName = N'{search_phrase}'").AsNoTracking();
                    break;
                default:
                    break;

            }
            if (spPO != null){
                spPOList = spPO.ToList();
                _POPOVendor.PO = spPOList;
            }
            if (spPOVendor != null){
                spPOVendorList = spPOVendor.ToList();
                _POPOVendor.POVendor = spPOVendorList;
            }
            return View("POIndex", _POPOVendor);

        }
    }
}
