#region

using System.Collections.Generic;

#endregion

namespace Excaliburn.Composition
{
    // TODO allow to replace previously registered registrations

    /// <summary>
    ///     Represents a mutable collection of <see cref="ServiceRegistration" />s.
    /// </summary>
    public interface IServiceCollection : IList<ServiceRegistration>
    {
    }
}
