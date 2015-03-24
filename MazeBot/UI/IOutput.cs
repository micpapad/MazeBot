using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeBot.Utils;

namespace MazeBot.UI
{
	public interface IOutput
	{
		void OutputResult(GameResult result);
		void OutputStep(Point pt);
	}
}
