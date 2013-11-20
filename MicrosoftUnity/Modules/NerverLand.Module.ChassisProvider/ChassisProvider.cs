using System;
using NerverLand.Module.CarComponent.Contract;

namespace NerverLand.Module.ChassisProvider
{
    using NerverLand.Module.CarModule;

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
