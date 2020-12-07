using System;
using System.Threading.Tasks;

namespace AbsurdRepliesServer.Infrastructure
{
    public class UtcDateTimeProvider : IDateTimeProvider
    {
        public Task<DateTime> GetDateTime() => DateTime.UtcNow.AsTask();
    }
}