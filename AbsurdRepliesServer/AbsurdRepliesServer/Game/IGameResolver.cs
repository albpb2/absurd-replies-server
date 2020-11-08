using System.Threading.Tasks;

namespace AbsurdRepliesServer.Game
{
    public interface IGameResolver
    {
        Task<IGame> GetOrCreateGame(string gameId);
    }
}