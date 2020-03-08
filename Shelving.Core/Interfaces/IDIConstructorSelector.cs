using System;
using System.Collections.Generic;

namespace Vardirsoft.DI.Interfaces
{
    public interface IDIConstructorSelector
    {
        IEnumerable<IConstructorDependency> SelectFor(Type type);
    }
}