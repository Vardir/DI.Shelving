using System;
using System.Linq;

using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Builders
{
    public class TypeInfoShelfBuilder<TKey, TInstance> : ITypeInfoShelfBuilder<TKey, TInstance>
    {
        private readonly IDIConstructorSelector _constructorSelector;
        private readonly IDIPropertiesSelector _propertiesSelector;

        private InstanceCreationMode _instanceCreationMode; 
        
        internal IDIContainerBuilder ContainerBuilder { get; set; }
        
        public Type RegistrationType { get; } = typeof(TKey);

        public Type InstanceType { get; } = typeof(TInstance);

        public TypeInfoShelfBuilder(IDIConstructorSelector constructorSelector, IDIPropertiesSelector propertiesSelector)
        {
            _constructorSelector = constructorSelector;
            _propertiesSelector = propertiesSelector;
        }

        public void AsSingleton()
        {
            _instanceCreationMode = InstanceCreationMode.CreateOnce;
            ContainerBuilder.Register(this);
        }

        public void CreatePerUsage()
        {
            _instanceCreationMode = InstanceCreationMode.Transient;
            ContainerBuilder.Register(this);
        }
        
        public void ForSingleUsage()
        {
            _instanceCreationMode = InstanceCreationMode.Singleton;
            ContainerBuilder.Register(this);
        }
        
        IShelf IShelfBuilder.Build()
        {
            var constructorDependencies = _constructorSelector.SelectFor(InstanceType).Cast<IDependency>();
            var propertyDependencies = _propertiesSelector.SelectFor(InstanceType).Cast<IDependency>();
            var typeDependencies = constructorDependencies.Concat(propertyDependencies);
            
            return new TypeInfoShelf(InstanceType, RegistrationType, _instanceCreationMode, typeDependencies);
        }
    }
}