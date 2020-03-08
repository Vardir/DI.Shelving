namespace Vardirsoft.DI
{
    public sealed class NullObject
    {
        private static readonly NullObject _instance = new NullObject();

        public static NullObject Instance => _instance;
    }
}