using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http;
using GRD.Models;
using GRD.Data;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GRD.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProjectContext _context;

        private const string _staticImagesRoute = "wwwroot/images/products/";

        public ProductsController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "מסך מוצרים";
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products by query
        public async Task<IActionResult> Search(int Price, string Name, int Size)
        {
            ViewData["Title"] = "מסך מוצרים";
            ViewData["ProductsPriceQuery"] = Price;
            ViewData["ProductsNameQuery"] = Name;
            ViewData["ProductsSizeQuery"] = Size;
            var searchQuery = _context.Products.Select(s => s);
            if (Price != 0)
            {
                searchQuery = searchQuery.Where(s => s.Price.Equals(Price));
            }
            if (!String.IsNullOrEmpty(Name))
            {
                searchQuery = searchQuery.Where(s => s.Name.Contains(Name));
            }
            if (Size != 0)
            {
                searchQuery = searchQuery.Where(s => s.Size.Equals(Size));
            }
            return View("Index", await searchQuery.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["Title"] = "פירוט";
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            ViewData["Title"] = "יצירת מוצר חדש";
            PopulateSuppliersDropDownList();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile file, [Bind("Price,Name,Size,id,SupplierForeignKey")] Product product)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            // get the image name and save the path to the saved pictures
            var filePath = _staticImagesRoute + file.FileName;

            // save the image name to the pictureName property so we get it later for the view
            product.PictureName = file.FileName;

            // save the picture to the static path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            try
            {
                // save to DB
                if (ModelState.IsValid)
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateSuppliersDropDownList(product.SupplierForeignKey);

            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            ViewData["Title"] = "עריכת מוצר קיים";
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            PopulateSuppliersDropDownList(product.SupplierForeignKey);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Price,Name,Size,Id,PictureName,SupplierForeignKey")] Product product, IFormFile file)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            if (id != product.Id)
            {
                return NotFound();
            }

            // case the user put new image to update
            if (file != null)
            {
                // Set full path to file 
                string FileToDelete = _staticImagesRoute + product.PictureName,
                       fileToUpdate = _staticImagesRoute + file.FileName;

                // Delete the previus image file
                FileInfo deleteFile = new FileInfo(FileToDelete);
                deleteFile.Delete();

                // put the new picture name to product object
                product.PictureName = file.FileName;

                // save the picture to the static path
                using (var stream = new FileStream(fileToUpdate, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateSuppliersDropDownList(product.SupplierForeignKey);
            return View(product);
        }

        private void PopulateSuppliersDropDownList(object selectedSupplier = null)
        {
            var suppliersQuery = from d in _context.Suppliers
                                   orderby d.Name
                                   select d;
            ViewBag.SupplierForeignKey = new SelectList(suppliersQuery, "Id", "Name", selectedSupplier);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            ViewData["Title"] = "מחיקת מוצר";
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            var product = await _context.Products.FindAsync(id);
            // delete the product image from fs
            FileInfo deleteFile = new FileInfo(_staticImagesRoute + product.PictureName);
            deleteFile.Delete();
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private bool IsAuthorized()
        {
            return (HttpContext.Session.GetString("isAdmin") == "true" ? true : false) &&
                (HttpContext.Session.GetString("isLogin") == "true" ? true : false);
        }
    }
}
