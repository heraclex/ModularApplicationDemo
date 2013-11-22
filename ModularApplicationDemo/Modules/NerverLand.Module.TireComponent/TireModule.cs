
namespace NerverLand.Module.TireComponent
{
    using System.ComponentModel.Composition;

    using NerverLand.Framework.CarModule;
    using NerverLand.Framework.Contract.Modules;

    [Export(typeof(IModule))]
    public class TireModule : CarModuleBase
    {
    }
}
