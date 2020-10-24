using System.Threading.Tasks;

namespace AbsurdRepliesServer.GameCode
{
    internal interface IGameFinder
    {
        Task<bool> CanFindGame(string gameCode);
    }
}