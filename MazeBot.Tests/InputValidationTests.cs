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

		[TestMethod]
		public void TestWallPointsOffLimitsX()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.Invalid_WallPointsOffLimitsX);
				Assert.Fail("Xml should fail");
			}
			catch (XmlException ex)
			{
				PrivateType pt = new PrivateType("MazeBot", "MazeBot.Resources");
				string msgExpected = pt.GetStaticProperty("sErrXmlWallPointOffLimits").ToString();
				Assert.AreEqual(String.Format(msgExpected, 9, 5), ex.Message);
			}
		}

		[TestMethod]
		public void TestWallPointsOffLimitsY()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.Invalid_WallPointsOffLimitsY);
				Assert.Fail("Xml should fail");
			}
			catch (XmlException ex)
			{
				PrivateType pt = new PrivateType("MazeBot", "MazeBot.Resources");
				string msgExpected = pt.GetStaticProperty("sErrXmlWallPointOffLimits").ToString();
				Assert.AreEqual(String.Format(msgExpected, 5, 9), ex.Message);
			}
		}

		[TestMethod]
		public void StartPointOffLimitsX()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.Invalid_StartPointOffLimitsX);
				Assert.Fail("Xml should fail");
			}
			catch (XmlException ex)
			{
				PrivateType pt = new PrivateType("MazeBot", "MazeBot.Resources");
				string msgExpected = pt.GetStaticProperty("sErrXmlStartPointOffLimits").ToString();
				Assert.AreEqual(String.Format(msgExpected, 9, 5), ex.Message);
			}
		}

		[TestMethod]
		public void StartPointOffLimitsY()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.Invalid_StartPointOffLimitsY);
				Assert.Fail("Xml should fail");
			}
			catch (XmlException ex)
			{
				PrivateType pt = new PrivateType("MazeBot", "MazeBot.Resources");
				string msgExpected = pt.GetStaticProperty("sErrXmlStartPointOffLimits").ToString();
				Assert.AreEqual(String.Format(msgExpected, 5, 9), ex.Message);
			}
		}

		[TestMethod]
		public void GoalPointOffLimitsX()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.Invalid_GoalPointOffLimitsX);
				Assert.Fail("Xml should fail");
			}
			catch (XmlException ex)
			{
				PrivateType pt = new PrivateType("MazeBot", "MazeBot.Resources");
				string msgExpected = pt.GetStaticProperty("sErrXmlGoalPointOffLimits").ToString();
				Assert.AreEqual(String.Format(msgExpected, 9, 5), ex.Message);
			}
		}

		[TestMethod]
		public void GoalPointOffLimitsY()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.Invalid_GoalPointOffLimitsY);
				Assert.Fail("Xml should fail");
			}
			catch (XmlException ex)
			{
				PrivateType pt = new PrivateType("MazeBot", "MazeBot.Resources");
				string msgExpected = pt.GetStaticProperty("sErrXmlGoalPointOffLimits").ToString();
				Assert.AreEqual(String.Format(msgExpected, 5, 9), ex.Message);
			}
		}

		[TestMethod]
		public void TestInvalidMazeDimensionX()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.Invalid_InvalidMazeDimensionsX);
				Assert.Fail("Xml should fail");
			}
			catch (XmlException ex)
			{
				PrivateType pt = new PrivateType("MazeBot", "MazeBot.Resources");
				string msgExpected = pt.GetStaticProperty("sErrXmlInvalidMazeDimensions").ToString();
				Assert.AreEqual(msgExpected, ex.Message);
			}
		}

		[TestMethod]
		public void TestInvalidMazeDimensionY()
		{
			Game game = new Game();
			try
			{
				game.Initialize(MockData.Invalid_InvalidMazeDimensionsY);
				Assert.Fail("Xml should fail");
			}
			catch (XmlException ex)
			{
				PrivateType pt = new PrivateType("MazeBot", "MazeBot.Resources");
				string msgExpected = pt.GetStaticProperty("sErrXmlInvalidMazeDimensions").ToString();
				Assert.AreEqual(msgExpected, ex.Message);
			}
		}

	}
}
