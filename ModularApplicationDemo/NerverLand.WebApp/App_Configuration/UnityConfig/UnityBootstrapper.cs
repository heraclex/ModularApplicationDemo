namespace NerverLand.WebApp.App_Configuration.UnityConfig
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.Linq;
    using System.IO;
    using System.Web.Mvc;

    using Microsoft.Practices.Unity;

    using NerverLand.Framework.Common.Export;
    using NerverLand.Framework.Contract.Modules;
    using NerverLand.Framework.Core.Boot;

    /// <summary>
    /// The unity bootstrapper.
    /// </summary>
    public class UnityBootstrapper : BootstrapperBase
    {
        /// <summary>
        /// The container.
        /// </summary>
        private IUnityContainer container;

        /// <summary>
        /// The start.
        /// </summary>
        public override void Start()
        {
            var dependencyResolver = this.ConfigureIoc();
            base.Start();
        }

        /// <summary>
        /// The export.
        /// </summary>
        /// <param name="entry">
        /// The entry.
        /// </param>
        protected override void Export(ExportEntry entry)
        {
            if (entry.IsSingleton)
            {
                this.container.RegisterType(
                    entry.InfType, entry.ImplType, entry.Name, new ContainerControlledLifetimeManager());
            }
            else
            {
                this.container.RegisterType(
                    entry.InfType, entry.ImplType, entry.Name);
            }
        }

        /// <summary>
        /// The find modules.
        /// </summary>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        protected override IList<IModule> FindModules()
        {
            var domain = AppDomain.CurrentDomain;
            var path = Path.Combine(domain.BaseDirectory, "_Modules");
            // Logger.InfoFormat("Lookup Modules for following path : {0}", path);
            var catalog = new AggregateCatalog(new DirectoryCatalog(path));
            var compositionContainer = new CompositionContainer(catalog);

            var ret = new List<IModule>(100);
            try
            {
                var foundModules = compositionContainer.GetExports<IModule>().Select(module => module.Value);
                ret.AddRange(foundModules);
            }
            catch (Exception ex)
            {
                throw;
            }

            return ret;
        }

        /// <summary>
        /// The configure ioc.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependencyResolver"/>.
        /// </returns>
        protected override IDependencyResolver ConfigureIoc()
        {
            this.container = new UnityContainer();
            var dependencyResolver = new UnityServiceLocator(this.container);
            DependencyResolver.SetResolver(dependencyResolver);
            return DependencyResolver.Current;
        }
    }
}