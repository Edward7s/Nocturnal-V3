using UnityEngine;
namespace Nocturnal.Ui
{
	internal class Objects
	{
		internal static VRC.UI.FriendsListManager friendListManager;
		internal static UnityEngine.UI.Text onlineFriendsText;
		internal static GameObject userInfoPannel;
		internal static GameObject bigButton;
		internal static NotificationManager notManager;
		internal static UnityEngine.UI.Text friendRequests;
		//   internal static UnityEngine.UI.Text group1;
		//  internal static UnityEngine.UI.Text group2;
		//  internal static UnityEngine.UI.Text group3;
		internal static UnityEngine.UI.Text offlinefriends;
		internal static GameObject scrollbarObj;
		internal static GameObject page;
		internal static GameObject submenu;
		internal static GameObject buttonPrefab;
		internal static GameObject togglePrefab;
		internal static GameObject qmBackground;
		internal static GameObject qmExpand;
		internal static UnityEngine.UI.Text trustRankText;

		internal static void FindObjects()
		{
			friendListManager = GameObject.Find("/_Application/FriendsListManager").gameObject.GetComponent<VRC.UI.FriendsListManager>();

			onlineFriendsText = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OnlineFriends/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

			userInfoPannel = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject;

			bigButton = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/Buttons/RightSideButtons/RightUpperButtonColumn/EditBioButton").gameObject;

			notManager = GameObject.Find("/_Application/").transform.Find("NotificationManager").gameObject.GetComponent<NotificationManager>();

			friendRequests = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendRequests/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

			//     group1 = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FavoriteContent/group_0/EditButton/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

			//    group2 = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FavoriteContent/group_1/EditButton/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

			//    group3 = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FavoriteContent/group_2/EditButton/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

			offlinefriends = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OfflineFriends/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

			scrollbarObj = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Scrollbar").gameObject;

			page = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools").gameObject;

			submenu = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools").gameObject;

			buttonPrefab = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/Button_WarpAllToHub").gameObject;

			togglePrefab = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_2/Button_ToggleFallbackIcon").gameObject;

			qmBackground = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").gameObject;

			qmExpand = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Expand").gameObject;

			trustRankText = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/User Panel/TrustLevel/TrustText").gameObject.GetComponent<UnityEngine.UI.Text>();
		}
	}
}
