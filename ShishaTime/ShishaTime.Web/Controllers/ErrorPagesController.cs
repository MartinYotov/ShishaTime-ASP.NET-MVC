using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShishaTime.Web.Controllers
{
    public class ErrorPagesController : Controller
    {
        public ActionResult Page403()
        {
            return View();
        }
    }
}