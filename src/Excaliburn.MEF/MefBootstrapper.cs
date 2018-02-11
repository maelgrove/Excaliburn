#region

using System;
using Excaliburn.Composition;

#endregion

namespace Excaliburn.MEF
{
    /// <summary>
    ///     Represents the bootstrapper and main composition root of the application, supporting MEF.
    /// </summary>
    public class MefBootstrapper : Bootstrapper
    {
        protected override IServiceContainer ConfigureServices(IServiceCollection components)
        {
            throw new NotImplementedException();
        }
    }
}
