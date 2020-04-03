namespace Vardirsoft.DI.Interfaces
{
    public interface IShelfBuildingSetup<TInstance> where TInstance: notnull
    {
        ITypeInfoShelfBuilder<TKey, TInstance> As<TKey>();

        ITypeInfoShelfBuilder<TInstance, TInstance> This();

        IInstanceShelfBuilder<TInstance> With(TInstance instance);
    }
}