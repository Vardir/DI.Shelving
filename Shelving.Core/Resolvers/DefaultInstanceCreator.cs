using System;
using System.Collections.Generic;
using System.Linq;

using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Resolvers
{
    public class DefaultInstanceCreator : IInstanceCreator
    {
        public object Create(Type type, IReadOnlyCollection<IResolvedDependency> resolvedDependencies)
        {
            object instance;
            var constructorDependency = resolvedDependencies.FirstOrDefault(x => x.Dependency is IConstructorDependency);

            if (constructorDependency is null)
            {
                instance = Activator.CreateInstance(type);
            }
            else
            {
                instance = Activator.CreateInstance(type, constructorDependency.Instance as object[]);
            }

            foreach (var resolvedDependency in resolvedDependencies.Where(x => x.Dependency is IPropertyDependency))
            {
                var propertyDependency = (IPropertyDependency)resolvedDependency.Dependency;
                var property = type.GetProperty(propertyDependency.PropertyName);
                
                property?.SetValue(instance, resolvedDependency.Instance);
            }
            
            return instance;
        }
    }
}