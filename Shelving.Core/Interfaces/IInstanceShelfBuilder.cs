namespace Vardirsoft.DI.Interfaces
{
    public interface IInstanceShelfBuilder<T> : IShelfBuilder
    {
        void Initialize();
    }
}