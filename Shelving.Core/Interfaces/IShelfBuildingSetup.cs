namespace Vardirsoft.DI.Interfaces
{
    public interface IShelfBuildingSetup<TInstance>
    {
        ITypeInfoShelfBuilder<TKey, TInstance> As<TKey>();

        ITypeInfoShelfBuilder<TInstance, TInstance> This();

        IInstanceShelfBuilder<TInstance> With(TInstance instance);
    }
}