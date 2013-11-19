using System.ComponentModel.Composition;
using NerverLand.Module.Contract.Modules;

namespace NerverLand.Module.ChassisProvider
{
    [Export(typeof(IModule))]
    public class ChassisModule : ChassisModuleBase.ChassisModuleBase
    {
    }
}
