using System.Threading.Tasks;
using AbsurdRepliesServer.Game;
using AbsurdRepliesServer.Infrastructure.Commands;
using static AbsurdRepliesServer.Infrastructure.ArgumentValidator;

namespace AbsurdRepliesServer.Commands.Game
{
    public class CreateGameCommandHandler : CommandHandlerBase<CreateGameCommand>
    {
        private readonly IGameCreator _gameCreator;
        
        public CreateGameCommandHandler(IGameCreator gameCreator)
        {
            _gameCreator = ValidateArgumentNotNull(gameCreator, nameof(gameCreator));
        }

        public override Task HandleCommand(CreateGameCommand command) => _gameCreator.CreateGame();
    }
}