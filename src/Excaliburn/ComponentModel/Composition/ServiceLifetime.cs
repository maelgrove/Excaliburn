namespace Excaliburn.ComponentModel.Composition
{
    /// <summary>
    ///     Represents the lifetime of a service.
    /// </summary>
    public enum ServiceLifetime
    {
        /// <summary>
        ///     Specifies that a new instance of the service is created for every request.
        /// </summary>
        Transient,

        /// <summary>
        ///     Specifies that a single instance of the service is created for every scope. Services
        ///     will automatically be disposed when the scope ends.
        /// </summary>
        Scoped,

        /// <summary>
        ///     Specifies that a single instance of the service is created. Services will automatically
        ///     be disposed along with their parenting container.
        /// </summary>
        Shared
    }
}
