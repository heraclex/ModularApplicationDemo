﻿
namespace NerverLand.Module.TireComponent
{
    using NerverLand.CarComponent.Contract;
    using NerverLand.Framework.CarModule;

    public class TireProvider : CarComponentProvider, ITireProvider
    {
        public TireProvider()
        {
            this.ComponentName = "Tire Model 2013";
        }

        public override void BuildComponent(string name)
        { }

        public override string GetComponentName()
        {
            return this.ComponentName;
        }
    }
}
