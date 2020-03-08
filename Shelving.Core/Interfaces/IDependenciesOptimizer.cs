using System;
using System.Collections.Generic;

namespace Vardirsoft.DI.Interfaces
{
    public interface IDependenciesOptimizer
    {
        IDictionary<Type, IShelf> Optimize(IDictionary<Type, IShelf> shelvesMap);
    }
}