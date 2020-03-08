using System;
using System.Collections.Generic;

using Vardirsoft.DI.Interfaces;

namespace Vardirsoft.DI.Shelves
{
    public class InstanceShelf : IShelf
    {
        public InstanceCreationMode CreationMode => InstanceCreationMode.None;
        
        public object ContainedInstance { get; }

        public Type RegistrationType { get; }

        public Type InstanceType { get; }
        
        public IReadOnlyCollection<IDependency> Dependencies => throw new NotSupportedException();

        public InstanceShelf(object instance, Type registrationType)
        {
            ContainedInstance = instance;
            
            InstanceType = instance.GetType();
            RegistrationType = registrationType;
        }
    }
}