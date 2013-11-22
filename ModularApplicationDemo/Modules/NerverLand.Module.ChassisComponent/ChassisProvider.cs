
namespace NerverLand.Module.ChassisComponent
{
    using NerverLand.CarComponent.Contract;
    using NerverLand.Framework.CarModule;

    public class ChassisProvider : CarComponentProvider, IChassisProvider
    {
        public ChassisProvider()
        {
            this.ComponentName = "Chassis Model 2013";
        }

        public override void BuildComponent(string name)
        {

        }

        public override string GetComponentName()
        {
            return this.ComponentName;
        }
    }
}
