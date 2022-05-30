using UnityEngine;
using VRC.Core;
namespace Nocturnal.Settings.Wrappers
{
	internal class Ranks
	{
		internal static void GetTrustRank(APIUser player, ref string rank, ref Color color)
		{
			if (player != null)
			{
				player.Fetch();
				var str = "";
				foreach (var tag in player.tags)
				{
					str += tag;
				}
				rank = "Visitor";
				switch (true)
				{
					case true when player.hasModerationPowers:
						rank = "Moderator";
						color = new Color(ConfigVars.Moderator[0], ConfigVars.Moderator[1], ConfigVars.Moderator[2], ConfigVars.Moderator[3]);
						break;
					case true when player.hasSuperPowers:
						rank = "Super powers";
						color = new Color(ConfigVars.superpowers[0], ConfigVars.superpowers[1], ConfigVars.superpowers[2], ConfigVars.superpowers[3]);
						break;
					case true when str.Contains("system_trust_veteran"):
						rank = "Trusted";
						color = new Color(ConfigVars.trusted[0], ConfigVars.trusted[1], ConfigVars.trusted[2], ConfigVars.trusted[3]);
						break;
					case true when str.Contains("system_trust_trusted"):
						rank = "Known";
						color = new Color(ConfigVars.known[0], ConfigVars.known[1], ConfigVars.known[2], ConfigVars.known[3]);
						break;
					case true when str.Contains("system_trust_known"):
						rank = "User";
						color = new Color(ConfigVars.user[0], ConfigVars.user[1], ConfigVars.user[2], ConfigVars.user[3]);
						break;
					case true when str.Contains("system_trust_basic"):
						rank = "New User";
						color = new Color(ConfigVars.newuser[0], ConfigVars.newuser[1], ConfigVars.newuser[2], ConfigVars.newuser[3]);
						break;
					case true when player.hasNegativeTrustLevel:
						rank = "Visitor";
						color = new Color(ConfigVars.visitor[0], ConfigVars.visitor[1], ConfigVars.visitor[2], ConfigVars.visitor[3]);
						break;
					case true when player.hasVeryNegativeTrustLevel:
						rank = "Nuisance";
						color = Color.red;
						break;
				}
			}
		}


#pragma warning disable CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
		internal static void ConvertToColorRank(ref string rank, ref string? changestringcolor)
#pragma warning restore CS8632 // The annotation for nullable reference types should only be used in code within a '#nullable' annotations context.
		{
			switch (rank)
			{
				case "Moderator":
					rank = "<color=#ff0000ff>Moderator</color>";
					if (changestringcolor != null)
						changestringcolor = $"<color=#ff0000ff>{changestringcolor}</color>";
					break;
				case "Super powers":
					rank = "<color=#ffa500ff>Super powers</color>";
					if (changestringcolor != null)
						changestringcolor = $"<color=#ffa500ff>{changestringcolor}</color>";
					break;
				case "Legendary":
					rank = "<color=#00ffffff>Legendary</color>";
					if (changestringcolor != null)
						changestringcolor = $"<color=#00ffffff>{changestringcolor}</color>";
					break;
				case "Veteran":
					rank = "<color=#808000ff>Veteran</color>";
					if (changestringcolor != null)
						changestringcolor = $"<color=#808000ff>{changestringcolor}</color>";

					break;
				case "Trusted":
					rank = "<color=#800080ff>Trusted</color>";
					if (changestringcolor != null)
						changestringcolor = $"<color=#800080ff>{changestringcolor}</color>";
					break;
				case "Known":
					rank = "<color=#ffa500ff>Known</color>";
					if (changestringcolor != null)
						changestringcolor = $"<color=#ffa500ff>{changestringcolor}</color>";
					break;
				case "User":
					rank = "<color=#008000ff>User</color>";
					if (changestringcolor != null)
						changestringcolor = $"<color=#008000ff>{changestringcolor}</color>";
					break;
				case "New User":
					rank = "<color=#00ffffff>New User</color>";
					if (changestringcolor != null)
						changestringcolor = $"<color=#00ffffff>{changestringcolor}</color>";
					break;
				case "Visitor":
					rank = "Visitor";
					if (changestringcolor != null)
						changestringcolor = $"{changestringcolor}";
					break;
				case "Nuisance":
					rank = "<color=#800000ff>Nuisance</color>";
					if (changestringcolor != null)
						changestringcolor = $"<color=#800000ff>{changestringcolor}</color>";
					break;
			}
		}
	}
}
