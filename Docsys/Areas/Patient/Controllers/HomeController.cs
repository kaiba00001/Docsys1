﻿using Microsoft.AspNetCore.Mvc;

namespace Docsys.Areas.Patient.Controllers
{
    [Area ("Patient")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
