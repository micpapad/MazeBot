using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeBot.Utils;

namespace MazeBot
{
	public class Bot
	{
		private TileStatus[,] TileStatus { get; set; }
		private IGameRulesHolder GameRulesHolder { get; set; }
		public Point Position { get; private set; }
		public Point GoalPositionFound { get; set; }

		public Bot(IGameRulesHolder gameRulesHolder)
		{
			Position = new Point(-1, -1);
			GoalPositionFound = new Point(-1, -1);
			GameRulesHolder = gameRulesHolder;
		}

		public void Initialize(int canvasDimX, int canvasDimY)
		{
			TileStatus = new TileStatus[canvasDimX + 1, canvasDimY + 1];
		}

		public void SetPosition(int x, int y)
		{
			Position = new Point(x, y);

			List<TileStatusInfo> tsiList = GameRulesHolder.GetTileStatusInfo(Position);
			foreach(TileStatusInfo tsi in tsiList)
			{
				TileStatus[tsi.X, tsi.Y] = tsi.Status;
			}
		}

		public void MoveTo(int x, int y)
		{

		}


	}
}
