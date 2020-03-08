namespace Vardirsoft.DI
{
    public class NullObject
    {
        private static readonly NullObject _instance = new NullObject();

        public static NullObject Instance => _instance;
    }
}