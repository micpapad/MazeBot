using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeBot.Utils;

namespace MazeBot.UI
{
	class ConsoleOutput : IOutput
	{
		#region IOutput Members

		public void OutputResult(GameResult result)
		{
			string description = ResultDescriptions.GetResultDesription(result);
			Console.WriteLine(String.Format(Resources.sGameResult, result));
		}

		public void OutputStep(Point pt)
		{
			Console.WriteLine(String.Format(Resources.sPoint, pt.X, pt.Y));			
		}

		#endregion
	}
}
