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

		public Point FullDimensionsWithOuterWalls
		{
			get
			{
				return new Point(Canvas.GetUpperBound(0) + 1, Canvas.GetUpperBound(1) + 1);
			}
		}

		public Point BoardDimensions
		{
			get
			{
				return new Point(Canvas.GetUpperBound(0) - 1, Canvas.GetUpperBound(1) - 1);
			}
		}

		public Maze()
		{
		}

		public void Initialize(int dimX, int dimY, List<Point> walls)
		{
			Canvas = new bool[dimX + 2, dimY + 2];

			for (int x = 0; x < dimX + 2; ++x)
			{
				for (int y = 0; y < dimY + 2; ++y)
				{
					if (x == 0 || y == 0 || x == dimX + 1 || y == dimY + 1) // canvas is surrounded by walls
						Canvas[x, y] = false;
					else
						Canvas[x, y] = true;
				}
			}

			foreach (Point wall in walls)
			{
				Canvas[wall.X, wall.Y] = false;
			}
		}

		public bool IsWallTile(int x, int y)
		{
			return !Canvas[x, y];
		}
	}
}
