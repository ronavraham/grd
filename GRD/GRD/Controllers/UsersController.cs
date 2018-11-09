using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using GRD.Models;
using GRD.Data;

namespace GRD.Controllers
{
    public class UsersController : Controller
    {
        private readonly ProjectContext _context;

        public UsersController(ProjectContext context)
        {
            _context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index(string searchString, string filterType)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            ViewData["CurrentFilter"] = searchString;
            ViewData["FilterType"] = filterType;
            var isAdmin = HttpContext.Session.GetString("isAdmin") == "true" ? true : false;
            if (!isAdmin)
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

        // GET: Users/Create
        public IActionResult Create()
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Username,Password,Address,Gender,IsAdmin")] User user)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(e => e.Username == user.Username))
                {
                    ViewData["errorMessage"] = "שם משתמש זה קיים כבר במערכת";
                    return View(nameof(Create));
                }
                _context.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return BadRequest();
        }

        // GET: Users/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Username,Password,Address,Gender,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                if (_context.Users.Any(e => e.Username == user.Username))
                {
                    ViewData["errorMessage"] = "שם משתמש זה קיים כבר במערכת";
                    return View(nameof(Register));
                }
                _context.Add(user);
                await _context.SaveChangesAsync();
                return await Login(user.Username, user.Password);
            }
            return BadRequest();
        }

        // GET: Users/Edit/5
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
        public async Task<IActionResult> Edit(int id, [Bind("Username,Password,Address,Gender,Id,IsAdmin")] User user)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            if (id != user.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // check if the edit user change it name, and if it did check if there is already Username in the db.
                    if (_context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id).Username != user.Username &&
                        _context.Users.Any(e => e.Username == user.Username))
                    {
                        ViewData["errorMessage"] = "שם משתמש זה קיים כבר במערכת";
                        return View(nameof(Edit));
                    }
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
            return BadRequest();
        }

        // GET: Users/Delete/5
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
            HttpContext.Session.SetString("isAdmin", user.IsAdmin ? "true" : "false");
            HttpContext.Session.SetString("username", user.Username);
            HttpContext.Session.SetString("userid", user.Id.ToString());
            HttpContext.Session.SetString("isLogin", "true");

            if (user.IsAdmin)
            {
                return RedirectToAction("Index", null);
            }
            return RedirectToAction("Index", "Home", null);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.SetString("isAdmin", "false");
            HttpContext.Session.SetString("username", "");
            HttpContext.Session.SetString("userid", "-1");
            HttpContext.Session.SetString("isLogin", "false");

            return RedirectToAction("Index", "Home", null);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (!IsAuthorized())
            {
                return Unauthorized();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return View("Views/Users/NotFound.cshtml");
            }
            user.Purchases.ToList().ForEach(p => user.Purchases.Remove(p));
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        private bool IsAuthorized()
        {
            return (HttpContext.Session.GetString("isAdmin") == "true" ? true : false) &&
                (HttpContext.Session.GetString("isLogin") == "true" ? true : false);
        }
    }
}
