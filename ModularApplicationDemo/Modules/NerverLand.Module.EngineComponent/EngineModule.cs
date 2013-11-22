namespace NerverLand.Module.EngineComponent
{
    using System.ComponentModel.Composition;

    using NerverLand.Framework.CarModule;
    using NerverLand.Framework.Contract.Modules;

    [Export(typeof(IModule))]
    public class EngineModule : CarModuleBase
    {
    }
}
