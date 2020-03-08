using System;
using System.Collections.Generic;

namespace Vardirsoft.DI.Interfaces
{
    public interface IDIPropertiesSelector
    {
        IEnumerable<IPropertyDependency> SelectFor(Type type);
    }
}