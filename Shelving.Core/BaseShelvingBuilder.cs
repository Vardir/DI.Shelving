using System.Collections.Generic;

using Vardirsoft.DI.Dependencies;
using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI
{
    public abstract class BaseShelvingBuilder : IDIContainerBuilder
    {
        protected readonly List<IShelfBuilder> _shelfBuilders;
        protected readonly IDIPropertiesSelector _propertiesSelector;
        protected readonly IDIConstructorSelector _constructorSelector;

        public IDependenciesOptimizer DependenciesOptimizer { get; set; }

        protected BaseShelvingBuilder(IDIConstructorSelector constructorSelector, IDIPropertiesSelector propertiesSelector)
        {
            _propertiesSelector = propertiesSelector;
            _constructorSelector = constructorSelector;
            
            _shelfBuilders = new List<IShelfBuilder>();
            DependenciesOptimizer = new NullDependenciesOptimizer();
        }

        void IDIContainerBuilder.Register(IShelfBuilder shelfBuilder)
        {
            _shelfBuilders.Add(shelfBuilder);
        }
        
        public abstract IShelfBuildingSetup<T> Register<T>() where T: notnull;

        public abstract IDIContainer Build(IDependencyResolver dependencyResolver, IInstanceCreator instanceCreator);
    }
}