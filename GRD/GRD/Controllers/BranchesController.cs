using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GRD.Data;
using GRD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GRD.Controllers
{
    public class BranchesController : Controller
    {
        private readonly ProjectContext _context;

        public BranchesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Branches
        public async Task<IActionResult> Index(string Name, string City, string Address)
        {
            ViewData["BranchesNameQuery"] = Name;
            ViewData["BranchesCityQuery"] = City;
            ViewData["BranchesAddressQuery"] = Address;

            var branches = _context.Branches.Select(x => x);

            if (!String.IsNullOrEmpty(Name))
            {
                branches = branches.Where(x => x.Name.Contains(Name));
            }

            if (!String.IsNullOrEmpty(City))
            {
                branches = branches.Where(x => x.City.Contains(City));
            }

            if (!String.IsNullOrEmpty(Address))
            {
                branches = branches.Where(x => x.Address.Contains(Address));
            }

            return View(await branches.AsNoTracking().ToListAsync());
        }

        // GET: Branches/Create
        public IActionResult Create()
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Lat,Long,Name,City,Address,Telephone,IsSaturday,Id")] Branch branch)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                _context.Add(branch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }
            return View(branch);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Lat,Long,Name,City,Address,Telephone,IsSaturday,Id")] Branch branch)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            if (id != branch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchExists(branch.Id))
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
            return View(branch);
        }

        // GET: Branches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            if (id == null)
            {
                return NotFound();
            }

            var branch = await _context.Branches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            var branch = await _context.Branches.FindAsync(id);
            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BranchExists(int id)
        {
            return _context.Branches.Any(e => e.Id == id);
        }

        private bool IsAuthorized()
        {
            return (HttpContext.Session.GetString("isAdmin") == "true" ? true : false) &&
                (HttpContext.Session.GetString("isLogin") == "true" ? true : false);
        }
    }
}
