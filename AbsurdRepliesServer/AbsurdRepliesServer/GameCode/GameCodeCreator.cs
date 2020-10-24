using System;
using System.Text;
using System.Threading.Tasks;

namespace AbsurdRepliesServer.GameCode
{
    public class GameCodeCreator
    {
        private readonly IGameFinder _gameFinder;
        private readonly Random _random;

        private static readonly char[] AllowedChars = {'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H'}; 

        internal GameCodeCreator(IGameFinder gameFinder)
        {
            _gameFinder = gameFinder ?? throw new ArgumentException($"nameof(gameFinder) not provided");
            
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