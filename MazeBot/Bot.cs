using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;
using MazeBot.Utils;

namespace MazeBot
{
	public class Bot
	{
		private TileStatus[,] TileStatus { get; set; }
		private List<Point> Path { get; set; }
		private IGameRulesHolder GameRulesHolder { get; set; }
		public Point Position { get; private set; }
		public Point GoalPositionFound { get; set; }

		public Bot(IGameRulesHolder gameRulesHolder)
		{
			Position = new Point(-1, -1);
			Path = new List<Point>();
			GoalPositionFound = new Point(-1, -1);
			GameRulesHolder = gameRulesHolder;
		}

		public void Initialize(int canvasDimX, int canvasDimY)
		{
			TileStatus = new TileStatus[canvasDimX + 1, canvasDimY + 1];
			Path.Clear();
		}

		public void SetPosition(int x, int y)
		{
			Position = new Point(x, y);
			Path.Add(Position);

			List<TileStatusInfo> tsiList = GameRulesHolder.GetTileStatusInfo(Position);
			foreach(TileStatusInfo tsi in tsiList)
			{
				TileStatus[tsi.X, tsi.Y] = tsi.Status;
			}
		}

		public bool MoveTo(int x, int y)
		{
			while (Position.X != x || Position.Y != y)
			{
				byte[,] grid = BuildPathFinderGrid();
				PathFinder pf = new PathFinder(grid);
				pf.Diagonals = false;
				List<PathFinderNode> nodes = pf.FindPath(Position, new Point(x, y));
				if (nodes == null)
					return false;
				SetPosition(nodes[1].X, nodes[1].Y);
			}
			return true;
		}

		private byte[,] BuildPathFinderGrid()
		{
			int dimX = TileStatus.GetUpperBound(0) + 1;
			int dimY = TileStatus.GetUpperBound(1) + 1;
			byte[,] grid = new byte[dimX, dimY];
			for (int x = 0; x < dimX; ++x)
			{
				for (int y = 0; y < dimY; ++y)
				{
					if (TileStatus[x, y] == MazeBot.TileStatus.Wall)
						grid[x, y] = 0;
					else
						grid[x, y] = 1;
				}
			}
			return grid;
		}
	}
}
