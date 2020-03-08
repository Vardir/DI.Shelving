using System;
using System.Collections.Generic;
using System.Linq;

using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI
{
    public class TypeInfoShelf : IShelf
    {
        public InstanceCreationMode CreationMode { get; }
        
        public object ContainedInstance => NullObject.Instance;

        public Type RegistrationType { get; }

        public Type InstanceType { get; }
        
        public IReadOnlyCollection<IDependency> Dependencies { get; }

        public TypeInfoShelf(Type instanceType, Type registrationType, InstanceCreationMode creationMode, IEnumerable<IDependency> dependencies)
        {
            InstanceType = instanceType;
            RegistrationType = registrationType;
            CreationMode = creationMode;
            Dependencies = dependencies.ToArray();
        }
    }
}