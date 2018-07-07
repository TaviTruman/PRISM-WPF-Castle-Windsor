using System;
using System.Collections.Generic;
using Castle.Windsor;
using IKW.Contropolus.ServiceLocator.CastleWindsorAdapter.Extensions;
using Microsoft.Practices.ServiceLocation;

namespace IKW.Contropolus.ServiceLocator.CastleWindsorAdapter.Adapters
{
    public class CastleWindsorServiceLocatorAdapter : ServiceLocatorImplBase
    {
        private readonly IWindsorContainer _windsorContainer;

        public CastleWindsorServiceLocatorAdapter(IWindsorContainer theWindsorContainer)
        {
            _windsorContainer = theWindsorContainer;
        }

        public IWindsorContainer WindsorContainer => _windsorContainer;
        protected override object DoGetInstance(Type serviceType, string key)
        {
            return CastleWindsorContainerExtensions.Resolve(WindsorContainer, serviceType);

            //if (key == null)
            //    return WindsorContainer.Resolve(serviceType);
            //return WindsorContainer.Resolve(key, serviceType);
        }

        protected override IEnumerable<object> DoGetAllInstances(Type serviceType) => (IEnumerable<object>) WindsorContainer.ResolveAll(serviceType);
    }
}

