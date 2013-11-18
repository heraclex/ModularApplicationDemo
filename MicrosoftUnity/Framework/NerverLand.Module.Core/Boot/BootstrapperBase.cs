// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BootstrapperBase.cs" company="">
//   
// </copyright>
// <summary>
//   The bootstrapper base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NerverLand.Module.Core.Boot
{
    
    using System.Collections.Generic;
    using System.Web.Mvc;

    using NerverLand.Module.Common.Export;
    using NerverLand.Module.Contract.Boot;
    using NerverLand.Module.Contract.Modules;

    /// <summary>
    /// The bootstrapper base.
    /// </summary>
    public abstract class BootstrapperBase : IBootstrapper
    {

        #region Public Methods and Operators

        /// <summary>
        /// The log4net logger instance.
        /// </summary>
        // private static readonly ILog Logger = LogManager.GetLogger(typeof(BootstrapperBase));

        /// <summary>
        /// Gets the current modules in solution..
        /// </summary>
        protected IList<IModule> Modules { get; private set; }

        /// <summary>
        /// Start the bootstrapper.
        /// </summary>
        public virtual void Start()
        {
            // Export common types manually
            this.ExportCommonTypes();

            // Find modules
            this.Modules = this.FindModules();

            // Export all modules entries.
            // Logger.Info("Going to export Module's element");
            foreach (var module in this.Modules)
            {
                foreach (var entry in module.Entries)
                {
                    this.Export(entry);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Export an entry for import later.
        /// </summary>
        /// <param name="entry">
        /// The entry to export.
        /// </param>
        protected abstract void Export(ExportEntry entry);

        /// <summary>
        /// Export all common types.
        /// Export manually
        /// </summary>
        protected virtual void ExportCommonTypes()
        {
        }

        /// <summary>
        /// Find all modules in the application.
        /// </summary>
        /// <returns>
        /// The module list.
        /// </returns>
        protected abstract IList<IModule> FindModules();

        /// <summary>
        ///   Configure Ioc container.
        /// </summary>
        /// <returns> The dependence resolver. </returns>
        protected abstract IDependencyResolver ConfigureIoc();

        #endregion
    }
}
