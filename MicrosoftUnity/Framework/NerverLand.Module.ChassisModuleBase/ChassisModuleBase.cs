// --------------------------------------------------------------------------------------------------------------------
// <copyright file="" company="">
//   
// </copyright>
// <summary>
//   The Tire module base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace NerverLand.Module.ChassisModuleBase
{
    using System;
    using System.Linq;

    using NerverLand.Module.Common.Export;
    using NerverLand.Module.Contract.Modules;
    using NerverLand.Module.Contract.Provider;
    using NerverLand.Module.Core.Module;

    /// <summary>
    /// The IChassisModule base.
    /// </summary>
    public class ChassisModuleBase : ModuleBase, IChassisModule
    {

        #region Static Fields

        /// <summary>
        /// The cached <see cref="ITireProvider"/> type for performance purpose.
        /// </summary>
        private static readonly Type GeneratorType = typeof(IChassisProvider);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ChassisModuleBase"/> class.
        /// </summary>
        protected ChassisModuleBase()
        {
            this.ExportChassisModule();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Export all tire provider classes.
        /// </summary>
        protected virtual void ExportChassisModule()
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
