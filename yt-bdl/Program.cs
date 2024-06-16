using System.Text.Json;
using System.Text.Json.Serialization;

namespace yt_bdl
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//string jsonText = System.IO.File.ReadAllText("data.json");
			Console.WriteLine("Hello, World!");

			//GenerateExampleFetchlistJson();
			var fetchList = new Fetchlist();
			var date = DateTime.Now;
			fetchList.Add(new Sub("C1", "Chaine 1", date, Sub.SubType.Channel), "Humour");
			fetchList.Add(new Sub("C1", "Chaine 1", date, Sub.SubType.Channel), "Humour");
			fetchList.Add(new Sub("C2", "Chaine 2", date, Sub.SubType.Channel), "Humour");
			fetchList.Add(new Sub("C3", "Chaine 3", date, Sub.SubType.Channel), "GAMING");

			var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } };
			var r = JsonSerializer.Serialize(fetchList, options);
			File.WriteAllText("E:/output.json", r);
		}

		public static void AddSubToFetchlist(List<Sublist> fetchlists, Sub sub, string fetchlistName)
		{
			foreach (Sublist list in fetchlists)
			{
				if (list.Name == fetchlistName && !list.Subs.Contains(sub))
				{
					list.Subs.Add(sub);
					return;
				}
			}
			fetchlists.Add(new Sublist(fetchlistName, new List<Sub> { sub }));
		}

		public static List<Fetchlist>? LoadFetchlistsFromFile(string path)
		{
			return JsonSerializer.Deserialize<List<Fetchlist>>(path);
		}

		private static void GenerateExampleFetchlistJson(string path = "E:/output.json")
		{
			var fetchlist = new Fetchlist(
				new List<Sublist>{
					new Sublist(
						"Ma Fetch list 1",
						new List<Sub>()
						{
							new Sub("P1", "Ma playlist", DateTime.Now, Sub.SubType.Playlist),
							new Sub("P2", "Ma playlist2", DateTime.Now, Sub.SubType.Playlist),
							new Sub("C1", "Ma chaine", DateTime.Now, Sub.SubType.Channel)
						}),
					new Sublist(
						"Ma Fetch list 2",
						new List<Sub>()
						{
							new Sub("P3", "Ma playlist 3", DateTime.Now, Sub.SubType.Playlist),
							new Sub("P4", "Ma playlist 4", DateTime.Now, Sub.SubType.Playlist),
							new Sub("C2", "Ma chaine 2", DateTime.Now, Sub.SubType.Channel)
						})
				}
			);

			var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } };
			var r = JsonSerializer.Serialize(fetchlist, options);
			File.WriteAllText(path, r);
		}
	}
}
