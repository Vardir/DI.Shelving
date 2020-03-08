using System;

namespace Vardirsoft.DI.Interfaces
{
    public interface IDIContainer
    {
        T Resolve<T>();

        object Resolve(Type keyType);
    }
}