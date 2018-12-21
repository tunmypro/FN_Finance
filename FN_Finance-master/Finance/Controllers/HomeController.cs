using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finance.Controllers
{
    public class HomeController : Controller
    {
        readonly Finance5917Entities1 db = new Finance5917Entities1();
        public ActionResult Index()
        {
            return View();
        }
    }
}