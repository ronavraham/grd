using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using GRD.Data;
using Microsoft.AspNetCore.Mvc;

namespace GRD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectContext _context;

        public HomeController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult AjaxGetCall(float lat, float lng)
        {
            var coord = new GeoCoordinate(lat, lng);
            var branches = _context.Branches.Select(x => x).ToList();

            var nearestBranch = branches.OrderBy(x => new GeoCoordinate(x.Lat, x.Long).GetDistanceTo(coord))
                                   .First();
            return Json(nearestBranch);
        }
    }
}