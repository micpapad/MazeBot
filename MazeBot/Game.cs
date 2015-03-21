using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
			XDocument xdoc = XDocument.Parse(xml);

			var endpoints = from endpoint in xdoc.Descendants("Game").Descendants("EndPoints")
							select new
							{
								Children = endpoint.Descendants()
							};

			foreach(var endpoint in endpoints)
			{
				foreach(var child in endpoint.Children)
				{
					if (String.Compare(child.Name.ToString(), "Start", true) == 0)
					{
						StartPosition.X = Convert.ToInt32(child.Attribute("X").Value);
						StartPosition.Y = Convert.ToInt32(child.Attribute("Y").Value);
					}
					else if (String.Compare(child.Name.ToString(), "Goal", true) == 0)
					{
						GoalPosition.X = Convert.ToInt32(child.Attribute("X").Value);
						GoalPosition.Y = Convert.ToInt32(child.Attribute("Y").Value);
					}
				}
			}

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
