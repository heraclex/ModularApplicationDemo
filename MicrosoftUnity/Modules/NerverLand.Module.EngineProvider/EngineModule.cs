namespace NerverLand.Module.EngineProvider
{
    using System.ComponentModel.Composition;

    using NerverLand.Module.CarModule;
    using NerverLand.Module.Contract.Modules;

    [Export(typeof(IModule))]
    public class EngineModule : CarModuleBase
    {
    }
}
