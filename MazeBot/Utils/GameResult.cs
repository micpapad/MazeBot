using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MazeBot.Utils
{
	public enum GameResult
	{
		GameNotStarted,
		GameInProgress,
		GoalFound,
		GoalNotFound
	}

	public static class ResultDescriptions
	{
		public static string GetResultDesription(GameResult result)
		{
			switch(result)
			{
				case GameResult.GameNotStarted:
					return Resources.sGameNotStarted;
				case GameResult.GameInProgress:
					return Resources.sGameInProgress;
				case GameResult.GoalFound:
					return Resources.sGoalFound;
				case GameResult.GoalNotFound:
					return Resources.sGoalNotFound;
				default:
					Debug.Assert(false);
					return "";
			}
		}
	}
}
