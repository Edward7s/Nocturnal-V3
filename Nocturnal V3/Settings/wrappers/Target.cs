using System.Linq;
using UnityEngine;
using VRC;

namespace Nocturnal.Settings.Wrappers
{
	internal class Target
	{
		internal static VRC.Player targetUser;
		private static GameObject targetPlate;

		internal static void TargetUser(string userid)
		{
			if (targetPlate != null)
				GameObject.DestroyImmediate(targetPlate);

			var players = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray().Where(player => player.field_Private_APIUser_0.id == userid).FirstOrDefault();
			targetUser = players;
			targetPlate = players._vrcplayer.GeneratePlate("<color=red>Targeted");
		}
	}
}

