
using System.ComponentModel.Composition;
using NerverLand.Module.Contract.Modules;

namespace NerverLand.Module.TireProvider
{
    [Export(typeof(IModule))]
    public class TireModule : TireModuleBase.TireModuleBase
    {
    }
}
