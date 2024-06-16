using System.Diagnostics.CodeAnalysis;

namespace yt_bdl
{
	internal class Sub
	{
		public required string ID { get; set; }
		public required string Name { get; set; }
		public required DateTime LastFetch { get; set; }
		public required SubType Type { get; set; }

		[SetsRequiredMembers]
		public Sub(string iD, string name, DateTime lastFetch, SubType type)
		{
			ID = iD;
			Name = name;
			LastFetch = lastFetch;
			Type = type;
		}

		public enum SubType
		{
			Channel,
			Playlist
		}
	}
}
