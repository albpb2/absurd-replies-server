using System.Threading.Tasks;
using AbsurdRepliesServer.Game;
using Orleans;

namespace AbsurdRepliesServer.Grains.Game
{
    public interface IGameGrain : IGrainWithStringKey
    {
        Task<IGame> GetGame();
    }
}