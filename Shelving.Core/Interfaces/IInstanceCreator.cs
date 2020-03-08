using System;
using System.Collections.Generic;

namespace Vardirsoft.DI.Interfaces
{
    public interface IInstanceCreator
    {
        object Create(Type type, IReadOnlyCollection<IResolvedDependency> resolvedDependencies);
    }
}