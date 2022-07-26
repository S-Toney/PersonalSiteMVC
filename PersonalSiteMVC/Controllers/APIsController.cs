using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalSiteMVC.Controllers
{
    public class APIsController : Controller
    {
        // GET: APIs
        public ActionResult ZipCode()
        {
            return View();
        }
    }
}