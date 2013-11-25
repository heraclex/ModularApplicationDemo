using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NerverLand.WebApp.App_Configuration.AutofacConfig
{

    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;
    using System.Web.Mvc;
    using System.Web.Routing;
    using System.Web.SessionState;

    using Autofac;
    using Autofac.Core;

    /// <summary>
    ///     MVC controller factory based on AUTOFAC.
    /// </summary>
    public class AutofacControllerFactory : IControllerFactory
    {
        #region Static Fields

        /// <summary>
        ///     Logger for logging.
        /// </summary>
        // private static readonly ILog Log = LogManager.GetLogger(typeof(AutofacControllerFactory));

        /// <summary>
        ///     The session state cache.
        /// </summary>
        private static readonly ConcurrentDictionary<Type, SessionStateBehavior> SessionStateCache =
            new ConcurrentDictionary<Type, SessionStateBehavior>();

        #endregion

        #region Fields

        /// <summary>
        ///     The <see cref="IComponentContext" /> from which services
        ///     should be located.
        /// </summary>
        private readonly IComponentContext container;

        /// <summary>
        ///     Default factory for not registered controller.
        /// </summary>
        private readonly IControllerFactory defaultFactory;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacControllerFactory"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public AutofacControllerFactory(IComponentContext container)
        {
            this.container = container;
            this.defaultFactory = new DefaultControllerFactory();
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Creates the specified controller by using the specified request context.
        /// </summary>
        /// <param name="requestContext">
        /// The request context.
        /// </param>
        /// <param name="controllerName">
        /// The name of the controller.
        /// </param>
        /// <returns>
        /// The controller object.
        /// </returns>
        [DebuggerStepThrough]
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            if (this.container.IsRegisteredWithName<IController>(controllerName.ToLowerInvariant()))
            {
                using (var lifetimeScope = ((ILifetimeScope)this.container).BeginLifetimeScope())
                {
                    return lifetimeScope.ResolveNamed<IController>(controllerName.ToLowerInvariant());
                }
            }

            // Log.ErrorFormat("Unable to find controller with name {0}", controllerName);
            return null;
        }

        /// <summary>
        /// The get controller session behavior.
        /// </summary>
        /// <param name="requestContext">
        /// The request context.
        /// </param>
        /// <param name="controllerName">
        /// The controller name.
        /// </param>
        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            if (requestContext == null)
            {
                throw new ArgumentNullException("requestContext");
            }

            if (string.IsNullOrEmpty(controllerName))
            {
                throw new ArgumentNullException("controllerName");
            }

            // Check controller name exist in cache or not
            var keyedService = new KeyedService(controllerName.ToLowerInvariant(), typeof(IController));
            IComponentRegistration registry;
            this.container.ComponentRegistry.TryGetRegistration(keyedService, out registry);
            if (registry != null)
            {
                return this.GetControllerSessionBehavior(requestContext, registry.Activator.LimitType);
            }

            return this.defaultFactory.GetControllerSessionBehavior(requestContext, controllerName);
        }

        /// <summary>
        /// The release controller.
        /// </summary>
        /// <param name="controller">
        /// The controller.
        /// </param>
        public void ReleaseController(IController controller)
        {
            // Do nothing.
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns the controller's session behavior.
        /// </summary>
        /// <returns>
        /// The controller's session behavior.
        /// </returns>
        /// <param name="requestContext">
        /// The request context.
        /// </param>
        /// <param name="controllerType">
        /// The type of the controller.
        /// </param>
        protected internal virtual SessionStateBehavior GetControllerSessionBehavior(
            RequestContext requestContext, Type controllerType)
        {
            return SessionStateCache.GetOrAdd(
                controllerType,
                type =>
                {
                    foreach (var attr in controllerType.GetCustomAttributes(typeof(SessionStateAttribute), true))
                    {
                        return ((SessionStateAttribute)attr).Behavior;
                    }

                    return SessionStateBehavior.ReadOnly;
                });
        }

        #endregion
    }
}