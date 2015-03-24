using System;
using MazeBot.Exceptions;
using MazeBot.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeBot.Tests
{
	[TestClass]
	public class InputValidationTests
	{
		[TestMethod]
		public void TestStartPointAtWall()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.Invalid_StartPointAtWall);
				Assert.Fail("Xml should fail");
			}
			catch (XmlException ex)
			{
				PrivateType pt = new PrivateType("MazeBot", "MazeBot.Resources");
				string msgExpected = pt.GetStaticProperty("sErrXmlStartingPointShouldNotBeAtWall").ToString();
				Assert.AreEqual(msgExpected, ex.Message);
			}
		}

		[TestMethod]
		public void TestGoalPointAtWall()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.Invalid_GoalPointAtWall);
				Assert.Fail("Xml should fail");
			}
			catch (XmlException ex)
			{
				PrivateType pt = new PrivateType("MazeBot", "MazeBot.Resources");
				string msgExpected = pt.GetStaticProperty("sErrXmlGoalPointShouldNotBeAtWall").ToString();
				Assert.AreEqual(msgExpected, ex.Message);
			}
		}
	}
}
