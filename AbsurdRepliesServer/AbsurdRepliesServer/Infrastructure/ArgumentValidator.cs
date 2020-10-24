using System;

namespace AbsurdRepliesServer.Infrastructure
{
    internal static class ArgumentValidator
    {
        public static T ValidateArgumentNotNull<T>(T argument, string argumentName) =>
            argument ?? throw new ArgumentException($"Argument {argumentName} should not be null");
    }
}