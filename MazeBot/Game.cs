using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MazeBot.Exceptions;
using MazeBot.UI;
using MazeBot.Utils;

namespace MazeBot
{
	public class Game : IGameRulesHolder
	{
		public GameResult Result { get; set; }
		public Bot Bot { get; set; }
		public Maze Maze { get; set; }
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

			// Read Maze definition
			XElement mazeDefinition = xdoc.Descendants("MazeDefinition").First();
			int dimX = Convert.ToInt32(mazeDefinition.Attribute("X").Value);
			int dimY = Convert.ToInt32(mazeDefinition.Attribute("Y").Value);
			if (dimX <= 0 || dimY <= 0)
				throw new XmlException(Resources.sErrXmlInvalidMazeDimensions);

			var walltiles = from walltile in xdoc.Descendants("MazeDefinition").Descendants("Walls").Descendants("WallTile")
							select walltile;

			if (walltiles.Count() == 0)
				throw new XmlException(Resources.sErrXmlNoWallsDefined);
			List<Point> wallTilePoints = new List<Point>();
			foreach (var walltile in walltiles)
			{
				Point ptWall = new Point(Convert.ToInt32(walltile.Attribute("X").Value),
											 Convert.ToInt32(walltile.Attribute("Y").Value));
				if (ptWall.X > dimX || ptWall.Y > dimY || ptWall.X < 1 || ptWall.Y < 1)
					throw new XmlException(String.Format(Resources.sErrXmlWallPointOffLimits, ptWall.X, ptWall.Y));

				wallTilePoints.Add(ptWall);
			}

			// Read end points
			var endpoints = from endpoint in xdoc.Descendants("Game").Descendants("EndPoints")
							select new
							{
								Children = endpoint.Descendants()
							};

			if (endpoints.Count() == 0)
				throw new XmlException(Resources.sErrXmlNoEndpointsFound);

			foreach(var endpoint in endpoints)
			{
				foreach(var child in endpoint.Children)
				{
					if (String.Compare(child.Name.ToString(), "Start", true) == 0)
					{
						StartPosition = new Point(Convert.ToInt32(child.Attribute("X").Value), Convert.ToInt32(child.Attribute("Y").Value));
						if (StartPosition.X > dimX || StartPosition.Y > dimY || StartPosition.X < 1 || StartPosition.Y < 1)
							throw new XmlException(Resources.sErrXmlStartPointOffLimits);
					}
					else if (String.Compare(child.Name.ToString(), "Goal", true) == 0)
					{
						GoalPosition = new Point(Convert.ToInt32(child.Attribute("X").Value), Convert.ToInt32(child.Attribute("Y").Value));
						if (GoalPosition.X > dimX || GoalPosition.Y > dimY || GoalPosition.X < 1 || GoalPosition.Y < 1)
							throw new XmlException(Resources.sErrXmlStartPointOffLimits);
					}
				}
			}

			Maze = new Maze();
			Maze.Initialize(dimX, dimY, wallTilePoints);

			if (Maze.IsWallTile(StartPosition.X, StartPosition.Y))
				throw new XmlException(Resources.sErrXmlStartingPointShouldNotBeAtWall);

			if (Maze.IsWallTile(GoalPosition.X, GoalPosition.Y))
				throw new XmlException(Resources.sErrXmlGoalPointShouldNotBeAtWall);

			Bot = new Bot(this);
			Bot.Initialize(Maze.Dimensions.X, Maze.Dimensions.Y);
			Bot.SetPosition(StartPosition.X, StartPosition.Y);
		}

		public void Play()
		{
			ConsoleOutput output = new ConsoleOutput();
			Result = GameResult.GameInProgress;
			TileStatus status = Bot.Search();
			switch(status)
			{
				case TileStatus.Goal:
					Result = GameResult.GoalFound;
					break;
				case TileStatus.Undefined:
					Result = GameResult.GoalNotFound;
					break;
				default:
					Debug.Assert(false);
					throw new GameException(Resources.sErrGameInvalidResult);
			}

			OutputGameResults(output);
		}

		private void OutputGameResults(IOutput output)
		{
			output.OutputResult(Result);
			Bot.OutputPath(output);
		}



		#region IGameRulesHolder Members

		private TileStatus GetTileStatus(int x, int y)
		{
			TileStatus ret = TileStatus.Undefined;

			if (x == GoalPosition.X && y == GoalPosition.Y)
			{
				ret = TileStatus.Goal;
			}
			else if (Maze.IsWallTile(x, y))
			{
				ret = TileStatus.Wall;
			}
			else
				ret = TileStatus.Free;

			Debug.Assert(ret != TileStatus.Undefined); // Should have a value;

			return ret;
		}

		private TileStatusInfo CheckTileStatus(int x, int y)
		{
			TileStatus ts = GetTileStatus(x, y);
			return new TileStatusInfo() { Status = ts, X = x, Y = y };
		}

		public List<TileStatusInfo> GetTileStatusInfo(Point currentPosition)
		{
			List<TileStatusInfo> tileStatuses = new List<TileStatusInfo>();

			tileStatuses.Add(CheckTileStatus(currentPosition.X, currentPosition.Y));
			tileStatuses.Add(CheckTileStatus(currentPosition.X - 1, currentPosition.Y));
			tileStatuses.Add(CheckTileStatus(currentPosition.X + 1, currentPosition.Y));
			tileStatuses.Add(CheckTileStatus(currentPosition.X, currentPosition.Y - 1));
			tileStatuses.Add(CheckTileStatus(currentPosition.X, currentPosition.Y + 1));
			
			return tileStatuses;
		}


		#endregion
	}
}
