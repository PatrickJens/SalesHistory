using MapicsHistory.Data;
using MapicsHistory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;

namespace MapicsHistory.Controllers
{
    public class POVendorController : Controller
    {
        private readonly ApplicationDbContext _db;
        public POVendorController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult POIndex()
        {
            return View();
        }
        public IActionResult POVendorSearch(String search_phrase, String search_field)
        {
            search_phrase = "%" + search_phrase + "%";
            IQueryable<POVendor> spPOVendor;
            List<POVendor> spPOListVendor = null;
            Console.WriteLine("phrase= " + search_phrase + "  " + "search_fields= " + search_field);
            switch (search_field)
            {
                case "VendID":
                    spPOVendor = _db.POVendor.FromSqlRaw($"EXEC spPOLookupVendID @prmVendID = N'{search_phrase}'").AsNoTracking();
                    break;
                case "VendName":
                    spPOVendor = _db.POVendor.FromSqlRaw($"EXEC spPOLookupVendName @prmVendName = N'{search_phrase}'").AsNoTracking();
                    break;
                default:
                    spPOVendor = _db.POVendor.FromSqlRaw($"EXEC spPOLookupVendID @prmVendID = N'{search_phrase}'").AsNoTracking();
                    break;

            }
            spPOListVendor = spPOVendor.ToList();
            return View("POVendorIndex", spPOListVendor);

        }
    }
}
