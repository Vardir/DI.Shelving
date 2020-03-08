using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Vardirsoft.DI.Dependencies;
using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Selectors
{
    public class DefaultConstructorSelector : IDIConstructorSelector
    {
        public IEnumerable<IConstructorDependency> SelectFor(Type type)
        {
            foreach (var constructorInfo in type.GetConstructors().Where(IsAccessible))
            {
                yield return new DefaultConstructorDependency(constructorInfo.GetParameters().Select(x => new ParameterDependency(x.ParameterType)));
            }
        }
        
        private static bool IsAccessible(ConstructorInfo constructorInfo)
        {
            if (constructorInfo.IsStatic || constructorInfo.ContainsGenericParameters)
                return false;
            
            return constructorInfo.IsPublic;
        }
    }
}