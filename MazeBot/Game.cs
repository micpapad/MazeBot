using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MazeBot.Exceptions;
using MazeBot.Utils;

namespace MazeBot
{
	public class Game
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

			// Initialize Maze
			XElement mazeDefinition = xdoc.Descendants("MazeDefinition").First();
			int dimX = Convert.ToInt32(mazeDefinition.Attribute("X").Value);
			int dimY = Convert.ToInt32(mazeDefinition.Attribute("Y").Value);

			var walltiles = from walltile in xdoc.Descendants("MazeDefinition").Descendants("Walls").Descendants("WallTile")
							select walltile;

			if (walltiles.Count() == 0)
				throw new XmlException(Resources.sErrXmlNoEndpointsFound);
			List<Point> wallTilePoints = new List<Point>();
			foreach(var walltile in walltiles)
			{
				wallTilePoints.Add(new Point(Convert.ToInt32(walltile.Attribute("X").Value),
											 Convert.ToInt32(walltile.Attribute("Y").Value)));
			}
			Maze = new Maze();
			Maze.Initialize(dimX, dimY, wallTilePoints);
			
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
