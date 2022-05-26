using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Nocturnal.Ui
{
    internal class objects
    {
        internal static VRC.UI.FriendsListManager friendlistmanager;
        internal static UnityEngine.UI.Text onlinefriendstext;
        internal static GameObject userinfpannel;
        internal static GameObject Bbutton;
        internal static NotificationManager notmanager;
        internal static UnityEngine.UI.Text friendreqeusts;
     //   internal static UnityEngine.UI.Text group1;
      //  internal static UnityEngine.UI.Text group2;
      //  internal static UnityEngine.UI.Text group3;
        internal static UnityEngine.UI.Text offlinefriends;
        internal static GameObject Scrollbargmj;
        internal static GameObject Page;
        internal static GameObject Submenu;
        internal static GameObject ButtonPrefab;
        internal static GameObject TogglePrebab;
        internal static GameObject qmbackground;
        internal static GameObject qmexpand;
        internal static UnityEngine.UI.Text trustranktext;

        internal static void collectobjs()
        {
            friendlistmanager = GameObject.Find("/_Application/FriendsListManager").gameObject.GetComponent<VRC.UI.FriendsListManager>();

            onlinefriendstext = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OnlineFriends/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            userinfpannel = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject;

            Bbutton = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/Buttons/RightSideButtons/RightUpperButtonColumn/EditBioButton").gameObject;

            notmanager = GameObject.Find("/_Application/").transform.Find("NotificationManager").gameObject.GetComponent<NotificationManager>();

           friendreqeusts = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendRequests/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

           //     group1 = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FavoriteContent/group_0/EditButton/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            //    group2 = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FavoriteContent/group_1/EditButton/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            //    group3 = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FavoriteContent/group_2/EditButton/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            offlinefriends = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OfflineFriends/Button/TitleText").gameObject.GetComponent<UnityEngine.UI.Text>();

            Scrollbargmj = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Scrollbar").gameObject;

            Page = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools").gameObject;

            Submenu = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools").gameObject;

            ButtonPrefab = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/Scrollrect/Viewport/VerticalLayoutGroup/Buttons/Button_WarpAllToHub").gameObject;

            TogglePrebab = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_2/Button_ToggleFallbackIcon").gameObject;

            qmbackground = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer01").gameObject;
            
              qmexpand = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Expand").gameObject;

            trustranktext = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo/User Panel/TrustLevel/TrustText").gameObject.GetComponent<UnityEngine.UI.Text>();
        }
    }
}
