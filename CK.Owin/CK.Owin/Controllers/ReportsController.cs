using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CK.Owin.Controllers
{
    public class ReportsController : Controller
    {
        [Authorize]
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}