using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yt_bdl
{
	internal class Config
	{
		public required string ApiKey { get; set; }
		public required string OutputPath { get; set; }

		[SetsRequiredMembers]
		public Config(string apiKey, string outputPath)
		{
			ApiKey = apiKey;
			OutputPath = outputPath;
		}
	}
}
