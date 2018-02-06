#region

using System.Collections.Generic;

#endregion

namespace Excaliburn.ComponentModel.Composition
{
    /// <summary>
    ///     Represents a mutable collection of <see cref="ServiceRegistration" />s.
    /// </summary>
    public interface IServiceCollection : IList<ServiceRegistration>
    {
    }
}
