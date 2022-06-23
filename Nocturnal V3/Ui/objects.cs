using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI;

namespace Nocturnal.Ui
{
    internal class Objects
    {
        internal static VRC.UI.FriendsListManager _friendlistmanager { get; set; }
        internal static UnityEngine.UI.Text _onlinefriendstext { get; set; }
        internal static GameObject _userinfpannel { get; set; }
        internal static GameObject _Bbutton { get; set; }
        internal static NotificationManager _notmanager { get; set; }
        internal static UnityEngine.UI.Text _friendreqeusts { get; set; }
        //   internal static UnityEngine.UI.Text group1{ get; set; }
        //  internal static UnityEngine.UI.Text group2{ get; set; }
        //  internal static UnityEngine.UI.Text group3{ get; set; }
        internal static UnityEngine.UI.Text _offlinefriends { get; set; }
        internal static GameObject _Scrollbargmj { get; set; }
        internal static GameObject _Page { get; set; }
        internal static GameObject _Submenu { get; set; }
        internal static GameObject _ButtonPrefab { get; set; }
        internal static GameObject _TogglePrebab { get; set; }
        internal static GameObject _qmbackground { get; set; }
        internal static GameObject _QMexpand { get; set; }
        internal static UnityEngine.UI.Text _trustranktext { get; set; }
        internal static GameObject _QuickMenuCanvas { get; set; }
        internal static PageAvatar _AvatarPage { get; set; }

        internal static GameObject _HudMesh { get; set; }
        internal static Il2CppSystem.Collections.Generic.List<VRC.DataModel.IUser> _OnlineFriends { get; set; }
        internal static Il2CppSystem.Collections.Generic.List<VRC.DataModel.IUser> _OfflineFriends { get; set; }

        internal static InputField _InputField { get; set; }
        internal static void Collectobjs()
        {

            _InputField = GameObject.Find("/UserInterface").transform.Find("MenuContent/Popups/InputPopup/InputField").gameObject.GetComponent<InputField>();
            _AvatarPage = GameObject.Find("Screens").transform.Find("Avatar").GetComponent<PageAvatar>();

            _HudMesh = GameObject.Find("/UserInterface").transform.Find("PlayerDisplay/WorldHudDisplay/MenuMesh").gameObject;

            _QuickMenuCanvas = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject;

            _friendlistmanager = GameObject.Find("/_Application/FriendsListManager").gameObject.GetComponent<FriendsListManager>();

            _OnlineFriends = _friendlistmanager.field_Private_List_1_IUser_1;

            _OfflineFriends = _friendlistmanager.field_Private_List_1_IUser_0;

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

            _QMexpand = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Expand").gameObject;

            _trustranktext = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/User Panel/TrustLevel/TrustText").gameObject.GetComponent<UnityEngine.UI.Text>();
        }
    }
}
