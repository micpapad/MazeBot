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
		public Point Position { get; set; }
		public Point GoalPositionFound { get; set; }

		public Bot()
		{
			Position = new Point(-1, -1);
			GoalPositionFound = new Point(-1, -1);
		}

		public void SetPosition(int x, int y)
		{
			Position.X = x;
			Position.Y = y;
		}

		public void MoveTo(int x, int y)
		{

		}
	}
}
