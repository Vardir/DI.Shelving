using System;
using System.Collections.Generic;
using System.Linq;

using Vardirsoft.DI.Interfaces;
using Vardirsoft.DI.Shelves;

namespace Vardirsoft.DI
{
    public class Shelving : IDIContainer
    {
        private readonly IInstanceCreator _instanceCreator;
        private readonly IDependencyResolver _dependencyResolver;
        private readonly IDictionary<Type, IShelf> _shelves;

        internal Shelving(IInstanceCreator instanceCreator, IDependencyResolver dependencyResolver, IDictionary<Type, IShelf> shelves)
        {
            _instanceCreator = instanceCreator;
            _dependencyResolver = dependencyResolver;
            _shelves = new Dictionary<Type, IShelf>(shelves);
        }

        public T Resolve<T>() => (T)Resolve(typeof(T));
        
        public object Resolve(Type keyType)
        {
            var shelf = _shelves[keyType];
            
            if (shelf.ContainedInstance is NullObject)
            {
                var resolvedDependencies = _dependencyResolver.Resolve(this, shelf.Dependencies).ToArray();
                var instance = _instanceCreator.Create(shelf.InstanceType, resolvedDependencies);
                
                if (shelf.CreationMode == InstanceCreationMode.CreateOnce)
                {
                    var instanceShelf = new InstanceShelf(instance, keyType);

                    _shelves[keyType] = instanceShelf;
                }
                else if (shelf.CreationMode == InstanceCreationMode.Singleton)
                {
                    _shelves.Remove(keyType);
                }

                return instance;
            }

            return shelf.ContainedInstance;
        }
    }
}