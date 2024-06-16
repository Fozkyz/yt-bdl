using System.Diagnostics.CodeAnalysis;

namespace yt_bdl
{
	internal class Fetchlist
	{
		public required List<Sublist> Sublists { get; set; }

		[SetsRequiredMembers]
		public Fetchlist()
		{
			Sublists = new List<Sublist>();
		}

		[SetsRequiredMembers]
		public Fetchlist(List<Sublist> sublists)
		{
			Sublists = sublists;
		}

		public void Add(Sub sub, string sublistName)
		{
			foreach (var sublist in Sublists)
			{
				if (sublist.Name == sublistName)
				{
					if (!sublist.Contains(sub))
					{
						sublist.Subs.Add(sub);
					}
					return;
				}
			}
			Sublists.Add(new Sublist(sublistName, new List<Sub>() { sub }));
		}

		public void Add(Sublist sublist)
		{
			foreach (var sList in Sublists)
			{
				if (sList.Name == sublist.Name)
				{
					return;
				}
			}
			Sublists.Add(sublist);
		}

		public void Remove(Sub sub)
		{
			foreach (var sublist in Sublists)
			{
				if (sublist.Contains(sub))
				{
					sublist.Subs.Remove(sub);
				}
			}
		}

		public void Remove(Sub sub, string sublistName)
		{
			foreach (var sublist in Sublists)
			{
				if (sublist.Name == sublistName)
				{
					foreach (var s in sublist.Subs)
					{
						if (s.ID == sub.ID)
						{
							sublist.Subs.Remove(s);
							return;
						}
					}
					return;
				}
			}
		}

		public Sublist? GetSublist(string sublistName)
		{
			foreach (var sublist in Sublists)
			{
				if (sublist.Name == sublistName)
				{
					return sublist;
				}
			}
			return null;
		}
	}
}
