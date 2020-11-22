using System.Threading.Tasks;
using AbsurdRepliesServer.Game;
using AbsurdRepliesServer.WebApi.Game.Dtos;
using Microsoft.AspNetCore.Mvc;
using static AbsurdRepliesServer.Infrastructure.ArgumentValidator;

namespace AbsurdRepliesServer.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController
    {
        private readonly IGameCreator _gameCreator;

        public GameController(IGameCreator gameCreator)
        {
            _gameCreator = ValidateArgumentNotNull(gameCreator, nameof(gameCreator));
        }
        
        [HttpPost]
        public async Task<GameDto> CreateGame() => GameDto.FromGame(await _gameCreator.CreateGame());
    }
}