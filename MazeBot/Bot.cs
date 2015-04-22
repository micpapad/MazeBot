using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms;
using MazeBot.Exceptions;
using MazeBot.UI;
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
			TileStatus = new TileStatus[canvasDimX, canvasDimY];
			Path.Clear();
		}

		public void SetPosition(int x, int y)
		{
			bool definingStartingPoint = Position.X == -1 && Position.Y == -1;
			Point newPosition = new Point(x, y);
			if (!definingStartingPoint)
			{
				if (Point.Distance(newPosition, Position) > 1)
					throw new InvalidMovementException(Resources.sErrBotMoveCannotMoveNonAdjacentTiles);

				// this should never happen. Since we are moving to adjacent tile, it should never be undefined.
				// Throw an invalid status error
				if (TileStatus[x, y] == MazeBot.TileStatus.Undefined)
				{
					throw new InvalidMovementException(Resources.sErrBotAdjacentCellShouldNotBeUndefined);
				}
			}
			if (TileStatus[x, y] == MazeBot.TileStatus.Wall)
			{
				throw new InvalidMovementException(Resources.sErrBotCannotMoveToWallTile);
			}

			Position = newPosition;

			Path.Add(Position);

			List<TileStatusInfo> tsiList = GameRulesHolder.GetTileStatusInfo(Position);
			foreach(TileStatusInfo tsi in tsiList)
			{
				TileStatus[tsi.X, tsi.Y] = tsi.Status;
			}
		}

		public TileStatus MoveTo(int x, int y)
		{
			while (Position.X != x || Position.Y != y)
			{
				byte[,] grid = BuildPathFinderGrid();
				PathFinder pf = new PathFinder(grid);
				pf.Diagonals = false;
				List<PathFinderNode> nodes = pf.FindPath(Position, new Point(x, y));
				if (nodes == null)
				{
					if (TileStatus[x, y] == MazeBot.TileStatus.Wall)
						return MazeBot.TileStatus.Wall;
					return MazeBot.TileStatus.Undefined; // no solution;
				}
				SetPosition(nodes[1].X, nodes[1].Y);
				if (TileStatus[Position.X, Position.Y] == MazeBot.TileStatus.Goal)
				{
					GoalPositionFound = new Point(Position.X, Position.Y);
					return MazeBot.TileStatus.Goal;
				}
			}
			return TileStatus[Position.X, Position.Y];
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

		public TileStatus Search()
		{
			TileStatus status = MazeBot.TileStatus.Undefined;
			for (int x = 1; x < TileStatus.GetUpperBound(0); ++x)
			{
				for (int y = 1; y < TileStatus.GetUpperBound(1); ++y)
				{
					if (TileStatus[x, y] == MazeBot.TileStatus.Goal) // if goal is found, move there
						status = MoveTo(x, y);
					else if (TileStatus[x, y] == MazeBot.TileStatus.Undefined) // else move to first unmapped tile.
						status = MoveTo(x, y);
					else
						status = TileStatus[x, y];
					if (status == MazeBot.TileStatus.Goal)
						return status;
				}
			}
			return MazeBot.TileStatus.Undefined;
		}

		public void OutputPath(IOutput output)
		{
			foreach (Point pt in Path)
			{
				output.OutputStep(pt);
			}
		}

	}
}
