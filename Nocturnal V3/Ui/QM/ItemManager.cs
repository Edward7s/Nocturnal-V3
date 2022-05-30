using Nocturnal.Apis.QM;
using Nocturnal.Settings.Wrappers;
using System.Collections.Generic;
using UnityEngine;
using VRC.SDKBase;

namespace Nocturnal.Ui.QM
{
	internal class ItemManager
	{
		static GameObject bring;
		static GameObject create;
		internal static void CreateUI()
		{
			var itemManager = SubMenu.Create("ItemManager", Main.mainPage);
			Main.mainPage.GetMenu().Create("Item Manager", itemManager, null, true, 2, 5);

			bring = SubMenu.Create("BringPickups", itemManager);
			create = SubMenu.Create("CreateObject", itemManager);

			itemManager.GetMenu().Create("Bring to you", bring);
			itemManager.GetMenu().Create("Create Object", create);
		}
		internal static void Refresh()
		{
			foreach (var b in buttons)
				GameObject.Destroy(b);

			CreateBring(bring.GetMenu());
			CreateCreate(create.GetMenu());
		}
		internal static List<GameObject> buttons = new List<GameObject>();
		internal static void CreateBring(GameObject menu)
		{
			if (Exploits.Pickups.pickupsobs != null)
				foreach (var obj in Exploits.Pickups.pickupsobs)
				{
					buttons.Add(Button.Create(menu, obj.name, () =>
					{
						Networking.SetOwner(Networking.LocalPlayer, obj.gameObject);
						if (VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Internal_Animator_0.isHuman)
							obj.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Internal_Animator_0.GetBoneTransform(HumanBodyBones.RightHand).position;
						else
							obj.transform.position = VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0, 1, 0);
					}));
				}
		}
		internal static void CreateCreate(GameObject menu)
		{
			if (VRC_SceneDescriptor._instance != null && VRC_SceneDescriptor._instance.DynamicPrefabs != null)
				foreach (var obj in VRC_SceneDescriptor._instance.DynamicPrefabs)
				{
					buttons.Add(Button.Create(menu, obj.name, () =>
					{
						Networking.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, obj.name,
						(VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Internal_Animator_0.isHuman ? VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Internal_Animator_0.GetBoneTransform(HumanBodyBones.RightHand).position : VRCPlayer.field_Internal_Static_VRCPlayer_0.transform.position + new Vector3(0, 1, 0)),
						Quaternion.identity);
					}));
				}
		}
	}
}
