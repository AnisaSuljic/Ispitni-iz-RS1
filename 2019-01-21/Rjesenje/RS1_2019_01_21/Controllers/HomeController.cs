﻿using Microsoft.AspNetCore.Mvc;
using RS1_2019_01_21.EF;

namespace RS1_2019_01_21.Controllers
{
    public class HomeController : Controller
    {
        private MojContext _context;

        public HomeController(MojContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TestDB()
        {
            MojDBInitializer.Izvrsi(_context);
            return View(_context); 
        }

     
    }
}