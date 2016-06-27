using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using hbulens.Exam70487.Common;
using hbulens.Exam70487.Core;
using hbulens.Exam70487.Repositories;
using hbulens.Exam70487.Cache;

namespace hbulens.Exam70487.WebUI.Controllers
{
    public class CacheController : Controller
    {
        #region Constructor

        public CacheController()
        {
            this.CacheRepository = new CacheRepository<Customer>();
        }

        #endregion Constructor

        #region Properties

        private IRepository<Customer> CacheRepository { get; set; }

        #endregion Properties

        #region Methods

        public IActionResult Index()
        {
            return View(this.CacheRepository.Get());
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            this.CacheRepository.Create(customer);
            return Ok(customer);
        }

        [HttpDelete]
        public IActionResult Delete(Customer customer)
        {
            this.CacheRepository.Delete(customer);
            return Ok(customer);
        }

        #endregion Methods

    }
}