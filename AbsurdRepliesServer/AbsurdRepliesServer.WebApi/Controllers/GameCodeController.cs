using System.Threading.Tasks;
using AbsurdRepliesServer.Game;
using AbsurdRepliesServer.GameCode;
using Microsoft.AspNetCore.Mvc;
using static AbsurdRepliesServer.Infrastructure.ArgumentValidator;

namespace AbsurdRepliesServer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameCodeController
    {
        private readonly IGameCodeCreator _gameCodeCreator;

        public GameCodeController(IGameCodeCreator gameCodeCreator, IGameCreator gameCreator)
        {
            _gameCodeCreator = ValidateArgumentNotNull(gameCodeCreator, nameof(gameCodeCreator));
        }

        [HttpPost]
        public Task<string> CreateGameCode() => _gameCodeCreator.CreateGameCode();
    }
}