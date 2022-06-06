using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Nocturnal.Ui
{
    internal class Objects
    {
        internal static VRC.UI.FriendsListManager _friendlistmanager;
        internal static UnityEngine.UI.Text _onlinefriendstext;
        internal static GameObject _userinfpannel;
        internal static GameObject _Bbutton;
        internal static NotificationManager _notmanager;
        internal static UnityEngine.UI.Text _friendreqeusts;
     //   internal static UnityEngine.UI.Text group1;
      //  internal static UnityEngine.UI.Text group2;
      //  internal static UnityEngine.UI.Text group3;
        internal static UnityEngine.UI.Text _offlinefriends;
        internal static GameObject _Scrollbargmj;
        internal static GameObject _Page;
        internal static GameObject _Submenu;
        internal static GameObject _ButtonPrefab;
        internal static GameObject _TogglePrebab;
        internal static GameObject _qmbackground;
        internal static GameObject _qmexpand;
        internal static UnityEngine.UI.Text _trustranktext;

        internal static void Collectobjs()
        {
            _friendlistmanager = GameObject.Find("/_Application/FriendsListManager").gameObject.GetComponent<VRC.UI.FriendsListManager>();

            _onlinefriendstext = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OnlineFriends/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            _userinfpannel = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject;

            _Bbutton = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/Buttons/RightSideButtons/RightUpperButtonColumn/EditBioButton").gameObject;

            _notmanager = GameObject.Find("/_Application/").transform.Find("NotificationManager").gameObject.GetComponent<NotificationManager>();

            _friendreqeusts = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendRequests/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            //     group1 = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FavoriteContent/group_0/EditButton/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            //    group2 = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FavoriteContent/group_1/EditButton/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            //    group3 = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FavoriteContent/group_2/EditButton/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            _offlinefriends = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OfflineFriends/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            _Scrollbargmj = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Scrollbar").gameObject;

            _Page = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools").gameObject;

            _Submenu = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools").gameObject;

            _ButtonPrefab = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/Button_WarpAllToHub").gameObject;

            _TogglePrebab = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_2/Button_ToggleFallbackIcon").gameObject;

            _qmbackground = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").gameObject;

            _qmexpand = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Expand").gameObject;

            _trustranktext = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/User Panel/TrustLevel/TrustText").gameObject.GetComponent<UnityEngine.UI.Text>();
        }
    }
}
