using Vardirsoft.DI.Builders;
using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Builders
{
    public class ShelfBuildingSetup<TInstance> : IShelfBuildingSetup<TInstance>
    {
        private readonly IDIConstructorSelector _constructorSelector;
        private readonly IDIPropertiesSelector _propertiesSelector;
        
        internal IDIContainerBuilder ContainerBuilder { get; set; }
        
        public ShelfBuildingSetup(IDIConstructorSelector constructorSelector, IDIPropertiesSelector propertiesSelector)
        {
            _constructorSelector = constructorSelector;
            _propertiesSelector = propertiesSelector;
        }
        
        public ITypeInfoShelfBuilder<TKey, TInstance> As<TKey>()
        {
            return new TypeInfoShelfBuilder<TKey, TInstance>(_constructorSelector, _propertiesSelector)
            {
                ContainerBuilder = ContainerBuilder
            };
        }

        public ITypeInfoShelfBuilder<TInstance, TInstance> This()
        {
            return new TypeInfoShelfBuilder<TInstance, TInstance>(_constructorSelector, _propertiesSelector)
            {
                ContainerBuilder = ContainerBuilder
            };
        }

        public IInstanceShelfBuilder<TInstance> With(TInstance instance)
        {
            var builder = new InstanceShelfBuilder<TInstance>(instance)
            {
                ContainerBuilder = ContainerBuilder
            };
            
            return builder;
        }
    }
}