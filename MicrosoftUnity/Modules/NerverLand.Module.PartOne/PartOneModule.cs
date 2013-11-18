namespace NerverLand.Module.PartOne
{
    using System.ComponentModel.Composition;

    using NerverLand.Module.Contract.Modules;
    using NerverLand.Module.PartOneBase;

    [Export(typeof(IModule))]
    public class PartOneModule : PartOneModuleBase
    {
    }
}
