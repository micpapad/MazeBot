using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeBot.Utils;

namespace MazeBot
{
	public class Game
	{
		public GameResult Result { get; set; }
		public Bot Bot { get; set; }
		public Point StartPosition { get; set; }
		public Point GoalPosition { get; set; }

		public Game()
		{
			Result = GameResult.GameNotStarted;
			StartPosition = new Point(0, 0);
			GoalPosition = new Point(0, 0);
		}

		public void Initialize(string xml)
		{
			Bot = new Bot();
		}

		public void Play()
		{
			Result = GameResult.GameInProgress;

			Bot.Position.X = StartPosition.X;
			Bot.Position.Y = StartPosition.Y;
		}

	}
}
