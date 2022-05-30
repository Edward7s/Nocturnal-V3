using System;
using UnityEngine;
namespace Nocturnal.MonoBehaviours
{
	internal class PageManager : MonoBehaviour
	{
		public PageManager(IntPtr ptr) : base(ptr)
		{

		}
		public void OnEnable()
		{
			// NocturnalC.log($"Opend: {this.gameObject.name}");
			switch (true)
			{
				case true when this.name == "Social":
					Ui.Objects.onlineFriendsText.text = $"Online Friends        [{Ui.Objects.friendListManager.field_Private_List_1_IUser_1.Count} / {Ui.Objects.friendListManager.field_Private_List_1_IUser_0.Count}]";
					Ui.Objects.friendRequests.text = $"Friend Requests        [{Ui.Objects.notManager.field_Private_List_1_InterfacePublicAbstractStOb1StTeVaSt1Te2Unique_1.Count}]";
					//  Ui.objects.group1.text = Ui.objects.friendlistmanager.prop_String_0 + $"  [{Ui.objects.friendlistmanager.field_Private_List_1_IUser_3.Count} / 64]";
					//  Ui.objects.group2.text = Ui.objects.friendlistmanager.prop_String_1 + $"  [{Ui.objects.friendlistmanager.field_Private_List_1_IUser_4.Count} / 64]";
					//  Ui.objects.group3.text = Ui.objects.friendlistmanager.prop_String_2 + $"  [{Ui.objects.friendlistmanager.field_Private_List_1_IUser_5.Count} / 64]";
					Ui.Objects.offlinefriends.text = $"Offline Friends (Expand to Show)        [{Ui.Objects.friendListManager.prop_List_1_IUser_2.Count}]";
					break;
				case true when this.name == "UserInfo":

					break;
				case true when this.name == "WorldInfo":
					break;

				case true when this.name == "Menu_SelectedUser_Local":
					break;
				case true when this.name == "Canvas_QuickMenu(Clone)":
					Ui.QMBasic.firstText.text = string.Format("{0:hh:mm:ss tt}", DateTime.Now);
					Ui.QMBasic.ThirdText.text = $"Friends: {Ui.Objects.friendListManager.field_Private_List_1_IUser_1.Count}/{Ui.Objects.friendListManager.field_Private_List_1_IUser_0.Count}";
					var getm = new Settings.JsonManager.custommsg()
					{
						code = "87",
						msg = "Getonlineclients",
					};
					Server.Setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(getm));
					break;
			}
		}
	}
}
