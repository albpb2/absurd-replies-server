using System.Threading.Tasks;

namespace AbsurdRepliesServer.Game
{
    public interface IGameCreator
    {
        Task<IGame> CreateGame();
    }
}