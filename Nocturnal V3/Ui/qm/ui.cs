using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui.qm;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using VRC;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using Nocturnal.Settings;

namespace Nocturnal.Ui.qm
{
    internal class Ui
    {
        internal static Image _btnt;
        internal static UnityEngine.UI.Slider[] _sliderarray;

        internal static string _tochange;
        internal static void runui()
        {
            var uipg = submenu.Create("UI",Main._mainpage);
            new Submenubutton(Main._mainpage.Getmenu(), "UI", uipg, Settings.Download_Files.imagehandler.ui, false, 3, 0);
            new Apis.Slider(extensions.Getmenu(uipg), value => Settings.ConfigVars.espwidth = value, Settings.ConfigVars.espwidth, () => 
            {
                var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
                for (int i = 0; i < player.Count; i++)
                {
                    try
                    {
                        if (player[i].field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id) continue;
                        player[i].transform.Find("SelectRegion/ESP").gameObject.GetComponent<MeshRenderer>().materials[1].SetFloat("_Width", Settings.ConfigVars.espwidth);

                    }
                    catch { }
                }//_falloff
            }, true,"Esp Width");

            new Apis.Slider(extensions.Getmenu(uipg), value => Settings.ConfigVars.falloff = value, Settings.ConfigVars.falloff, () =>
            {
                var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
                for (int i = 0; i < player.Count; i++)
                {
                    try
                    {
                        if (player[i].field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id) continue;
                        player[i].transform.Find("SelectRegion/ESP").gameObject.GetComponent<MeshRenderer>().materials[1].SetFloat("_falloff", Settings.ConfigVars.falloff * 30);

                    }
                    catch { }
                }

            }, true, "Esp Falloff");
            new NToggle("Esp Size Distance", extensions.Getmenu(uipg), () =>
            {
                Settings.ConfigVars.EspSizeOverDistance = true;
                var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
                for (int i = 0; i < player.Count; i++)
                {
                    try
                    {
                        if (player[i].field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id) continue;
                        player[i].transform.Find("SelectRegion/ESP").gameObject.GetComponent<MeshRenderer>().materials[1].SetFloat("_ToggleSizeD", 1);

                    }
                    catch { }
                }
            }, () =>
            {
                var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
                for (int i = 0; i < player.Count; i++)
                {
                    try
                    {
                        if (player[i].field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id) continue;
                        player[i].transform.Find("SelectRegion/ESP").gameObject.GetComponent<MeshRenderer>().materials[1].SetFloat("_ToggleSizeD", 0);

                    }
                    catch { }
                }

                Settings.ConfigVars.EspSizeOverDistance = false;
            }, Settings.ConfigVars.EspSizeOverDistance);


            new NToggle("Thunder Big Ui", extensions.Getmenu(uipg), () =>
            {
                GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.GetComponent<Image>().material.SetFloat("postpr", 1);
                Settings.ConfigVars.thunderbigui = true;
            }, () =>
            {
                GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.GetComponent<Image>().material.SetFloat("postpr", 0);
                Settings.ConfigVars.thunderbigui = false;

            }, Settings.ConfigVars.thunderbigui);

            new NToggle("Debbuger", extensions.Getmenu(uipg), () =>
            {
                Settings.ConfigVars.qmdebug = true;
            }, () =>
            {
                Settings.ConfigVars.qmdebug = false;
            }, Settings.ConfigVars.qmdebug);

            new NToggle("Qm Music", extensions.Getmenu(uipg), () =>
            {
                Settings.ConfigVars.qmmusic = true;
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponent<AudioSource>().enabled = true;
            }, () =>
            {
                Settings.ConfigVars.qmmusic = false;
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponent<AudioSource>().enabled = false;
            }, Settings.ConfigVars.qmmusic);

            new NToggle("Player List", extensions.Getmenu(uipg), () =>
            {
                string obj = Settings.ConfigVars.rightsideplayerlist ? "Wing_Right" : "Wing_Left";
                GameObject.Find("/UserInterface").transform.Find($"Canvas_QuickMenu(Clone)/Container/Window/{obj}/Button/Playerlist").gameObject.SetActive(true);
                Settings.ConfigVars.playerlist = true;
            }, () =>
            {
                string obj = Settings.ConfigVars.rightsideplayerlist ? "Wing_Right" : "Wing_Left";
                GameObject.Find("/UserInterface").transform.Find($"Canvas_QuickMenu(Clone)/Container/Window/{obj}/Button/Playerlist").gameObject.SetActive(false);
                Settings.ConfigVars.playerlist = false;
            }, Settings.ConfigVars.playerlist);

            new NToggle("Player List Right side", extensions.Getmenu(uipg), () =>
            {
                Settings.ConfigVars.rightsideplayerlist = true;
                try
                {
                    var btn = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Playerlist").transform;
                    var path = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button").transform;
                    btn.transform.parent = path;
                    btn.localPosition = new Vector3(515, 0, 0);
                }
                catch { }
            }, () =>
            {
                Settings.ConfigVars.rightsideplayerlist = false;
                try
                {
                    var btn = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Playerlist").transform;
                    var path = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button").transform;
                    btn.transform.parent = path;
                    btn.transform.localPosition = new Vector3(-515, 0, 0);
                }
                catch { }
            }, Settings.ConfigVars.rightsideplayerlist);

            new NToggle("Qm Info Pannel", extensions.Getmenu(uipg), () =>
            {
                Settings.ConfigVars.qminfopannel = true;
                try
                {
                    Qm_basic._firsttext.transform.parent.parent.gameObject.SetActive(true);
                }
                catch { }
            }, () =>
            {
                Settings.ConfigVars.qminfopannel = false;
                try
                {
                    Qm_basic._firsttext.transform.parent.parent.gameObject.SetActive(false);
                }
                catch { }
            }, Settings.ConfigVars.qminfopannel);

            new NToggle("Rain Background", extensions.Getmenu(uipg), () =>
            {
                Settings.ConfigVars.rainbackground = true;
                try
                {
                    GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.SetActive(true);
                }
                catch { }
            }, () =>
            {
                Settings.ConfigVars.rainbackground = false;
                try
                {
                    GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.SetActive(false);
                }
                catch { }
            }, Settings.ConfigVars.rainbackground);

            new NToggle("Hud Info", extensions.Getmenu(uipg), () => {
                Settings.ConfigVars.hudUi = true;
                Qm_basic._GUIInfo.transform.parent.gameObject.SetActive(true);

            }, () => {
                Settings.ConfigVars.hudUi = false;
                Qm_basic._GUIInfo.transform.parent.gameObject.SetActive(false);


            }, Settings.ConfigVars.hudUi);

            new NToggle("Screen Logger", extensions.Getmenu(uipg), () => {

                Settings.ConfigVars.toggleonscreenlogger = true;
                GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ONscreennotui").gameObject.SetActive(true);

            }, () => {
                Settings.ConfigVars.toggleonscreenlogger = false;
                GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ONscreennotui").gameObject.SetActive(false);


            }, Settings.ConfigVars.toggleonscreenlogger);
            GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ONscreennotui").gameObject.SetActive(Settings.ConfigVars.toggleonscreenlogger);



            new NToggle("Join Leave Logs", extensions.Getmenu(uipg), () => {

                Settings.ConfigVars.joinnotif = true;

            }, () => {
                Settings.ConfigVars.joinnotif = false;
            }, Settings.ConfigVars.toggleonscreenlogger);
            GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ONscreennotui").gameObject.SetActive(Settings.ConfigVars.toggleonscreenlogger);

            new NToggle("Hud Ui", extensions.Getmenu(uipg), () => {

                Settings.ConfigVars.hudUi = true;
                Settings.Hooks._IsInVr = false;


            }, () => {
                Settings.ConfigVars.hudUi = false;
                Settings.Hooks._IsInVr = true;

            }, Settings.ConfigVars.hudUi);



            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var Colors = submenu.Create("Colors", Main._mainpage);
            new Submenubutton(Main._mainpage.Getmenu(), "Colors", Colors, Settings.Download_Files.imagehandler.Colors, false, 0, 1);


            new Apis.Slider(extensions.Getmenu(Colors), value => Settings.ConfigVars.BigImgOpacity = value, Settings.ConfigVars.BigImgOpacity, () =>
            {
                GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Rain(Clone)").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, Settings.ConfigVars.BigImgOpacity);
            }, true, "Big Img Opacity");
            
           new Apis.Slider(extensions.Getmenu(Colors), value => Settings.ConfigVars.debuggeropacity = value, Settings.ConfigVars.debuggeropacity, () =>
           {
               try
               {
                   GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/N_Debbuger/SupportVRChat/SupportVRChat(Clone)").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, Settings.ConfigVars.debuggeropacity);

               }
               catch { }
           }, true, "Debbuger Opacity");


            new Apis.Slider(extensions.Getmenu(Colors), value => Settings.ConfigVars.playelerlistopacity = value, Settings.ConfigVars.playelerlistopacity, () =>
            {
                if (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Playerlist/Playerlistmask/Playerlistmask(Clone)") != null)
                {
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Playerlist/Playerlistmask/Playerlistmask(Clone)").gameObject.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, Settings.ConfigVars.playelerlistopacity);
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Playerlist/Playerlistmask/Playerlistmask(Clone)(Clone)").gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, Settings.ConfigVars.playelerlistopacity);

                }

                else
                {
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Playerlist/Playerlistmask/Playerlistmask(Clone)").gameObject.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, Settings.ConfigVars.playelerlistopacity);
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Playerlist/Playerlistmask/Playerlistmask(Clone)(Clone)").gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, Settings.ConfigVars.playelerlistopacity);
 
                }


            }, true, "Player List Opacity");

            new Apis.Slider(extensions.Getmenu(Colors), value => Settings.ConfigVars.QMopacity = value, Settings.ConfigVars.QMopacity, () =>
            {
               Objects._qmbackground.transform.Find("_Background").gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, Settings.ConfigVars.QMopacity);
            }, true, "Qm Opacity");


            new NButton(extensions.Getmenu(Colors), "Big Image", () =>
           {
               XRefedMethods.PopOutInput("Big Image", value => Settings.ConfigVars.BiguiImg = value, () => {
                   MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                       GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Rain(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.BiguiImg
                       ));
               });

           }, false, null);
            new NButton(extensions.Getmenu(Colors), "Debbuger Image", () =>
           {
               try
               {
                   XRefedMethods.PopOutInput("Debbuger Image", value => Settings.ConfigVars.QmDebbugerImg = value, () => {
                       MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                           GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/N_Debbuger/SupportVRChat/SupportVRChat(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.QmDebbugerImg
                           ));
                   });
               }
               catch { }
          

           }, false, null);

