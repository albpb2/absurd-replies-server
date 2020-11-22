using AbsurdRepliesServer.Game;

namespace AbsurdRepliesServer.WebApi.Game.Dtos
{
    public class GameDto
    {
        public string Id { get; set; }
        
        public bool Initialized { get; set; }

        public static GameDto FromGame(IGame game) => new GameDto
        {
            Id = game.Id,
            Initialized = game.Initialized
        };
    }
}