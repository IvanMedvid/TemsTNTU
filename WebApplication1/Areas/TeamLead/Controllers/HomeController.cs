using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Areas.TeamLead.Controllers
{
    public class HomeController : TeamLeadController
    {
        // GET: TeamLead/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}