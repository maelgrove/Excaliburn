namespace Excaliburn.ComponentModel.Commands
{
    /// <summary>
    ///     Represents a service for creating <see cref="CommandBinding"/>s.
    /// </summary>
    internal class CommandBindingFactory
    {

        /// <summary>
        ///     Creates a new <see cref="Comand"/>
        /// </summary>
        /// <param name="commandHandlerResolver"></param>
        /// <param name="commandStateCache"></param>
        public CommandBindingFactory(
            ICommandHandlerResolver commandHandlerResolver,
            ICommandStateCache commandStateCache)
        {
            
        }

    }
}
