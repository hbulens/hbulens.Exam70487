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
using System.Xml.Linq;

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
            // Generate XML
            XElement collectionElement = new XElement("Customers");
            XElement customer1 = new XElement("Customer",
                new XAttribute("CrazyLevel", "Off The Charts"),
                new XElement("FirstName", "Donald Trumps"));

            XElement customer2 = new XElement("Customer");
            XComment randomComment = new XComment("I wasn't originally going to get a brain transplant, but then I changed my mind.");
            XElement customer3 = new XElement("Customer",
                new XAttribute("CrazyLevel", "Fairly Crazy"),
                new XElement("FirstName", "Hillbilly Clinton"));

            collectionElement.Add(customer1, randomComment, customer2, customer3);
            XDocument xmlDocument = new XDocument(collectionElement);
            ViewBag.Xml = xmlDocument.ToString();

            // Read XML 
            XDocument incomingXml = XDocument.Parse((string)ViewBag.Xml);

            int nodeCount = incomingXml.Descendants().Count();
            int firstNameCount = incomingXml.Descendants("Customer").Descendants("FirstName").Count();
            int crazyCount = incomingXml.Descendants("Customer").Count(x => x.Attribute("CrazyLevel")?.Value == "Off The Charts");

            ViewBag.NodeCount = nodeCount;
            ViewBag.CountFirstName = firstNameCount;
            ViewBag.CrazyCount = crazyCount;
            ViewBag.CrazyCountList = string.Join(",",
                incomingXml.Descendants("Customer")
                .Where(x => x.Attribute("CrazyLevel")?.Value == "Off The Charts")
                .Select(x => x.Descendants("FirstName").FirstOrDefault()?.Value));

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
            // Create document
            string documentPath = XmlCreator.Create(xml);

            // Read file using XmlReader
            XmlParser.ParseFile(documentPath);

            // Read file using XmlDocument
            XmlParser.ParseDocument(documentPath);

            return Json("Document is now available on " + documentPath);
        }


        #endregion Methods

    }
}