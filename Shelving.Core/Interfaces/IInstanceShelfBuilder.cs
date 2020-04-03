namespace Vardirsoft.DI.Interfaces
{
    public interface IInstanceShelfBuilder<T> : IShelfBuilder 
        where T: notnull
    {
        void Initialize();
    }
}