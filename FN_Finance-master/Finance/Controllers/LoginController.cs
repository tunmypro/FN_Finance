using Finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Finance.Controllers
{

    public class LoginController : Controller
    {
        private Finance5917Entities1 db = new Finance5917Entities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User_Finance id)
        {
            if (id.Username != null && id.Password != null)
            {
                var n = db.User_Finance.Where(x => x.Username == id.Username && x.Password == id.Password).FirstOrDefault();
                if (n != null)
                {
                    Session["Pass"] = n;
                    Session["User"] = n.Name;
                    Session["currentSetTimeout"] = 1;
                    return RedirectToAction("UserCheck");
                }
            }
            return RedirectToAction("UserCheck");
        }

        public ActionResult UserCheck()
        {
            if (Session["User"] != null)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("UserCheck");
        }


    }
}
