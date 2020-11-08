namespace AbsurdRepliesServer.Game
{
    public interface IGame
    {
        string Id { get; set; }
        
        bool Initialized { get; set; }
    }
}