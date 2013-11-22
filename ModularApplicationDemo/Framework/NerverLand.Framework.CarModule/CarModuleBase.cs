namespace NerverLand.Framework.CarModule
{
    using System;
    using System.Linq;

    using NerverLand.Framework.Common.Export;
    using NerverLand.Framework.Contract.Modules;
    using NerverLand.Framework.Contract.Provider;
    using NerverLand.Framework.Core.Module;

    public class CarModuleBase : ModuleBase, ICarModule
    {
        #region Static Fields

        /// <summary>
        /// The cached <see cref="ICarComponentProvider"/> type for performance purpose.
        /// </summary>
        private static readonly Type GeneratorType = typeof(ICarComponentProvider);

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CarModuleBase"/> class.
        /// </summary>
        protected CarModuleBase()
        {
            this.ExportCarModule();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Export all CarComponentProvider classes.
        /// </summary>
        protected virtual void ExportCarModule()
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