             new NButton(extensions.Getmenu(Colors), "Qm Image", () =>
            {
                XRefedMethods.PopOutInput("Qm Image", value => Settings.ConfigVars.QmImg = value, () => {
                    MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                       Objects._qmbackground.transform.Find("_Background").gameObject.GetComponent<Image>(), Settings.ConfigVars.QmImg
                        )) ;
                });

            }, false, null);

            new NButton(extensions.Getmenu(Colors), "Playerlist Image", () =>
            {
                XRefedMethods.PopOutInput("Player List Image", value => Settings.ConfigVars.PlayerListImg = value, () => {

                    if (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Playerlist/Playerlistmask/Playerlistmask(Clone)") != null)
                    MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                        GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/Playerlist/Playerlistmask/Playerlistmask(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.PlayerListImg
                        ));
                    else
                        MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                     GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/Playerlist/Playerlistmask/Playerlistmask(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.PlayerListImg
                     ));
                });

            }, false, null);

          

            float r = 0;
            float g = 0;
            float b = 0;
            float a = 0;

            _sliderarray = new UnityEngine.UI.Slider[4];
            GameObject sliderR = null;
            new Apis.Slider(out sliderR, extensions.Getmenu(Colors), value => r = value, 0, () =>
           {
               if (_tochange == null)
                   return;
               extensions.setconfigfieldvalue(_tochange, new float[] { r, g, b, a });
               _btnt.color = new Color(r, g, b, a);
           }, true, "Red");
            _sliderarray[0] = sliderR.GetComponent<UnityEngine.UI.Slider>();

            GameObject sliderG = null;
            new Apis.Slider(out sliderG, extensions.Getmenu(Colors), value => g = value, 0, () =>
            {
                if (_tochange == null)
                    return;
                extensions.setconfigfieldvalue(_tochange, new float[] { r, g, b, a });
                _btnt.color = new Color(r, g, b, a);
            }, true, "Green");
            _sliderarray[1] = sliderG.GetComponent<UnityEngine.UI.Slider>();



            GameObject sliderB = null;
            new Apis.Slider(out sliderB, extensions.Getmenu(Colors), value => b = value, 0, () =>
            {
                if (_tochange == null)
                    return;
                extensions.setconfigfieldvalue(_tochange, new float[] { r, g, b, a });
                _btnt.color = new Color(r, g, b, a);
            }, true, "Blue");
            _sliderarray[2] = sliderB.GetComponent<UnityEngine.UI.Slider>();

            GameObject sliderA = null;
            new Apis.Slider(out sliderA, extensions.Getmenu(Colors), value => a = value, 0, () =>
           {
               if (_tochange == null)
                   return;
               extensions.setconfigfieldvalue(_tochange, new float[] { r, g, b, a });
               _btnt.color = new Color(r, g, b, a);
           }, true, "Alpha");
            _sliderarray[3] = sliderA.GetComponent<UnityEngine.UI.Slider>();



            GameObject bc;
            new NButton(out bc,extensions.Getmenu(Colors), "Color View(Refresh)", () =>
            {
                Nocturnal.Ui.uicolors.hudcolors();
                Nocturnal.Ui.uicolors.applybutton();
                Nocturnal.Ui.uicolors.ApplyText();

                var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
                for (int i = 0; i < player.Count; i++)
                {
                    try
                    {
                        if (player[i].field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id) continue;
               
                            string empt = "";
                        Color outlinecolor = Color.white;
                        Settings.wrappers.Ranks.gettrsutrank(player[i].field_Private_APIUser_0, ref empt, ref outlinecolor);
                            if (player[i].IsFriend())
                                outlinecolor = new Color(Settings.ConfigVars.friend[0], Settings.ConfigVars.friend[1], Settings.ConfigVars.friend[2], Settings.ConfigVars.friend[3]);
                            player[i].transform.Find("SelectRegion/ESP").gameObject.GetComponent<UnityEngine.MeshRenderer>().materials[1].SetColor("_Color", outlinecolor);

                        

                    }
                    catch { }
                }







            });
            bc.transform.Find("Icon").gameObject.SetActive(false);
            Component.DestroyImmediate(bc.gameObject.transform.Find("Background").GetComponent<Image>());
            _btnt = bc.gameObject.transform.Find("Background").gameObject.AddComponent<Image>();
            _btnt.sprite = null;

             new NButton(extensions.Getmenu(Colors), "Client Chat Image", () =>
            {
                XRefedMethods.PopOutInput("Qm Image", value => Settings.ConfigVars.chatimage = value, () => {
                    MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                      GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/_Submenu_Client Chat/Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup/_Button_/Background/Background(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.chatimage
                        ));
                });

            }, false, null);


            new NButton(extensions.Getmenu(Colors), "Friends", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.friend[0], Settings.ConfigVars.friend[1], Settings.ConfigVars.friend[2], Settings.ConfigVars.trusted[3]);
                _tochange = nameof(Settings.ConfigVars.friend);
                csliderv(Settings.ConfigVars.friend);

            },true);

             new NButton(extensions.Getmenu(Colors), "Visitor", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.visitor[0], Settings.ConfigVars.visitor[1], Settings.ConfigVars.visitor[2], Settings.ConfigVars.trusted[3]);
                _tochange = nameof(Settings.ConfigVars.visitor);
                csliderv(Settings.ConfigVars.visitor);

            }, true);

            new NButton(extensions.Getmenu(Colors), "New User", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.newuser[0], Settings.ConfigVars.newuser[1], Settings.ConfigVars.newuser[2], Settings.ConfigVars.trusted[3]);
                _tochange = nameof(Settings.ConfigVars.newuser);
                csliderv(Settings.ConfigVars.newuser);

            }, true);

             new NButton(extensions.Getmenu(Colors), "User", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.user[0], Settings.ConfigVars.user[1], Settings.ConfigVars.user[2], Settings.ConfigVars.trusted[3]);
                _tochange = nameof(Settings.ConfigVars.user);
                csliderv(Settings.ConfigVars.user);

            }, true);

             new NButton(extensions.Getmenu(Colors), "Known User", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.known[0], Settings.ConfigVars.known[1], Settings.ConfigVars.known[2], Settings.ConfigVars.trusted[3]);
                _tochange = nameof(Settings.ConfigVars.known);
                csliderv(Settings.ConfigVars.known);

            }, true);

             new NButton(extensions.Getmenu(Colors), "Trusted", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.trusted[0], Settings.ConfigVars.trusted[1], Settings.ConfigVars.trusted[2], Settings.ConfigVars.trusted[3]);
                _tochange = nameof(Settings.ConfigVars.trusted);
                csliderv(Settings.ConfigVars.trusted);

            }, true);

           
             new NButton(extensions.Getmenu(Colors), "Super Powers", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.superpowers[0], Settings.ConfigVars.superpowers[1], Settings.ConfigVars.superpowers[2], Settings.ConfigVars.superpowers[3]);
                _tochange = nameof(Settings.ConfigVars.superpowers);
                csliderv(Settings.ConfigVars.superpowers);

            }, true);

             new NButton(extensions.Getmenu(Colors), "Moderator", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.Moderator[0], Settings.ConfigVars.Moderator[1], Settings.ConfigVars.Moderator[2], Settings.ConfigVars.Moderator[3]);
                _tochange = nameof(Settings.ConfigVars.Moderator);
                csliderv(Settings.ConfigVars.Moderator);

            }, true);

             new NButton(extensions.Getmenu(Colors), "Hud", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.HuDColor[0], Settings.ConfigVars.HuDColor[1], Settings.ConfigVars.HuDColor[2], Settings.ConfigVars.HuDColor[3]);
                _tochange = nameof(Settings.ConfigVars.HuDColor);
                csliderv(Settings.ConfigVars.HuDColor);

            }, true);
             new NButton(extensions.Getmenu(Colors), "Buttons", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.ButtonColor[0], Settings.ConfigVars.ButtonColor[1], Settings.ConfigVars.ButtonColor[2], Settings.ConfigVars.ButtonColor[3]);
                _tochange = nameof(Settings.ConfigVars.ButtonColor);
                csliderv(Settings.ConfigVars.ButtonColor);

            }, true);
             new NButton(extensions.Getmenu(Colors), "Text", () =>
            {
                _btnt.color = new Color(Settings.ConfigVars.textcolor[0], Settings.ConfigVars.textcolor[1], Settings.ConfigVars.textcolor[2], Settings.ConfigVars.textcolor[3]);
                _tochange = nameof(Settings.ConfigVars.textcolor);
                csliderv(Settings.ConfigVars.textcolor);

            }, true);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }
        private static void csliderv(float[] flarray)
        {
            _sliderarray[0].value = flarray[0];
            _sliderarray[1].value = flarray[1];
            _sliderarray[2].value = flarray[2];
            _sliderarray[3].value = flarray[3];
        }

    }
}
