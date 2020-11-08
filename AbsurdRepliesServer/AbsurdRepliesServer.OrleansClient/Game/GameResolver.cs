using System.Threading.Tasks;
using AbsurdRepliesServer.Game;
using AbsurdRepliesServer.GameCode;
using AbsurdRepliesServer.Grains.Game;
using Orleans;

namespace AbsurdRepliesServer.Orleans.Game
{
    public class GameResolver : IGameResolver
    {
        private readonly IGrainFactory _grainFactory;
        private readonly IGameCodeCreator _gameCodeCreator;
        
        public GameResolver(IGrainFactory grainFactory, IGameCodeCreator gameCodeCreator)
        {
            _grainFactory = grainFactory;
            _gameCodeCreator = gameCodeCreator;
        }

        public Task<IGame> GetOrCreateGame(string gameId) => _grainFactory.GetGrain<IGameGrain>(gameId).GetGame();
    }
}