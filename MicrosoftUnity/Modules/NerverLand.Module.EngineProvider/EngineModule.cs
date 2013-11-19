using System.ComponentModel.Composition;
using NerverLand.Module.Contract.Modules;

namespace NerverLand.Module.EngineProvider
{
    [Export(typeof(IModule))]
    public class EngineModule : EngineModuleBase.EngineModuleBase
    {
    }
}
