using System.Threading.Tasks;
using AbsurdRepliesServer.GameCode;

namespace AbsurdRepliesServer.Game
{
    public class GameCreator : IGameCreator
    {
        private readonly IGameCodeCreator _gameCodeCreator;
        private readonly IGameResolver _gameResolver;

        public GameCreator(IGameCodeCreator gameCodeCreator, IGameResolver gameResolver)
        {
            _gameCodeCreator = gameCodeCreator;
            _gameResolver = gameResolver;
        }
        
        public async Task<IGame> CreateGame() => 
            await _gameResolver.GetOrCreateGame(await _gameCodeCreator.CreateGameCode());
    }
}