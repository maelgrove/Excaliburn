namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents a service which creates and persists <see cref="CommandState"/>s for making
    ///     them accessible from various UI components.
    /// </summary>
    public interface ICommandStateCache
    {
        /// <summary>
        ///     Retrieves an existing <see cref="CommandState"/> for the specified <see cref="CommandDefinition"/>
        ///     or creates a new one.
        /// </summary>
        /// <param name="commandDefinition">The <see cref="CommandDefinition"/>.</param>
        /// <returns>The associated <see cref="CommandState"/>.</returns>
        CommandState GetOrCreateCommandState(CommandDefinition commandDefinition);
    }
}
