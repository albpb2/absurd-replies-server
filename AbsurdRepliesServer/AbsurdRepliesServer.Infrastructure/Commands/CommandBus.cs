using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbsurdRepliesServer.Infrastructure.Commands
{
    public class CommandBus
    {
        private List<ICommandHandler> _commandHandlers;
        private Dictionary<Type, ICommandHandler> _commandHandlersByCommandType;

        public CommandBus(IEnumerable<ICommandHandler> commandHandlers)
        {
            _commandHandlers = commandHandlers.ToList();
            _commandHandlersByCommandType = new Dictionary<Type, ICommandHandler>();
        }

        public Task HandleCommand<TCommand>(TCommand command) where TCommand : ICommand =>
            GetCommandHandler(command).HandleCommand(command);

        private CommandHandlerBase<TCommand> GetCommandHandler<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (_commandHandlersByCommandType.TryGetValue(command.GetType(), out var commandHandler))
                return commandHandler as CommandHandlerBase<TCommand>;

            commandHandler = _commandHandlers.OfType<CommandHandlerBase<TCommand>>().FirstOrDefault();
            _commandHandlersByCommandType[command.GetType()] = 
                commandHandler ?? throw new InvalidOperationException($"Could not find command handler for type {command.GetType().Name}");
            _commandHandlers.Remove(commandHandler);
            
            return (CommandHandlerBase<TCommand>) commandHandler;
        }
    }
}