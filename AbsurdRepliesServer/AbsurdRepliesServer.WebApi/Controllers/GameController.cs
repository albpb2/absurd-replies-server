using System.Threading.Tasks;
using AbsurdRepliesServer.Commands.Game;
using AbsurdRepliesServer.Infrastructure.Commands;
using Microsoft.AspNetCore.Mvc;
using static AbsurdRepliesServer.Infrastructure.ArgumentValidator;

namespace AbsurdRepliesServer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController
    {
        private readonly CommandBus _commandBus;

        public GameController(CommandBus commandBus)
        {
            _commandBus = ValidateArgumentNotNull(commandBus, nameof(commandBus));
        }
        
        [HttpPost]
        public Task CreateGame() => _commandBus.HandleCommand(new CreateGameCommand());
    }
}