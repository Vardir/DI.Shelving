using System;

namespace Vardirsoft.DI.Interfaces
{
    public interface IPropertyDependency : IDependency
    {
        string PropertyName { get; }
        
        Type PropertyType { get; }
    }
}