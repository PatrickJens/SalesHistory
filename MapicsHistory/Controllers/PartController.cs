using MapicsHistory.Data;
using MapicsHistory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Text;


namespace MapicsHistory.Controllers
{
    public class PartController : Controller
    {
        private readonly ILogger<PartController> _logger;
        private readonly ApplicationDbContext _db;

        public PartController(ApplicationDbContext db, ILogger<PartController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult PartIndex()
        {
            return View();
        }
        public IActionResult PartSearch(String search_phrase, String search_field)
        {
            search_phrase = "%" + search_phrase + "%";
            IQueryable<Part> spPart;
            Console.WriteLine("phrase= " + search_phrase + "  " + "search_fields= " + search_field);
            spPart = queryDb( search_phrase,  search_field);
            List<Part> spPartList = spPart.ToList();
            return View("PartIndex", spPartList);
        }
        private IQueryable<Part> queryDb(String search_phrase, String search_field)
        {
            IQueryable<Part> spPart;
            switch (search_field)
            {
                case "PartNum":
                    spPart = _db.Part.FromSqlRaw($"EXEC spPartLookup1 @prmPartNum = N'{search_phrase}'").AsNoTracking();
                    break;
                case "PartDescription":
                    spPart = _db.Part.FromSqlRaw($"EXEC spPartLookup2 @prmDescription = N'{search_phrase}'").AsNoTracking();
                    break;
                case "MfgComment":
                    spPart = _db.Part.FromSqlRaw($"EXEC spPartLookup3 @prmMfg = N'{search_phrase}'").AsNoTracking();
                    break;
                case "PurComment":
                    spPart = _db.Part.FromSqlRaw($"EXEC spPartLookup4 @prmPur = N'{search_phrase}'").AsNoTracking();
                    break;
                default:
                    spPart = _db.Part.FromSqlRaw($"EXEC spPartLookup1 @prmPartNum = N'{search_phrase}'").AsNoTracking();
                    break;
            }
            return spPart;
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
