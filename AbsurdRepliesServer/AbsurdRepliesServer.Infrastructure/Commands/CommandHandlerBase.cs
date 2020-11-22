using System.Threading.Tasks;

namespace AbsurdRepliesServer.Infrastructure.Commands
{
    public abstract class CommandHandlerBase<TCommand> : ICommandHandler where TCommand : ICommand
    {
        public abstract Task HandleCommand(TCommand command);
    }
}