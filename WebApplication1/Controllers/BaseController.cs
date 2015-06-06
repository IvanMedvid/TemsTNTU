﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.DAL;

namespace WebApplication1.Controllers
{
    public class BaseController : Controller
    {
        private static TemsTNTUEntities instance;

        public static TemsTNTUEntities db
        {
            get
            {
                if (instance == null)
                {
                    instance = new TemsTNTUEntities();
                }
                return instance;
            }
        }
    }
}