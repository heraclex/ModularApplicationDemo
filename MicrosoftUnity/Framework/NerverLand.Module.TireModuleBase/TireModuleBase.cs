// --------------------------------------------------------------------------------------------------------------------
// <copyright file="" company="">
//   
// </copyright>
// <summary>
//   The Tire module base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace NerverLand.Module.TireModuleBase
{
    using System;
    using System.Linq;

    using NerverLand.Module.Common.Export;
    using NerverLand.Module.Contract.Modules;
    using NerverLand.Module.Contract.Provider;
    using NerverLand.Module.Core.Module;

    /// <summary>
    /// The Part One module base.
    /// </summary>
    public class TireModuleBase : ModuleBase, ITireModule
    {

        #region Static Fields

        /// <summary>
        /// The cached <see cref="ITireProvider"/> type for performance purpose.
        /// </summary>
        private static readonly Type GeneratorType = typeof(ITireProvider);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TireModuleBase"/> class.
        /// </summary>
        protected TireModuleBase()
        {
            this.ExportTireModule();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Export all tire provider classes.
        /// </summary>
        protected virtual void ExportTireModule()
        {
            Type[] types = this.GetType().Assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsAbstract || (!GeneratorType.IsAssignableFrom(type)))
                {
                    continue;
                }

                string infName = "I" + type.Name;
                Type infType = type.GetInterfaces().FirstOrDefault(t => t.Name == infName);

                if (infType == null)
                {
                    continue;
                }

                this.Add(ExportEntry.Instance(infType, type));
            }
        }

        #endregion
    }
}
