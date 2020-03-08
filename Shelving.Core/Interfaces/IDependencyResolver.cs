using System.Collections.Generic;

namespace Vardirsoft.DI.Interfaces
{
    public interface IDependencyResolver
    {
        IEnumerable<IResolvedDependency> Resolve(IDIContainer diContainer, IEnumerable<IDependency> dependencies);
    }
}