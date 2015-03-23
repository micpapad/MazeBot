using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBot.Utils
{
	public class Point
	{
		public int X { get; private set; }
		public int Y { get; private set; }

		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static implicit operator System.Drawing.Point(Point pt)
		{
			return new System.Drawing.Point(pt.X, pt.Y);
		}

		public static double Distance(Point from, Point to)
		{
			return Math.Sqrt(Math.Pow(from.X - to.X, 2) + Math.Pow(from.Y - to.Y, 2));
		}
	}
}
