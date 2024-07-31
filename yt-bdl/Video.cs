using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yt_bdl
{
	public class Video
	{
		public string ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ChannelName { get; set; }
		public string ThumbnailUrl { get; set; }
		public DateTime? ReleaseDate { get; set; }

		public string Url
		{
			get { return "https://www.youtube.com/watch?v=" + ID; }
		}

		public Video(string id)
		{
			ID = id;
			Title = string.Empty;
			Description = string.Empty;
			ChannelName = string.Empty;
			ThumbnailUrl = string.Empty;
		}

	}
}
