using System;
using System.Collections.Generic;
using System.Linq;

using Vardirsoft.DI.Interfaces;
using Vardirsoft.DI.Selectors;

namespace Vardirsoft.DI.Builders
{
    public sealed class ShelvingBuilder : BaseShelvingBuilder
    {
        public ShelvingBuilder() : this(new DefaultConstructorSelector(), new DefaultPropertySelector())
        {
            
        }

        public ShelvingBuilder(IDIConstructorSelector constructorSelector, IDIPropertiesSelector propertiesSelector)
            : base(constructorSelector, propertiesSelector)
        {
            
        }
        
        public override IShelfBuildingSetup<TInstance> Register<TInstance>()
        {
            return new ShelfBuildingSetup<TInstance>(this, _constructorSelector, _propertiesSelector);
        }

        public override IDIContainer Build(IDependencyResolver dependencyResolver, IInstanceCreator instanceCreator)
        {
            var shelves = BuildShelves();
            
            return new Shelving(instanceCreator, dependencyResolver, shelves);
        }

        private IDictionary<Type, IShelf> BuildShelves()
        {
            IDictionary<Type, IShelf> map = _shelfBuilders.ToDictionary(x => x.RegistrationType, x => x.Build());
            
            return DependenciesOptimizer.Optimize(map);
        }
    }
}