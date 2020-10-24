using System.Threading.Tasks;

namespace AbsurdRepliesServer.GameCode
{
    public class NullGameFinder : IGameFinder
    {
        public Task<bool> CanFindGame(string gameCode) => Task.FromResult(false);
    }
}