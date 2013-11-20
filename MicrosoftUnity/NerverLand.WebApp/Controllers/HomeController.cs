﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerverLand.WebApp.Controllers
{
    using NerverLand.Module.CarComponent.Contract;

    public class HomeController : Controller
    {
        private ITireProvider tireProvider;

        public HomeController(ITireProvider tireProvider)
        {
            this.tireProvider = tireProvider;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
