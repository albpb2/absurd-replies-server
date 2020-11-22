using System.Threading.Tasks;
using AbsurdRepliesServer.Game;
using AbsurdRepliesServer.GameCode;
using AbsurdRepliesServer.Grains.Game;
using Orleans;

namespace AbsurdRepliesServer.OrleansClient.Game
{
    public class GameResolver : IGameResolver
    {
        private readonly IClusterClient _client;
        
        public GameResolver(IClusterClient client, IGameCodeCreator gameCodeCreator)
        {
            _client = client;
        }

        public Task<IGame> GetOrCreateGame(string gameId) => _client.GetGrain<IGameGrain>(gameId).GetGame();
    }
}