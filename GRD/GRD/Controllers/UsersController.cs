using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Http;

namespace GRD.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersContext _context;

        public UsersController(UsersContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string searchString, string filterType)
        {
            ViewData["CurrentFilter"] = searchString;
            ViewData["FilterType"] = filterType;
            var isAdmin = HttpContext.Session.GetString("isAdmin");
            if (isAdmin == null || isAdmin.CompareTo("yes") < 0)
            {
                return RedirectToAction("Index", "Home", null);
            }
            var users = _context.Users.Select(s => s);
            if (!String.IsNullOrEmpty(searchString))
            {
                switch (filterType)
                {
                    case "שם משתמש":
                        users = users.Where(s => s.Username.Contains(searchString));
                        break;
                    case "סיסמא":
                        users = users.Where(s => s.Password.Contains(searchString));
                        break;
                    case "כתובת":
                        users = users.Where(s => s.Address.Contains(searchString));
                        break;
                }
            }
            return View(await users.AsNoTracking().ToListAsync());
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,Address,Id,Gender,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Username,Password,Address,Id,Gender,IsAdmin")] User user)
        {
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id))
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
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Login/5
        public async Task<IActionResult> Login(string userName, string password)
        {
            if (userName == null || password == null)
            {
                return View();
            }

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Username == userName && u.Password == password);
            if (user == null)
            {
                return View("Views/Users/NotFound.cshtml");
            }
            HttpContext.Session.SetString("isAdmin", user.IsAdmin ? "yes" : "no");
            HttpContext.Session.SetString("username", user.Username);

            if (user.IsAdmin)
            {
                return RedirectToAction("Index", null);
            }
            return RedirectToAction("Index", "Home", null);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
