using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace yt_bdl
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			// ----- Tests fetchlist to json -----
			////string jsonText = System.IO.File.ReadAllText("data.json");
			//Console.WriteLine("Hello, World!");

			////GenerateExampleFetchlistJson();
			//var fetchList = new Fetchlist();
			//var date = DateTime.Now;
			//fetchList.Add(new Sub("C1", "Chaine 1", date, Sub.SubType.Channel), "Humour");
			//fetchList.Add(new Sub("C1", "Chaine 1", date, Sub.SubType.Channel), "Humour");
			//fetchList.Add(new Sub("C2", "Chaine 2", date, Sub.SubType.Channel), "Humour");
			//fetchList.Add(new Sub("C3", "Chaine 3", date, Sub.SubType.Channel), "GAMING");

			//var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } };
			//var jsonText = JsonSerializer.Serialize(fetchList, options);
			//File.WriteAllText("E:/output.json", jsonText);

			// ----- Tests config file -----
			//WriteConfigFile(new Config("myApiKey", ""));
			//SetApiKey("myNewAPIkey");


			// ----- Tests video downloading -----
			Console.WriteLine("Enter your api key :");
			var key = Console.ReadLine();
			if (key == null )
			{
				return;
			}

			var youTubeHelper = new YouTubeHelper(key);

			await DownloadVideo("KSlGJv3LZII", "E:/Temp", youTubeHelper);
			//try
			//{
			//	var video = await youTubeHelper.GetVideo("BzBbd6JshYE");
			//	await VideoDownloader.DownloadVideo(video, "E:/Temp");
			//}
			//catch (Exception ex)
			//{
			//	Console.WriteLine(ex.Message);
			//}

		}

		public static async Task DownloadVideo(string id, string path, YouTubeHelper youTubeHelper)
		{
			try
			{
				var video = await youTubeHelper.GetVideo(id);
				await VideoDownloader.DownloadVideo(video, path);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			//var process = new Process();
			//var startInfo = new ProcessStartInfo();

			//var url = "https://www.youtube.com/watch?v=" + id;

			//startInfo.WindowStyle = ProcessWindowStyle.Normal;
			//startInfo.WorkingDirectory = path;
			//startInfo.FileName = "cmd.exe";
			//startInfo.Arguments = "/C yt-dlp " + url + " -f \"bv+ba/b\" --merge-output-format mp4";

			//process.StartInfo = startInfo;
			//process.Start();

			//await process.WaitForExitAsync();
		}

		public static void WriteConfigFile(Config? config)
		{
			if (config == null)
			{
				config = new Config("", "");
			}
			var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } };
			var jsonText = JsonSerializer.Serialize(config, options);
			File.WriteAllText("config.json", jsonText);
		}

		public static void SetApiKey(string apiKey)
		{
			var jsonText = File.ReadAllText("config.json");
			Config? config = JsonSerializer.Deserialize<Config>(jsonText);
			if (config != null)
			{
				config.ApiKey = apiKey;
				WriteConfigFile(config);
			}
		}

		public static void SetOutputPath(string outputPath)
		{
			var jsonText = File.ReadAllText("config.json");
			Config? config = JsonSerializer.Deserialize<Config>(jsonText);
			if (config != null)
			{
				config.OutputPath = outputPath;
				WriteConfigFile(config);
			}
		}

		public static void GetApiKey()
		{
			var jsonText = File.ReadAllText("config.json");
			Config? config = JsonSerializer.Deserialize<Config>(jsonText);
			if (config != null)
			{
				Console.WriteLine(config.ApiKey);
			}
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
