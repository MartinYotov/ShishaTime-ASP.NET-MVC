using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShishaTime.Web.Controllers
{
    public class ErrorPagesController : Controller
    {
        public ActionResult Page400()
        {
            return View();
        }

        public ActionResult Page401()
        {
            return View();
        }

        public ActionResult Page404()
        {
            return View();
        }

        public ActionResult Page500()
        {
            return View();
        }
    }
}