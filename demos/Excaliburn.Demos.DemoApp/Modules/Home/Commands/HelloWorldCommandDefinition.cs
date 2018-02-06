#region

using System;
using Excaliburn.ComponentModel.Commands;

#endregion

namespace Excaliburn.Demos.DemoApp.Modules.Home.Commands
{
    /// <summary>
    ///     Represents a simple 'Hello World' command. The command definition <see cref="HelloWorldCommandDefinition" />
    ///     is the unique identifier of the command, and links it with the <see cref="HelloWorldCommandHandler" />.
    /// </summary>
    public class HelloWorldCommandDefinition : CommandDefinition<HelloWorldCommandHandler>
    {
        /// <summary>
        ///     Returns the default display text associated with the command.
        /// </summary>
        public override string Text { get; } = "Hello World!";

        /// <summary>
        ///     Returns the default tooltip associated with the command.
        /// </summary>
        public override string ToolTip { get; } = "Executes the 'Hello World' command.";

        // TODO hello world -> example icon
        /// <summary>
        ///     Returns the <see cref="Uri" /> of the default icon associated with the command.
        /// </summary>
        public override Uri IconSource { get; } = null;
    }
}
