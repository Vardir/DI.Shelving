using System.Collections.Generic;

namespace Vardirsoft.DI.Interfaces
{
    public interface IConstructorDependency : IDependency
    {
        IReadOnlyCollection<IParameterDependency> ParameterDependencies { get; }
    }
}