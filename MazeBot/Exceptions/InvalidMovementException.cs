using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBot.Exceptions
{
	public class InvalidMovementException : Exception
	{
		public InvalidMovementException(string message) : base(message)
		{
		}
	}
}
