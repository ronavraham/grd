using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using GRD.Data;
using GRD.Models;
using Microsoft.AspNetCore.Mvc;

namespace GRD.Controllers
{
    public class BranchSalesView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class ProductSalesView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }

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
            var branches = _context.Branches.Select(x => new Branch
            {
                Id=x.Id,
                Lat=x.Lat,
                Long=x.Long,
                IsSaturday=x.IsSaturday,
                Address=x.Address,
                City=x.City,
                Name=x.Name,
                Telephone=x.Telephone
            }).ToList();

            var nearestBranch = branches.OrderBy(x => new GeoCoordinate(x.Lat, x.Long).GetDistanceTo(coord))
                                   .First();
            return Json(nearestBranch);
        }

        [HttpGet]
        public JsonResult BranchSales()
        {
            var sales = new List<BranchSalesView>();
            int count = 0;
            var result = _context.Branches.Select(x => x).ToList();
            foreach (Branch b in result)
            {
                count = 0;
                if (b.Purchases.Count != 0)
                {
                    foreach(Purchase p in b.Purchases)
                    {
                        count += p.Count;
                    }
                }
                sales.Add(new BranchSalesView
                {
                    Id = b.Id,
                    Name = b.Name,
                    Count = count
                });
            }
            return Json(sales);
        }

        [HttpGet]
        public JsonResult ProductSales()
        {
            var sales = new List<BranchSalesView>();
            int count = 0;
            var result = _context.Products.Select(x => x).ToList();
            foreach (Product pro in result)
            {
                count = 0;
                if (pro.Purchases.Count != 0)
                {
                    foreach (Purchase pur in pro.Purchases)
                    {
                        count += pur.Count;
                    }
                }
                sales.Add(new BranchSalesView
                {
                    Id = pro.Id,
                    Name = pro.Name,
                    Count = count
                });
            }
            return Json(sales);
        }
    }
}