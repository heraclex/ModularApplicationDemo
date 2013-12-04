
namespace NerverLand.WebApp.App_Configuration.AutofacConfig
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Composition.Hosting;
    using System.IO;
    using System.Linq;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Builder;
    //using Autofac.Integration.Mvc;

    using NerverLand.Framework.Common.Export;
    using NerverLand.Framework.Contract.Modules;
    using NerverLand.Framework.Core.Boot;

    public class AutofacBootstrapper : BootstrapperBase
    {
        //http://stackoverflow.com/questions/2355139/what-is-the-lifetime-of-a-asp-net-mvc-controller
        //http://stephenwalther.com/archive/2008/03/18/asp-net-mvc-in-depth-the-life-of-an-asp-net-mvc-request

        #region Static Fields

        /// <summary>
        ///     The log4net logger instance.
        /// </summary>
        // private static readonly ILog Logger = LogManager.GetLogger(typeof(AutofacBootstrapper));

        /// <summary>
        /// Interface Controller type.
        /// </summary>
        private static readonly Type IControllerType = typeof(IController);

        #endregion

        #region Fields

        /// <summary>
        ///     AUTOFAC builder.
        /// </summary>
        private readonly ContainerBuilder builder = new ContainerBuilder();

        /// <summary>
        ///     The <see cref="IComponentContext" /> from which services
        ///     should be located.
        /// </summary>
        private IComponentContext container;

        #endregion

        /// <summary>
        /// The start.
        /// </summary>
        public override void Start()
        {
            base.Start();
            this.ConfigureIoc();
        }

        protected override void Export(ExportEntry entry)
        {
            IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> regBuilder =
                this.builder.RegisterType(entry.ImplType);

            if (string.IsNullOrEmpty(entry.Name))
            {
                regBuilder.As(entry.InfType);
            }
            else
            {
                regBuilder.Named(entry.Name, entry.InfType);
            }

            if (entry.IsSingleton)
            {
                regBuilder.SingleInstance();
            }
        }

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

        protected override void ConfigureIoc()
        {
            this.RegisterControllerFactory();
            this.container = this.builder.Build();
            DependencyResolver.SetResolver(new NerverLand.WebApp.App_Configuration.AutofacConfig.AutofacDependenceResolver(this.container, DependencyResolver.Current));
        }

        private void RegisterControllerFactory()
        {
            Type[] types = this.GetType().Assembly.GetTypes();
            foreach (Type type in types)
            {
                // Register Controllers
                if ((!type.IsAbstract) && IControllerType.IsAssignableFrom(type))
                {
                    // this.logger.InfoFormat("--- Register {0}", type.Name);

                    this.builder.RegisterType(type).As<IController>()
                        .Named(type.Name.Replace("Controller", string.Empty).ToLowerInvariant(), typeof(IController));
                }
            }
            
            this.builder.RegisterType(typeof(AutofacControllerFactory)).As<IControllerFactory>().SingleInstance();
        }
    }
}