using System;
using System.Text;
using System.Threading.Tasks;
using static AbsurdRepliesServer.Infrastructure.ArgumentValidator;

namespace AbsurdRepliesServer.GameCode
{
    public class GameCodeCreator : IGameCodeCreator
    {
        private readonly IGameFinder _gameFinder;
        private readonly Random _random;

        public GameCodeCreator(IGameFinder gameFinder)
        {
            _gameFinder = ValidateArgumentNotNull(gameFinder, nameof(gameFinder));
            
            _random = new Random();
        }
        
        public async Task<string> CreateGameCode()
        {
            const int maxAttempts = 100;

            for (var attempt = 0; attempt < maxAttempts; attempt++)
            {
                var gameCode = GenerateGameCode();
                if (!await _gameFinder.CanFindGame(gameCode))
                {
                    return gameCode;
                }
            }
            
            throw new GameCodeCreationAttemptsExceededException();
        }

        private string GenerateGameCode()
        {
            const int gameCodeLength = 6;
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            var stringBuilder = new StringBuilder();
            for (var i = 0; i < gameCodeLength; i++)
            {
                stringBuilder.Append(GetRandomChar(allowedChars));
            }

            return stringBuilder.ToString();
        }

        private char GetRandomChar(string source) => source[_random.Next(0, source.Length)];
    }
}