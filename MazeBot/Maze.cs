using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeBot.Utils;

namespace MazeBot
{
	public class Maze
	{
		// Canvas is 0-based and is handled privately
		private bool[,] Canvas { get; set; }

		public Point Dimensions
		{
			get
			{
				return new Point(Canvas.GetUpperBound(0) + 1, Canvas.GetUpperBound(1) + 1);
			}
		}

		public Maze()
		{
		}

		public void Initialize(int dimX, int dimY, List<Point> walls)
		{
			Canvas = new bool[dimX, dimY];

			for (int x = 0; x < dimX; ++x)
			{
				for (int y = 0; y < dimY; ++y)
				{
					Canvas[x, y] = true;
				}
			}

			foreach (Point wall in walls)
			{
				Canvas[wall.X - 1, wall.Y - 1] = false;
			}
		}

		public bool IsWallTile(int x, int y)
		{
			return !Canvas[x - 1, y - 1];
		}
	}
}
