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

		private void DefineMazeFromXml(XDocument xdoc)
		{
			// Read Maze definition
			XElement mazeDefinition = xdoc.Descendants("MazeDefinition").First();
			int dimX = Convert.ToInt32(mazeDefinition.Attribute("X").Value);
			int dimY = Convert.ToInt32(mazeDefinition.Attribute("Y").Value);
			if (dimX <= 0 || dimY <= 0)
				throw new XmlException(Resources.sErrXmlInvalidMazeDimensions);

			var wallElements = mazeDefinition.Descendants("Walls");
			if (wallElements == null || wallElements.Count() == 0)
				throw new XmlException(Resources.sErrXmlNoWallsDefined);

			XElement wallElement = wallElements.First();

			XAttribute noWallsAttr = wallElement.Attribute("nowalls");

			List<Point> wallTilePoints = new List<Point>();
			if (noWallsAttr == null || String.Compare(noWallsAttr.Value, "true") != 0)
			{
				var walltiles = from walltile in xdoc.Descendants("MazeDefinition").Descendants("Walls").Descendants("WallTile")
								select walltile;

				if (walltiles.Count() == 0)
					throw new XmlException(Resources.sErrXmlNoWallsDefined);
				foreach (var walltile in walltiles)
				{
					Point ptWall = new Point(Convert.ToInt32(walltile.Attribute("X").Value),
												 Convert.ToInt32(walltile.Attribute("Y").Value));
					if (ptWall.X > dimX || ptWall.Y > dimY || ptWall.X < 1 || ptWall.Y < 1)
						throw new XmlException(String.Format(Resources.sErrXmlWallPointOffLimits, ptWall.X, ptWall.Y));

					wallTilePoints.Add(ptWall);
				}
			}

			Maze = new Maze();
			Maze.Initialize(dimX, dimY, wallTilePoints);
		}

		private void DefineGamePropertiesFromXml(XDocument xdoc)
		{
			// Read end points
			var endpoints = from endpoint in xdoc.Descendants("Game").Descendants("EndPoints")
							select new
							{
								Children = endpoint.Descendants()
							};

			if (endpoints.Count() == 0)
				throw new XmlException(Resources.sErrXmlNoEndpointsFound);

			foreach (var endpoint in endpoints)
			{
				foreach (var child in endpoint.Children)
				{
					if (String.Compare(child.Name.ToString(), "Start", true) == 0)
					{
						StartPosition = new Point(Convert.ToInt32(child.Attribute("X").Value), Convert.ToInt32(child.Attribute("Y").Value));
						if (StartPosition.X > Maze.BoardDimensions.X || StartPosition.Y > Maze.BoardDimensions.Y || StartPosition.X < 1 || StartPosition.Y < 1)
							throw new XmlException(Resources.sErrXmlStartPointOffLimits);
						if (Maze.IsWallTile(StartPosition.X, StartPosition.Y))
							throw new XmlException(Resources.sErrXmlStartingPointShouldNotBeAtWall);

					}
					else if (String.Compare(child.Name.ToString(), "Goal", true) == 0)
					{
						GoalPosition = new Point(Convert.ToInt32(child.Attribute("X").Value), Convert.ToInt32(child.Attribute("Y").Value));
						if (GoalPosition.X > Maze.BoardDimensions.X || GoalPosition.Y > Maze.BoardDimensions.Y || GoalPosition.X < 1 || GoalPosition.Y < 1)
							throw new XmlException(Resources.sErrXmlStartPointOffLimits);
						if (Maze.IsWallTile(GoalPosition.X, GoalPosition.Y))
							throw new XmlException(Resources.sErrXmlGoalPointShouldNotBeAtWall);
					}
				}
			}
		}

		private void InitializeBot()
		{
			Bot = new Bot(this);
			Bot.Initialize(Maze.FullDimensionsWithOuterWalls.X, Maze.FullDimensionsWithOuterWalls.Y);
			Bot.SetPosition(StartPosition.X, StartPosition.Y);
		}

		public void Initialize(string xml)
		{
			XDocument xdoc = XDocument.Parse(xml);

			DefineMazeFromXml(xdoc);
			DefineGamePropertiesFromXml(xdoc);

			InitializeBot();
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
