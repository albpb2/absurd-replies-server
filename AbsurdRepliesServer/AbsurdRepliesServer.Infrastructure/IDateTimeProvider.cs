using System;
using System.Threading.Tasks;

namespace AbsurdRepliesServer.Infrastructure
{
    public interface IDateTimeProvider
    {
        Task<DateTime> GetDateTime();
    }
}