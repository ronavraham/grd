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
    public class AdminController : Controller
    {
        private readonly ProjectContext _context;

        public AdminController(ProjectContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "דף מנהל";
            return View();
        }

        [HttpGet]
        public JsonResult BranchSales()
        {
            var result = _context.Purchases.Join(_context.Branches,
                (purchase => purchase.Branch.Id),
                (branch => branch.Id),
                (p, b) => new
                {
                    branchId = b.Id,
                    branchName = b.Name,
                    count = p.Count
                })
            .GroupBy(b => b.branchId)
            .Select(p => new
            {
                Count = p.Sum(pur => pur.count),
                Name = p.First(pur => pur.branchId == p.Key).branchName,
                Id = p.Key
            });

            return Json(result);
        }

        [HttpGet]
        public JsonResult ProductSales()
        {
            var result = _context.Purchases.Join(_context.Products,
                (purchase => purchase.Product.Id),
                (product => product.Id),
                (pur, pro) => new
                {
                    productId = pro.Id,
                    productName = pro.Name,
                    count = pur.Count
                })
            .GroupBy(b => b.productId)
            .Select(p => new
            {
                Count = p.Sum(pur => pur.count),
                Name = p.First(pur => pur.productId == p.Key).productName,
                Id = p.Key
            });

            return Json(result);
        }
    }
}