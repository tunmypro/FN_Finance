using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finance.Controllers
{

    public class SearchingController : Controller
    {
        private Finance5917Entities1 db = new Finance5917Entities1();
        // GET: Searching
        public ActionResult Index()
        {
            var data = db.Contracts.ToList();
            return View(data);
        }
    }
}