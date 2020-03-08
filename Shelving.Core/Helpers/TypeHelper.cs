namespace Vardirsoft.DI
{
    public static class TypeHelper
    {
        public static bool IsNot<TKey>(this object instance) => !(instance is TKey);
    }
}