namespace NerverLand.WebApp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CarModel
    {
        [Display(Name="Car Name")]
        public string CarName { get; set; }

        [Display(Name = "Model Year")]
        public int Year { get; set; }

        [Display(Name = "Tire Size")]
        public string TireModel { get; set; }

        [Display(Name = "Chassis Model")]
        public string ChassisModel { get; set; }

        [Display(Name = "Engine Info")]
        public string EngineModel { get; set; }
    }
}