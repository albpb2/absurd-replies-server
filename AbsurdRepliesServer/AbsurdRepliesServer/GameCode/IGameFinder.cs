﻿using System.Threading.Tasks;

namespace AbsurdRepliesServer.GameCode
{
    public interface IGameFinder
    {
        Task<bool> CanFindGame(string gameCode);
    }
}