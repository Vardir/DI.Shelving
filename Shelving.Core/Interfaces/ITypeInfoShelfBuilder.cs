namespace Vardirsoft.DI.Interfaces
{
    public interface ITypeInfoShelfBuilder<TKey, TInstance> : IShelfBuilder
    {
        void AsSingleton();
        void CreatePerUsage();
        void ForSingleUsage();
    }
}