using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4TL.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Admin/Dashboard
        [Authorize(Roles = "admin")]

        public ActionResult Index()
        {
            return View();
        }
    }
}