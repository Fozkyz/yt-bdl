using System.Diagnostics.CodeAnalysis;

namespace yt_bdl
{
	internal class Sublist
	{
		public required string Name { get; set; }
		public required List<Sub> Subs { get; set; }

		[SetsRequiredMembers]
		public Sublist(string name)
		{
			Name = name;
			Subs = new List<Sub>();
		}

		[SetsRequiredMembers]
		public Sublist(string name, List<Sub> subs)
		{
			Name = name;
			Subs = subs;
		}

		public bool Contains(Sub sub)
		{
			foreach (var s in Subs)
			{
				if (s.ID == sub.ID)
				{
					return true;
				}
			}
			return false;
		}
	}
}
