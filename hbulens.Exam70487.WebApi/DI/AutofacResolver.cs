using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Autofac.Integration.WebApi;

namespace hbulens.Exam70487.WebApi
{
    /// <summary>
    /// Inspired by http://www.asp.net/web-api/overview/advanced/dependency-injection
    /// Note: this class is a mere wrapper around Autofac, so it does absolutely nothing new or different from Autofac.
    /// The article mentioned above shows the same sample but with another DI container (Unity). The end result is exactly the same!
    /// </summary>
    public class AutofacResolver : IDependencyResolver
    {
        #region Constructor

        public AutofacResolver(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.Container = container;
            this.DependencyScope = new AutofacWebApiDependencyScope(container);
        }

        #endregion Constructor

        #region Properties

        protected IContainer Container { get; set; }
        protected AutofacWebApiDependencyScope DependencyScope { get; set; }

        #endregion Properties

        #region Methods

        public object GetService(Type serviceType)
        {
            return this.DependencyScope.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.DependencyScope.GetServices(serviceType);
        }

        public IDependencyScope BeginScope()
        {
            ILifetimeScope lifetimeScope = this.Container.BeginLifetimeScope();
            return new AutofacWebApiDependencyScope(lifetimeScope);
        }

        public void Dispose()
        {
            this.DependencyScope.Dispose();
        }

        #endregion Methods

    }
}
