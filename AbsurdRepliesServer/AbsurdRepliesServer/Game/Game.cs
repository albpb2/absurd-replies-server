using System;

namespace AbsurdRepliesServer.Game
{
    public class Game : IGame
    {
        public string Id { get; set; }
        public bool Initialized { get; set; }
        public DateTime? FinishedAt { get; set; }
    }
}