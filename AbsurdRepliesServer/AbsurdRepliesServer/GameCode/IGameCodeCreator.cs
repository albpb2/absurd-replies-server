using System.Threading.Tasks;

namespace AbsurdRepliesServer.GameCode
{
    public interface IGameCodeCreator
    {
        Task<string> CreateGameCode();
    }
}