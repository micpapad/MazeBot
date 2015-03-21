using System;
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
		}
	}
}
