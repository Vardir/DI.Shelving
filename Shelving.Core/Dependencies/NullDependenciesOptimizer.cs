using System;
using System.Collections.Generic;

using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Dependencies
{
    public sealed class NullDependenciesOptimizer : IDependenciesOptimizer
    {
        public IDictionary<Type, IShelf> Optimize(IDictionary<Type, IShelf> shelvesMap) => shelvesMap;
    }
}