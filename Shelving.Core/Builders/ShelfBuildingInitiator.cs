using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Builders
{
    public class ShelfBuildingSetup<TInstance> : IShelfBuildingSetup<TInstance> 
        where TInstance: notnull
    {
        private readonly IDIConstructorSelector _constructorSelector;
        private readonly IDIPropertiesSelector _propertiesSelector;
        
        internal IDIContainerBuilder ContainerBuilder { get; }
        
        public ShelfBuildingSetup(IDIContainerBuilder containerBuilder, IDIConstructorSelector constructorSelector, IDIPropertiesSelector propertiesSelector)
        {
            ContainerBuilder = containerBuilder;
            _constructorSelector = constructorSelector;
            _propertiesSelector = propertiesSelector;
        }
        
        public ITypeInfoShelfBuilder<TKey, TInstance> As<TKey>()
        {
            return new TypeInfoShelfBuilder<TKey, TInstance>(ContainerBuilder, _constructorSelector, _propertiesSelector);
        }

        public ITypeInfoShelfBuilder<TInstance, TInstance> This()
        {
            return new TypeInfoShelfBuilder<TInstance, TInstance>(ContainerBuilder, _constructorSelector, _propertiesSelector);
        }

        public IInstanceShelfBuilder<TInstance> With(TInstance instance)
        {
            return new InstanceShelfBuilder<TInstance>(instance, ContainerBuilder);
        }
    }
}