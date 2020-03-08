using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Dependencies
{
    public class ResolvedDependency : IResolvedDependency
    {
        public object Instance { get; }
        
        public IDependency Dependency { get; }

        public ResolvedDependency(object instance, IDependency dependency)
        {
            Instance = instance;
            Dependency = dependency;
        }
    }
}