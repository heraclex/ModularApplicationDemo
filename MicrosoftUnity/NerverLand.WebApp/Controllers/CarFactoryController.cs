namespace NerverLand.WebApp.Controllers
{
    using System.Web.Mvc;

    using NerverLand.Module.CarComponent.Contract;
    using NerverLand.WebApp.Models;

    public class CarFactoryController : Controller
    {
        private ITireProvider tireProvider;

        private IChassisProvider chassisProvider;

        private IEngineProvider engineProvider;

        public CarFactoryController(ITireProvider tireProvider, IChassisProvider chassisProvider, IEngineProvider engineProvider)
        {
            this.tireProvider = tireProvider;
            this.chassisProvider = chassisProvider;
            this.engineProvider = engineProvider;
        }

        public ActionResult Build()
        {
            var model = new CarModel
            {
                CarName = "New Car model 2013: producted by factory component",
                ChassisModel = this.chassisProvider.GetComponentName(),
                EngineModel = this.engineProvider.GetComponentName(),
                TireModel = this.tireProvider.GetComponentName(),
                Year = 2013
            };
            return this.View("CarInfo", model);
        }
    }
}