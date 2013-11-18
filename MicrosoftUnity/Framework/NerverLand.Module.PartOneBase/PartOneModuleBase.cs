// --------------------------------------------------------------------------------------------------------------------
// <copyright file="" company="">
//   
// </copyright>
// <summary>
//   The PartOne module base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace NerverLand.Module.PartOneBase
{
    using System;
    using System.Linq;

    using NerverLand.Module.Common.Export;
    using NerverLand.Module.Contract.Modules;
    using NerverLand.Module.Contract.ModuleTypes;
    using NerverLand.Module.Core.Module;

    /// <summary>
    /// The Part One module base.
    /// </summary>
    public class PartOneModuleBase : ModuleBase, IPartOneModule
    {
        
        #region Static Fields

        /// <summary>
        /// The cached <see cref="ITire"/> type for performance purpose.
        /// </summary>
        private static readonly Type GeneratorType = typeof(ITire);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PartOneModuleBase"/> class.
        /// </summary>
        protected PartOneModuleBase()
        {
            this.ExportPartOne();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Export all services classes.
        /// </summary>
        protected virtual void ExportPartOne()
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
