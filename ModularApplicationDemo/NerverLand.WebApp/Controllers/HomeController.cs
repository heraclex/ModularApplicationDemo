using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NerverLand.WebApp.Controllers
{
    using NerverLand.CarComponent.Contract;
    using NerverLand.WebApp.Models;

    public class HomeController : Controller
    {
        private ITireProvider tireProvider;

        private IChassisProvider chassisProvider;

        private IEngineProvider engineProvider;

        public HomeController(ITireProvider tireProvider, IChassisProvider chassisProvider, IEngineProvider engineProvider)
        {
            this.tireProvider = tireProvider;
            this.chassisProvider = chassisProvider;
            this.engineProvider = engineProvider;
        }

        public ActionResult Index()
        {
            var model = new CarModel
            {
                CarName = "New Car model 2013: producted by factory component",
                ChassisModel = this.chassisProvider.GetComponentName(),
                EngineModel = this.engineProvider.GetComponentName(),
                TireModel = this.tireProvider.GetComponentName(),
                Year = 2013
            };
            return this.View(model);
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
