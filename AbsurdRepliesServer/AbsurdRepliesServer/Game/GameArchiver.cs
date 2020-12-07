using System.Threading.Tasks;
using AbsurdRepliesServer.Infrastructure;

namespace AbsurdRepliesServer.Game
{
    public class GameArchiver
    {
        private const int ArchiveAfterMinutes = 5;

        private readonly IDateTimeProvider _dateTimeProvider;

        public GameArchiver(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
        }

        public async Task<bool> IsArchived(IGame game) => 
            game.FinishedAt.HasValue 
            && game.FinishedAt.Value.AddMinutes(ArchiveAfterMinutes) <= await _dateTimeProvider.GetDateTime();
    }
}