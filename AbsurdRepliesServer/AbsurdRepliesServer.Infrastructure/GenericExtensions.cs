using System.Threading.Tasks;

namespace AbsurdRepliesServer.Infrastructure
{
    public static class GenericExtensions
    {
        public static Task<T> AsTask<T>(this T obj)
        {
            return Task.FromResult(obj);
        }
    }
}