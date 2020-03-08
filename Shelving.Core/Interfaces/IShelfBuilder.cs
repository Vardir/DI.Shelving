using System;

namespace Vardirsoft.DI.Interfaces
{
    public interface IShelfBuilder
    {
        Type RegistrationType { get; }

        internal IShelf Build();
    }
}