using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yt_bdl
{
	public class Helper
	{
		private static string[] excludableCharacter = ["*", "?", "<", ">"];
		private static string[] dashReplaceableCharacters = ["/", "\\", ":", "|"];
		private static string[] quoteReplaceableCharacters = ["\""];

		public static string CleanupString(string str)
		{
			var returnString = str;
			foreach (var c in excludableCharacter)
			{
				returnString = returnString.Replace(c, "");
			}
			foreach (var c in dashReplaceableCharacters)
			{
				returnString = returnString.Replace(c, "-");
			}
			foreach (var c in quoteReplaceableCharacters)
			{
				returnString = returnString.Replace(c, "'");
			}

			returnString = returnString.Replace("\n", "`n");
			//returnString = returnString.Replace("'", "\\'");

			return returnString;
		}
	}
}
