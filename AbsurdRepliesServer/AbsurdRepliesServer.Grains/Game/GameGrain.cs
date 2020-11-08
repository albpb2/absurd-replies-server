using System.Threading.Tasks;
using AbsurdRepliesServer.Game;
using Orleans;

namespace AbsurdRepliesServer.Grains.Game
{
    public class GameGrain : Grain, IGameGrain
    {
        private IGame _game;
        
        public override async Task OnActivateAsync()
        {
            await base.OnActivateAsync();

            _game ??= new AbsurdRepliesServer.Game.Game
            {
                Id = this.IdentityString
            };
        }

        public Task<IGame> GetGame() => Task.FromResult(_game);
    }
}