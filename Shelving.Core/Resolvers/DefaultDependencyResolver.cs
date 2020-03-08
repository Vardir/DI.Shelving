using System;
using System.Collections.Generic;
using System.Linq;

using Vardirsoft.DI.Dependencies;
using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Resolvers
{
    public class DefaultDependencyResolver : IDependencyResolver
    {
        public IEnumerable<IResolvedDependency> Resolve(IDIContainer diContainer, IEnumerable<IDependency> dependencies)
        {
            var list = dependencies.ToArray();

            var constructor = ResolveConstructor(diContainer, list.OfType<IConstructorDependency>());

            if (constructor.IsNot<NullResolvedDependency>())
                yield return constructor;
            
            foreach (var property in ResolveProperties(diContainer, list.OfType<IPropertyDependency>()))
            {
                if (property.IsNot<NullResolvedDependency>())
                    yield return property;
            }
        }

        private static IResolvedDependency ResolveConstructor(IDIContainer diContainer, IEnumerable<IConstructorDependency> constructorDependencies)
        {
            foreach (var constructorDependency in constructorDependencies.OrderBy(x => x.ParameterDependencies.Count))
            {
                var parameters = ResolveConstructorParameters(diContainer, constructorDependency.ParameterDependencies).ToArray();

                if (parameters.All(x => x != NullObject.Instance))
                    return new ResolvedDependency(parameters, constructorDependency);
            }
            
            return new NullResolvedDependency();
        }
        
        private static IEnumerable<IResolvedDependency> ResolveProperties(IDIContainer diContainer, IEnumerable<IPropertyDependency> propertyDependencies)
        {
            foreach (var propertyDependency in propertyDependencies)
            {
                if (TryResolveInstance(propertyDependency.PropertyType, diContainer, out var instance))
                {
                    yield return new ResolvedDependency(instance, propertyDependency);
                }
            }
        }

        private static IEnumerable<object> ResolveConstructorParameters(IDIContainer diContainer, IEnumerable<IParameterDependency> parameterDependencies)
        {
            foreach (var parameterDependency in parameterDependencies)
            {
                TryResolveInstance(parameterDependency.ParameterType, diContainer, out var instance);

                yield return instance;
            }
        }
        
        private static bool TryResolveInstance(Type type, IDIContainer diContainer, out object instance)
        {
            instance = NullObject.Instance;

            try
            {
                instance = diContainer.Resolve(type);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}