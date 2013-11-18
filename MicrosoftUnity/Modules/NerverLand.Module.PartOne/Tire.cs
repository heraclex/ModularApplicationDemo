
namespace NerverLand.Module.PartOne
{
    using NerverLand.Module.Contract.ModuleTypes;

    public class Tire : ITire
    {
        public string GetTire(int size)
        {
            return "Tire for car: " + size + " inch.";
        }
    }
}
