using System;
using System.Collections.Generic;

namespace Vardirsoft.DI.Interfaces
{
    public interface IShelf
    {
        InstanceCreationMode CreationMode { get; }
        
        object ContainedInstance { get; }

        Type RegistrationType { get; }
        
        Type InstanceType { get; }
        
        IReadOnlyCollection<IDependency> Dependencies { get; }
    }
}