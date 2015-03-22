using System;
using MazeBot;
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

		[TestMethod]
		public void TestBotTileInformation()
		{
			Game game = new Game();
			game.Initialize(MockData.SampleXml);

			game.Bot.SetPosition(game.StartPosition.X, game.StartPosition.Y);
			PrivateObject po = new PrivateObject(game.Bot);
			TileStatus[,] tileStatus = (TileStatus[,])po.GetFieldOrProperty("TileStatus");
			Assert.AreEqual(TileStatus.Free, tileStatus[1, 1]);
			Assert.AreEqual(TileStatus.Free, tileStatus[1, 2]);
			Assert.AreEqual(TileStatus.Free, tileStatus[2, 2]);
			Assert.AreEqual(TileStatus.Free, tileStatus[2, 1]);
			Assert.AreEqual(TileStatus.Undefined, tileStatus[3, 1]);
			Assert.AreEqual(TileStatus.Undefined, tileStatus[1, 3]);

			game.Bot.SetPosition(1, 2);
			tileStatus = (TileStatus[,])po.GetFieldOrProperty("TileStatus");
			Assert.AreEqual(TileStatus.Free, tileStatus[1, 1]);
			Assert.AreEqual(TileStatus.Free, tileStatus[1, 2]);
			Assert.AreEqual(TileStatus.Free, tileStatus[2, 2]);
			Assert.AreEqual(TileStatus.Free, tileStatus[2, 1]);
			Assert.AreEqual(TileStatus.Wall, tileStatus[1, 3]);
			Assert.AreEqual(TileStatus.Wall, tileStatus[2, 3]);
			Assert.AreEqual(TileStatus.Undefined, tileStatus[3, 3]);

			game.Bot.SetPosition(5, 6);
			Assert.AreEqual(TileStatus.Goal, tileStatus[6, 6]);
			Assert.AreEqual(TileStatus.Free, tileStatus[1, 1]);
			Assert.AreEqual(TileStatus.Free, tileStatus[1, 1]);
			Assert.AreEqual(TileStatus.Free, tileStatus[1, 2]);
			Assert.AreEqual(TileStatus.Free, tileStatus[2, 2]);
			Assert.AreEqual(TileStatus.Free, tileStatus[2, 1]);
			Assert.AreEqual(TileStatus.Wall, tileStatus[1, 3]);
			Assert.AreEqual(TileStatus.Wall, tileStatus[2, 3]);
			Assert.AreEqual(TileStatus.Undefined, tileStatus[3, 3]);
		}
	}
}
