﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GRD.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index(string userName, string password)
        {
            return View();
        }
    }
}