using System;
using MazeBot.Exceptions;
using MazeBot.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeBot.Tests
{
	[TestClass]
	public class GameTests
	{
		[TestMethod]
		public void TestGameInitialization()
		{
			Game game = new Game();
			game.Initialize(MockData.CheckInitXml);
			Assert.AreEqual(1, game.StartPosition.X);
			Assert.AreEqual(2, game.StartPosition.Y);
			Assert.AreEqual(5, game.GoalPosition.X);
			Assert.AreEqual(6, game.GoalPosition.Y);

			Assert.IsTrue(game.Maze.IsWallTile(1, 3));
			Assert.IsTrue(game.Maze.IsWallTile(2, 3));
			Assert.IsTrue(game.Maze.IsWallTile(3, 3));
			Assert.IsTrue(game.Maze.IsWallTile(4, 3));
			Assert.IsTrue(game.Maze.IsWallTile(4, 2));
			Assert.IsTrue(game.Maze.IsWallTile(5, 5));
			Assert.IsTrue(game.Maze.IsWallTile(6, 5));
			Assert.IsTrue(game.Maze.IsWallTile(7, 5));
			Assert.IsTrue(game.Maze.IsWallTile(7, 6));

			Assert.IsFalse(game.Maze.IsWallTile(1, 1));
			Assert.IsFalse(game.Maze.IsWallTile(1, 2));
			Assert.IsFalse(game.Maze.IsWallTile(2, 2));
			Assert.IsFalse(game.Maze.IsWallTile(8, 6));
			Assert.IsFalse(game.Maze.IsWallTile(3, 4));

			Assert.AreEqual(8, game.Maze.Dimensions.X);
			Assert.AreEqual(6, game.Maze.Dimensions.Y);
		}

		[TestMethod]
		public void TestErrorInitialization()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.ErrorEndPointsXml);
				Assert.Fail("Xml should fail");
			}
			catch(XmlException ex)
			{
			}
			try
			{
				game.Initialize(MockData.ErrorWallsXml);
				Assert.Fail("Xml should fail");
			}
			catch(XmlException ex)
			{
			}
		}

	}
}
