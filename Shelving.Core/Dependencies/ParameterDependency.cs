using System;

using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Dependencies
{
    public class ParameterDependency : IParameterDependency
    {
        public Type ParameterType { get; }

        public ParameterDependency(Type parameterType)
        {
            ParameterType = parameterType;
        }
    }
}