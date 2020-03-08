using System;

using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Dependencies
{
    public class DefaultPropertyDependency : IPropertyDependency
    {
        public string PropertyName { get; }

        public Type PropertyType { get; }
        
        public DefaultPropertyDependency(string propertyName, Type propertyType)
        {
            PropertyName = propertyName;
            PropertyType = propertyType;
        }
    }
}