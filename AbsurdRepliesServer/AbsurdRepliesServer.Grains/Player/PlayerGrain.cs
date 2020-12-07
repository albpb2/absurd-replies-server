using System.Threading.Tasks;
using AbsurdRepliesServer.Game;
using AbsurdRepliesServer.Grains.Game;

namespace AbsurdRepliesServer.Grains.Player
{
    public class PlayerGrain : GameGrain
    {
        private readonly IGame _activeGame;

        public Task<IGame> GetActiveGame()
        {
            if (_activeGame != null)
            {
                if (_activeGame.)
            }
            return Task.FromResult(_activeGame);
        }

        public Task AssignGame(IGame game)
        {
            
        }
    }
}