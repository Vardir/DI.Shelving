namespace Vardirsoft.DI.Interfaces
{
    public interface IDIContainerBuilder
    {
        IDependenciesOptimizer DependenciesOptimizer { get; set; }
        
        internal void Register(IShelfBuilder shelf);
        
        IShelfBuildingSetup<T> Register<T>();
        
        IDIContainer Build(IDependencyResolver dependencyResolver, IInstanceCreator instanceCreator);
    }
}