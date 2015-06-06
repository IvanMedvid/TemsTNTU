using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.SuperAdmin.Controllers
{
    public class HomeController : SuperAdminController
    {
        // GET: SuperAdmin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}