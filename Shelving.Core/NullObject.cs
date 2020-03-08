using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI
{
    public sealed class NullObject : INullObject
    {
        private static readonly NullObject _instance = new NullObject();

        public static NullObject Instance => _instance;
    }
}