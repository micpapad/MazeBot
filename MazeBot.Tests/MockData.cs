using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeBot.Tests
{
	public class MockData
	{
		public static string SampleXml
		{
			get
			{
				return Resources.sSampleXml;
			}
		}

		public static string NoSolutionXml
		{
			get
			{
				return Resources.sSampleXml;
			}
		}

		public static string CheckInitXml
		{
			get
			{
				return Resources.sCheckInitXml;
			}
		}

		public static string ErrorEndPointsXml
		{
			get
			{
				return Resources.sErrorEndPointsXml;
			}
		}

		public static string ErrorWallsXml
		{
			get
			{
				return Resources.sErrorWallsXml;
			}
		}
	}
}
