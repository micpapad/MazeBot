using System.Collections.Generic;
using MazeBot.Utils;
namespace MazeBot
{
	public enum TileStatus
	{
		Undefined,
		Free,
		Wall,
		Start,
		Goal
	}

	public class TileStatusInfo
	{
		public int X { get; set; }
		public int Y { get; set; }
		public TileStatus Status { get; set; }
	}

	public interface IGameRulesHolder
	{
		List<TileStatusInfo> GetTileStatusInfo(Point currentPosition);
	}
}
