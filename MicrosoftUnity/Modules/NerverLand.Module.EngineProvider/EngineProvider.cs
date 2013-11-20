using NerverLand.Module.CarComponent.Contract;

namespace NerverLand.Module.EngineProvider
{
    using NerverLand.Module.CarModule;

    public class EngineProvider : CarComponentProvider, IEngineProvider
    {
        public EngineProvider()
        {
            this.ComponentName = "Engine Provider model 2013";
        }

        public override void BuildComponent(string name)
        {
            // do sth
        }

        public override string GetComponentName()
        {
            return this.ComponentName;
        }
    }
}
