using System;

using Vardirsoft.DI.Interfaces;
using Vardirsoft.DI.Shelves;

namespace Vardirsoft.DI.Builders
{
    public class InstanceShelfBuilder<T> : IInstanceShelfBuilder<T>
    {
        private readonly T _instance;
        
        internal IDIContainerBuilder ContainerBuilder { get; set; }

        public Type RegistrationType { get; } = typeof(T);

        public InstanceShelfBuilder(T instance)
        {
            _instance = instance;
        }

        public void Initialize()
        {
            ContainerBuilder.Register(this);
        }

        IShelf IShelfBuilder.Build() => new InstanceShelf(_instance, RegistrationType);
    }
}