using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using GRD.Data;
using GRD.Models;
using Microsoft.AspNetCore.Http;
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
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            ViewData["Title"] = "דף מנהל";
            return View();
        }

        [HttpGet]
        public JsonResult BranchSales()
        {
            if (!IsAuthorized())
            {
                var res = Json("you are not autorized for this request");
                res.StatusCode = 401;
                return res;
            }
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
            if (!IsAuthorized())
            {
                var res = Json("you are not autorized for this request");
                res.StatusCode = 401;
                return res;
            }
            var result = _context.Purchases.Join(_context.Products,
                (purchase => purchase.Product.Id),
                (product => product.Id),
                (pur, pro) => new
                {
                    ProductTypeId = pro.ProductTypeId,
                    productName = pro.ProductType.Name,
                    count = pur.Count
                })
            .GroupBy(b => b.ProductTypeId)
            .Select(p => new
            {
                Count = p.Sum(pur => pur.count),
                Name = p.First(pur => pur.ProductTypeId == p.Key).productName,
                Id = p.Key
            });

            return Json(result);
        }

        private bool IsAuthorized()
        {
            return (HttpContext.Session.GetString("isAdmin") == "true" ? true : false) &&
                (HttpContext.Session.GetString("isLogin") == "true" ? true : false);
        }
    }
}