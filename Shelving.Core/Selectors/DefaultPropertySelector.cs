using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Vardirsoft.DI.Dependencies;
using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Selectors
{
    public class DefaultPropertySelector : IDIPropertiesSelector
    {
        public IEnumerable<IPropertyDependency> SelectFor(Type type)
        {
            foreach (var propertyInfo in type.GetProperties().Where(IsAccessible))
            {
                yield return new DefaultPropertyDependency(propertyInfo.Name, propertyInfo.PropertyType);
            }
        }

        private static bool IsAccessible(PropertyInfo propertyInfo)
        {
            return propertyInfo.CanRead && propertyInfo.CanWrite &&
                   propertyInfo.GetAccessors().All(x => x.IsPublic && !x.IsStatic);
        }
    }
}