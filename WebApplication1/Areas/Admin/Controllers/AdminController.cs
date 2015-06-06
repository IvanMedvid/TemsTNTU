using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        
    }
}