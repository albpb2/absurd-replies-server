using System.Threading.Tasks;
using AbsurdRepliesServer.GameCode;
using Microsoft.AspNetCore.Mvc;
using static AbsurdRepliesServer.Infrastructure.ArgumentValidator;

namespace AbsurdRepliesServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameCodeController
    {
        private readonly IGameCodeCreator _gameCodeCreator;

        public GameCodeController(IGameCodeCreator gameCodeCreator)
        {
            _gameCodeCreator = ValidateArgumentNotNull(gameCodeCreator, nameof(gameCodeCreator));
        }

        [HttpGet]
        public Task<string> CreateGameCode() => _gameCodeCreator.CreateGameCode();
    }
}