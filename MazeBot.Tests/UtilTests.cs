using System;
using MazeBot.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MazeBot.Tests
{
	[TestClass]
	public class UtilTests
	{
		[TestMethod]
		public void TestDistance()
		{
			{
				Point ptStart = new Point(1, 1);
				Point ptEnd = new Point(2, 2);
				Assert.IsTrue(Math.Abs(Math.Sqrt(2) - Point.Distance(ptStart, ptEnd)) < 0.00000001);
			}

			{
				Point ptStart = new Point(2, 2);
				Point ptEnd = new Point(1, 2);
				Assert.AreEqual(1, Point.Distance(ptStart, ptEnd));
			}

			{
				Point ptStart = new Point(2, 2);
				Point ptEnd = new Point(2, 1);
				Assert.AreEqual(1, Point.Distance(ptStart, ptEnd));
			}

			{
				Point ptStart = new Point(2, 2);
				Point ptEnd = new Point(3, 2);
				Assert.AreEqual(1, Point.Distance(ptStart, ptEnd));
			}

			{
				Point ptStart = new Point(2, 2);
				Point ptEnd = new Point(2, 3);
				Assert.AreEqual(1, Point.Distance(ptStart, ptEnd));
			}
		}
	}
}
