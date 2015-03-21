using System;
using MazeBot.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeBot.Tests
{
	[TestClass]
	public class BotMovementTests
	{
		[TestMethod]
		public void TestSampleMoveDirectlyToGoal()
		{
			Game game = new Game();
			game.Initialize(MockData.SampleXml);
			game.Bot.MoveTo(game.GoalPosition.X, game.GoalPosition.Y);
			Assert.AreEqual(game.GoalPosition.X, game.Bot.Position.X);
			Assert.AreEqual(game.GoalPosition.Y, game.Bot.Position.Y);

			Assert.AreEqual(GameResult.GoalFound, game.Result);
			Assert.AreEqual(game.GoalPosition.X, game.Bot.GoalPositionFound.X);
			Assert.AreEqual(game.GoalPosition.Y, game.Bot.GoalPositionFound.Y);
		}

		[TestMethod]
		public void TestSampleAutoPlay()
		{
			Game game = new Game();
			game.Initialize(MockData.SampleXml);
			game.Play();

			Assert.AreEqual(GameResult.GoalFound, game.Result);
			Assert.AreEqual(game.GoalPosition.X, game.Bot.GoalPositionFound.X);
			Assert.AreEqual(game.GoalPosition.Y, game.Bot.GoalPositionFound.Y);
		}

		[TestMethod]
		public void TestNoSolutionFound()
		{
			Game game = new Game();
			game.Initialize(MockData.NoSolutionXml);
			game.Play();

			Assert.AreEqual(GameResult.GoalNotFound, game.Result);
		}
	}
}
