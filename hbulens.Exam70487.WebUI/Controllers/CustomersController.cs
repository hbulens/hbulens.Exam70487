﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace hbulens.Exam70487.WebUI.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult WebApi()
        {
            return View();
        }

        public IActionResult Wcf()
        {
            return View();
        }

        public IActionResult WcfData()
        {
            return View();
        }
    }
}
