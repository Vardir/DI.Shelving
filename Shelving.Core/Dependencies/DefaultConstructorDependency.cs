using System.Collections.Generic;
using System.Linq;

using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Dependencies
{
    public class DefaultConstructorDependency : IConstructorDependency
    {
        public IReadOnlyCollection<IParameterDependency> ParameterDependencies { get; }

        public DefaultConstructorDependency(IEnumerable<IParameterDependency> parameterDependencies)
        {
            ParameterDependencies = parameterDependencies.ToArray();
        }
    }
}