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
				return Resources.sNoSolutionXml;
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

		public static string Invalid_StartPointAtWall
		{
			get
			{
				return Resources.sInvalidXml_StartPointAtWall;
			}
		}

		public static string Invalid_GoalPointAtWall
		{
			get
			{
				return Resources.sInvalidXml_GoalPointAtWall;
			}
		}

		public static string Invalid_WallPointsOffLimitsX
		{
			get
			{
				return Resources.sInvalidXml_WallPointsOffLimitsX;
			}
		}

		public static string Invalid_WallPointsOffLimitsY
		{
			get
			{
				return Resources.sInvalidXml_WallPointsOffLimitsY;
			}
		}

		public static string Invalid_StartPointOffLimitsX
		{
			get
			{
				return Resources.sInvalidXml_StartPointOffLimitsX;
			}
		}

		public static string Invalid_StartPointOffLimitsY
		{
			get
			{
				return Resources.sInvalidXml_StartPointOffLimitsY;
			}
		}

		public static string Invalid_GoalPointOffLimitsX
		{
			get
			{
				return Resources.sInvalidXml_GoalPointOffLimitsX;
			}
		}

		public static string Invalid_GoalPointOffLimitsY
		{
			get
			{
				return Resources.sInvalidXml_GoalPointOffLimitsY;
			}
		}

		public static string Invalid_InvalidMazeDimensionsX
		{
			get
			{
				return Resources.sInvalidXml_InvalidMazeDimensionsX;
			}
		}

		public static string Invalid_InvalidMazeDimensionsY
		{
			get
			{
				return Resources.sInvalidXml_InvalidMazeDimensionsY;
			}
		}
	}
}
