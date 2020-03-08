namespace Vardirsoft.DI.Interfaces
{
    public interface IResolvedDependency
    {
        object Instance { get; }
        
        IDependency Dependency { get; }
    }
}