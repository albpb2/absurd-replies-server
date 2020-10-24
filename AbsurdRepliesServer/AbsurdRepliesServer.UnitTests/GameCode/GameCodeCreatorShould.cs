using System;
using System.Threading.Tasks;
using AbsurdRepliesServer.GameCode;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace AbsurdRepliesServer.UnitTests.GameCode
{
    [TestFixture]
    public class GameCodeCreatorShould
    {
        [Test]
        public void ThrowException_WhenTheGameCodesAreAlreadyUsed()
        {
            // Arrange
            var gameFinder = Substitute.For<IGameFinder>();
            gameFinder.CanFindGame(Arg.Any<string>()).Returns(true);
            
            var subjectUnderTest = new GameCodeCreator(gameFinder);

            // Act
            Func<Task> functionUnderTest = async () => await subjectUnderTest.CreateGameCode();

            // Assert
            functionUnderTest.Should().Throw<GameCodeCreationAttemptsExceededException>();
        }
    }
}