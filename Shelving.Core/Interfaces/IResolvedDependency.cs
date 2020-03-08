namespace Vardirsoft.DI.Interfaces
{
    public interface IResolvedDependency
    {
        object Instance { get; }
        
        IDependency Dependency { get; }
    }

    public class NullResolvedDependency : IResolvedDependency, INullObject
    {
        public object Instance => NullObject.Instance;
        
        public IDependency Dependency => new NullDependency();
    }
}