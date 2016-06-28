using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hbulens.Exam70487.Common;
using hbulens.Exam70487.Core;
using hbulens.Exam70487.Repositories;
using hbulens.Exam70487.Cache;
using hbulens.Exam70487.Xml;
using System.IO;

namespace hbulens.Exam70487.WebUI.Controllers
{
    public class XmlController : Controller
    {
        #region Constructor

        public XmlController()
        {
        }

        #endregion Constructor

        #region Properties

        #endregion Properties

        #region Methods

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Validate(string xml)
        {
            return Json(XmlParser.Parse(xml));
        }

        [HttpPost]
        public IActionResult Create(string xml)
        {
            return Json(XmlCreator.Create(xml));
        }


        #endregion Methods

    }
}