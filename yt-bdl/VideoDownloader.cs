using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yt_bdl
{
	public class VideoDownloader
	{
		public static async Task DownloadVideo(Video video, string path)
		{
			var tempPath = path + "/temp/";

			if (!Directory.Exists(tempPath))
			{
				Directory.CreateDirectory(tempPath);
			}

			var process = new Process();
			var startInfo = new ProcessStartInfo();

			startInfo.WindowStyle = ProcessWindowStyle.Normal;
			startInfo.WorkingDirectory = tempPath;
			startInfo.FileName = "cmd.exe";
			startInfo.Arguments = "/C yt-dlp " + video.Url + " -f \"bv+ba/b\" --merge-output-format mp4 -o \"video.mp4\"";

			process.StartInfo = startInfo;
			process.Start();

			await process.WaitForExitAsync();

			await DownloadVideoThumbnail(video, path);
			
			//startInfo.FileName = "ffmpeg";
			startInfo.WorkingDirectory = path;
			startInfo.UseShellExecute = false;
			startInfo.Arguments = $"/C ffmpeg -i {tempPath}video.mp4 -i {tempPath}thumbnail.png -map 1 -map 0 -c copy -disposition:0 attached_pic "
				+ $"-metadata title=\"{video.Title}\" -metadata artist=\"{video.ChannelName}\" -metadata comment=\"{video.Description}\" "
				+ $"-metadata creation_time=\"{video.ReleaseDate?.ToString("yyyy-MM-ddTHH:mm:ss")}\" "
				+ $"\"{video.Title}.mp4\" -y";

			Console.WriteLine("---------------------------------------");
			Console.WriteLine(startInfo.Arguments);
			Console.WriteLine("---------------------------------------");


			process.Close();
			process.StartInfo = startInfo;
			process.Start();

			await process.WaitForExitAsync();
		}

		public static async Task DownloadVideoThumbnail(Video video, string path)
		{
			var tempPath = path + "/temp/";

			using (var client = new HttpClient())
			{
				var response = await client.GetAsync(video.ThumbnailUrl);
				response.EnsureSuccessStatusCode();
				using (var fileStream = new System.IO.FileStream(tempPath + "thumbnail.png", System.IO.FileMode.Create, System.IO.FileAccess.Write))
				{
					await response.Content.CopyToAsync(fileStream);
				}
			}
		}
	}
}
