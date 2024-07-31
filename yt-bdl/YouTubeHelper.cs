using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace yt_bdl
{
	public class YouTubeHelper
	{
		public string ApiKey { get; set; }

		public YouTubeService YouTubeService { get; private set; }

		public YouTubeHelper(string apiKey)
		{
			ApiKey = apiKey;
			YouTubeService = new YouTubeService(new BaseClientService.Initializer()
			{
				ApiKey = ApiKey
			});
		}

		public async Task<Video> GetVideo(string id)
		{
			var request = YouTubeService.Videos.List("snippet,contentDetails,statistics");
			request.Id = id;

			var response = await request.ExecuteAsync();

			if (response.Items.Count == 0)
			{
				throw new Exception("Could not find video with id " + id);
			}

			var v = response.Items[0];
			
			var video = new Video(id)
			{
				Title = Helper.CleanupString(v.Snippet.Title),
				Description = Helper.CleanupString(v.Snippet.Description),
				ChannelName = Helper.CleanupString(v.Snippet.ChannelTitle),
				ThumbnailUrl = v.Snippet.Thumbnails.High.Url,
				ReleaseDate = v.Snippet.PublishedAtDateTimeOffset?.DateTime
			};

			return video;
		}
	}
}
