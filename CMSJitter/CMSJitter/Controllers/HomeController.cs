using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using USERDataTransferObject;
namespace CMSJitter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        [HttpPost]
        public ActionResult Index(Register register)
        {
            ViewBag.Title = "Home Page";

            return View(register);
        }
    }
}
