using Autofac;
using Core.Contracts;
using System;

namespace Core.Application
{
    internal class Context : IContextBuilder, IContext, IDisposable
    {
        private readonly ContainerBuilder _containerBuilder = new ContainerBuilder();
        private IContainer _container;
        private ILifetimeScope _applicationScope;

        public IContextBuilder Bind<TInterface, TImplementation>(bool isSingleton = false)
            where TInterface : class
            where TImplementation : TInterface
        {
            if (isSingleton)
                _containerBuilder.RegisterType<TImplementation>().As<TInterface>();
            else
                _containerBuilder.RegisterType<TImplementation>().As<TInterface>().InstancePerDependency();
            return this;
        }

        internal void BuildContainer()
        {
            _container = _containerBuilder.Build();
            _applicationScope = _container.BeginLifetimeScope();
        }

        public T Get<T>() where T : class => _applicationScope.Resolve<T>();

        public void Dispose() => _applicationScope.Dispose();
    }
}
