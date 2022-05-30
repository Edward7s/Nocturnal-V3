using System;

namespace Nocturnal.Settings
{
	internal static class JsonManager
	{
		[Serializable]
		internal class worldhistory
		{
			public string worldname { get; set; }

			public string worldid { get; set; }
		}
		internal class custommsg
		{
			public string msg { get; set; }

			public string code { get; set; }
		}

		internal class custommsgarr
		{
			public custommsg2[] msg { get; set; }

			public string code { get; set; }
		}

		internal class custommsg2
		{
			public string msg { get; set; }
			public string msg2 { get; set; }

			public string code { get; set; }
		}
		internal class reciveplate
		{
			public string code { get; set; }

			public string userid { get; set; }

			public string[] tagslist { get; set; }
		}

		internal class discordrpc
		{
			public string Details { get; set; }

			public string State { get; set; }

			public string LargeImage { get; set; }

			public bool ison { get; set; }

		}



	}


}
