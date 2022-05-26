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
namespace Nocturnal.Ui.qm
{
    internal class ui
    {
        internal static Image btnt;
        internal static UnityEngine.UI.Slider[] sliderarray;

        internal static string tochange;
        internal static void runui()
        {
            var uipg = submenu.Submenu("UI",Main.mainpage);
            Main.mainpage.getmenu().submenu("UI",uipg, Settings.Download_Files.ui, false, 3, 0);

            Apis.Slider.slider(extensions.getmenu(uipg), value => Settings.ConfigVars.espwidth = value, Settings.ConfigVars.espwidth, () => 
            {
                var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
                for (int i = 0; i < player.Count; i++)
                {
                    try
                    {
                        if (player[i].field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id) continue;
                        player[i].transform.Find("SelectRegion/ESP").gameObject.GetComponent<UnityEngine.MeshRenderer>().materials[1].SetFloat("_Width", Settings.ConfigVars.espwidth);

                    }
                    catch { }
                }//_falloff
            }, true,"Esp Width");

            Apis.Slider.slider(extensions.getmenu(uipg), value => Settings.ConfigVars.falloff = value, Settings.ConfigVars.falloff, () =>
            {
                var player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0;
                for (int i = 0; i < player.Count; i++)
                {
                    try
                    {
                        if (player[i].field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id) continue;
                        player[i].transform.Find("SelectRegion/ESP").gameObject.GetComponent<UnityEngine.MeshRenderer>().materials[1].SetFloat("_falloff", Settings.ConfigVars.falloff * 30);

                    }
                    catch { }
                }

            }, true, "Esp Falloff");

            Apis.qm.Toggle.toggle("Thunder Big Ui", extensions.getmenu(uipg), () =>
            {
                GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.GetComponent<Image>().material.SetFloat("postpr", 1);
                Settings.ConfigVars.thunderbigui = true;
            }, () =>
            {
                GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.GetComponent<Image>().material.SetFloat("postpr", 0);
                Settings.ConfigVars.thunderbigui = false;

            }, Settings.ConfigVars.thunderbigui);

            Apis.qm.Toggle.toggle("Debbuger", extensions.getmenu(uipg), () =>
            {
                Settings.ConfigVars.qmdebug = true;
            }, () =>
            {
                Settings.ConfigVars.qmdebug = false;

            }, Settings.ConfigVars.qmdebug);

            Apis.qm.Toggle.toggle("Qm Music", extensions.getmenu(uipg), () =>
            {
                Settings.ConfigVars.qmmusic = true;
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponent<AudioSource>().enabled = true;
            }, () =>
            {
                Settings.ConfigVars.qmmusic = false;
                GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.GetComponent<AudioSource>().enabled = false;

            }, Settings.ConfigVars.qmmusic);

            Apis.qm.Toggle.toggle("Player List", extensions.getmenu(uipg), () =>
            {

                string obj = Settings.ConfigVars.rightsideplayerlist ? "Wing_Right" : "Wing_Left";
                    GameObject.Find("/UserInterface").transform.Find($"Canvas_QuickMenu(Clone)/Container/Window/{obj}/Button/VRC+_Banners(Clone)").gameObject.SetActive(true);

                Settings.ConfigVars.playerlist = true;

            }, () =>
            {
                string obj = Settings.ConfigVars.rightsideplayerlist ? "Wing_Right" : "Wing_Left";

                GameObject.Find("/UserInterface").transform.Find($"Canvas_QuickMenu(Clone)/Container/Window/{obj}/Button/VRC+_Banners(Clone)").gameObject.SetActive(false);
                Settings.ConfigVars.playerlist = false;

            }, Settings.ConfigVars.playerlist);

            Apis.qm.Toggle.toggle("Player List Right side", extensions.getmenu(uipg), () =>
            {
                Settings.ConfigVars.rightsideplayerlist = true;
                try
                {
                    var btn = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/VRC+_Banners(Clone)").transform;
                    var path = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button").transform;
                    btn.transform.parent = path;
                    btn.transform.Find("Mask").transform.localPosition = new Vector3(1150, -534, 0);
                  
                }
                catch { }
             
            }, () =>
            {
                Settings.ConfigVars.rightsideplayerlist = false;

                try
                {
                    var btn = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/VRC+_Banners(Clone)").transform;
                    var path = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button").transform;
                    btn.transform.parent = path;
                    btn.transform.Find("Mask").transform.localPosition = new Vector3(-967, -512, 0);
                    btn.transform.localPosition = new Vector3(457, 1035, 1);
                    //457 1035 1
                }
                catch { }
              
            }, Settings.ConfigVars.rightsideplayerlist);

            Apis.qm.Toggle.toggle("Qm Info Pannel", extensions.getmenu(uipg), () =>
            {
                Settings.ConfigVars.qminfopannel = true;
                try
                {
                    Ui.Qm_basic.firsttext.transform.parent.parent.gameObject.SetActive(true);
                }
                catch { }


            }, () =>
            {
                Settings.ConfigVars.qminfopannel = false;
                try
                {
                    Ui.Qm_basic.firsttext.transform.parent.parent.gameObject.SetActive(false);
                }
                catch { }

            }, Settings.ConfigVars.qminfopannel);

            Apis.qm.Toggle.toggle("Rain Background", extensions.getmenu(uipg), () =>
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
                    GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Image").gameObject.SetActive(false );
                }
                catch { }

            }, Settings.ConfigVars.rainbackground);

            Apis.qm.Toggle.toggle("Hud Info", extensions.getmenu(uipg), () => {
                Settings.ConfigVars.hudUi = true;
                Ui.Qm_basic.GUIInfo.transform.parent.gameObject.SetActive(true);

            }, () => {
                Settings.ConfigVars.hudUi = false;
                Ui.Qm_basic.GUIInfo.transform.parent.gameObject.SetActive(false);


            }, Settings.ConfigVars.hudUi);

            Apis.qm.Toggle.toggle("Screen Logger", extensions.getmenu(uipg), () => {

                Settings.ConfigVars.toggleonscreenlogger = true;
                GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ONscreennotui").gameObject.SetActive(true);

            }, () => {
                Settings.ConfigVars.toggleonscreenlogger = false;
                GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ONscreennotui").gameObject.SetActive(false);


            }, Settings.ConfigVars.toggleonscreenlogger);
            GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/ONscreennotui").gameObject.SetActive(Settings.ConfigVars.toggleonscreenlogger);



            //VRC+_Banners(Clone)

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////
            var Colors = submenu.Submenu("Colors", Main.mainpage);
            Main.mainpage.getmenu().submenu("Colors", Colors, Settings.Download_Files.Colors, false, 0, 1);

           Apis.Slider.slider(extensions.getmenu(Colors), value => Settings.ConfigVars.BigImgOpacity = value, Settings.ConfigVars.BigImgOpacity, () =>
            {
                GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Rain(Clone)").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, Settings.ConfigVars.BigImgOpacity);
            }, true, "Big Img Opacity");
            
           Apis.Slider.slider(extensions.getmenu(Colors), value => Settings.ConfigVars.debuggeropacity = value, Settings.ConfigVars.debuggeropacity, () =>
           {
               try
               {
                   GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/N_Debbuger/SupportVRChat/SupportVRChat(Clone)").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, Settings.ConfigVars.debuggeropacity);

               }
               catch { }
           }, true, "Debbuger Opacity");


            Apis.Slider.slider(extensions.getmenu(Colors), value => Settings.ConfigVars.playelerlistopacity = value, Settings.ConfigVars.playelerlistopacity, () =>
            {
                if (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)") != null)
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)").gameObject.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, Settings.ConfigVars.playelerlistopacity);

                else
                    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)").gameObject.GetComponent<Image>().color = new Color(0.7f, 0.7f, 0.7f, Settings.ConfigVars.playelerlistopacity);


            }, true, "Player List Opacity");

            Apis.Slider.slider(extensions.getmenu(Colors), value => Settings.ConfigVars.QMopacity = value, Settings.ConfigVars.QMopacity, () =>
            {
               objects.qmbackground.transform.Find("_Background").gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f, Settings.ConfigVars.QMopacity);
            }, true, "Qm Opacity");


            Buttons.Button(extensions.getmenu(Colors), "Big Image", () =>
           {
               Apis.inputpopout.run("Big Image", value => Settings.ConfigVars.BiguiImg = value, () => {
                   MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                       GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop/Rain/Rain(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.BiguiImg
                       ));
               });

           }, false, null);
           Buttons.Button(extensions.getmenu(Colors), "Debbuger Image", () =>
           {
               try
               {
                   Apis.inputpopout.run("Debbuger Image", value => Settings.ConfigVars.QmDebbugerImg = value, () => {
                       MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                           GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/N_Debbuger/SupportVRChat/SupportVRChat(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.QmDebbugerImg
                           ));
                   });
               }
               catch { }
          

           }, false, null);

            Buttons.Button(extensions.getmenu(Colors), "Qm Image", () =>
            {
                Apis.inputpopout.run("Qm Image", value => Settings.ConfigVars.QmImg = value, () => {
                    MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                       objects.qmbackground.transform.Find("_Background").gameObject.GetComponent<Image>(), Settings.ConfigVars.QmImg
                        )) ;
                });

            }, false, null);

            Buttons.Button(extensions.getmenu(Colors), "Playerlist Image", () =>
            {
                Apis.inputpopout.run("Player List Image", value => Settings.ConfigVars.PlayerListImg = value, () => {

                    if (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)") != null)
                    MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                        GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.PlayerListImg
                        ));
                    else
                        MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                     GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button/VRC+_Banners(Clone)/Mask/Mask(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.PlayerListImg
                     ));
                });

            }, false, null);

          

            float r = 0;
            float g = 0;
            float b = 0;
            float a = 0;

            sliderarray = new UnityEngine.UI.Slider[4];

            sliderarray[0] = Apis.Slider.slider(extensions.getmenu(Colors), value => r = value, 0, () =>
            {
                if (tochange == null)
                    return;
                extensions.setconfigfieldvalue(tochange, new float[] { r, g, b ,a});
                btnt.color = new Color(r, g, b,a);
            }, true, "Red").GetComponent<UnityEngine.UI.Slider>();

            sliderarray[1]= Apis.Slider.slider(extensions.getmenu(Colors), value => g = value, 0, () =>
            {
                if (tochange == null)
                    return;
                extensions.setconfigfieldvalue(tochange, new float[] { r, g, b ,a});
                btnt.color = new Color(r, g, b,a);
            }, true, "Green").GetComponent<UnityEngine.UI.Slider>();

            sliderarray[2] = Apis.Slider.slider(extensions.getmenu(Colors), value => b = value, 0, () =>
            {
                if (tochange == null)
                    return;
                extensions.setconfigfieldvalue(tochange, new float[] { r, g, b,a });
                btnt.color = new Color(r, g, b,a);
            }, true, "Blue").GetComponent<UnityEngine.UI.Slider>();
            sliderarray[3] = Apis.Slider.slider(extensions.getmenu(Colors), value => a = value, 0, () =>
            {
                if (tochange == null)
                    return;
                extensions.setconfigfieldvalue(tochange, new float[] { r, g, b ,a});
                btnt.color = new Color(r, g, b,a);
            }, true, "Alpha").GetComponent<UnityEngine.UI.Slider>();
            var bc = Buttons.Button(extensions.getmenu(Colors), "Color View(Refresh)", () =>
            {
                Ui.uicolors.hudcolors();
                Ui.uicolors.applybutton();
                Ui.uicolors.ApplyText();

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
                }//_falloff







            });
            bc.transform.Find("Icon").gameObject.SetActive(false);
            Component.DestroyImmediate(bc.gameObject.transform.Find("Background").GetComponent<Image>());
            btnt = bc.gameObject.transform.Find("Background").gameObject.AddComponent<Image>();
            btnt.sprite = null;

            Buttons.Button(extensions.getmenu(Colors), "Client Chat Image", () =>
            {
                Apis.inputpopout.run("Qm Image", value => Settings.ConfigVars.chatimage = value, () => {
                    MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(
                      GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_DevTools/_Submenu_Client Chat/Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup/_Button_/Background/Background(Clone)").gameObject.GetComponent<Image>(), Settings.ConfigVars.chatimage
                        ));
                });

            }, false, null);


            Buttons.Button(extensions.getmenu(Colors), "Friends", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.friend[0], Settings.ConfigVars.friend[1], Settings.ConfigVars.friend[2], Settings.ConfigVars.trusted[3]);
                tochange = nameof(Settings.ConfigVars.friend);
                csliderv(Settings.ConfigVars.friend);

            },true);

            Buttons.Button(extensions.getmenu(Colors), "Visitor", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.visitor[0], Settings.ConfigVars.visitor[1], Settings.ConfigVars.visitor[2], Settings.ConfigVars.trusted[3]);
                tochange = nameof(Settings.ConfigVars.visitor);
                csliderv(Settings.ConfigVars.visitor);

            }, true);

            Buttons.Button(extensions.getmenu(Colors), "New User", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.newuser[0], Settings.ConfigVars.newuser[1], Settings.ConfigVars.newuser[2], Settings.ConfigVars.trusted[3]);
                tochange = nameof(Settings.ConfigVars.newuser);
                csliderv(Settings.ConfigVars.newuser);

            }, true);

            Buttons.Button(extensions.getmenu(Colors), "User", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.user[0], Settings.ConfigVars.user[1], Settings.ConfigVars.user[2], Settings.ConfigVars.trusted[3]);
                tochange = nameof(Settings.ConfigVars.user);
                csliderv(Settings.ConfigVars.user);

            }, true);

            Buttons.Button(extensions.getmenu(Colors), "Known User", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.known[0], Settings.ConfigVars.known[1], Settings.ConfigVars.known[2], Settings.ConfigVars.trusted[3]);
                tochange = nameof(Settings.ConfigVars.known);
                csliderv(Settings.ConfigVars.known);

            }, true);

            Buttons.Button(extensions.getmenu(Colors), "Trusted", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.trusted[0], Settings.ConfigVars.trusted[1], Settings.ConfigVars.trusted[2], Settings.ConfigVars.trusted[3]);
                tochange = nameof(Settings.ConfigVars.trusted);
                csliderv(Settings.ConfigVars.trusted);

            }, true);

           
            Buttons.Button(extensions.getmenu(Colors), "Super Powers", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.superpowers[0], Settings.ConfigVars.superpowers[1], Settings.ConfigVars.superpowers[2], Settings.ConfigVars.superpowers[3]);
                tochange = nameof(Settings.ConfigVars.superpowers);
                csliderv(Settings.ConfigVars.superpowers);

            }, true);

            Buttons.Button(extensions.getmenu(Colors), "Moderator", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.Moderator[0], Settings.ConfigVars.Moderator[1], Settings.ConfigVars.Moderator[2], Settings.ConfigVars.Moderator[3]);
                tochange = nameof(Settings.ConfigVars.Moderator);
                csliderv(Settings.ConfigVars.Moderator);

            }, true);

            Buttons.Button(extensions.getmenu(Colors), "Hud", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.HuDColor[0], Settings.ConfigVars.HuDColor[1], Settings.ConfigVars.HuDColor[2], Settings.ConfigVars.HuDColor[3]);
                tochange = nameof(Settings.ConfigVars.HuDColor);
                csliderv(Settings.ConfigVars.HuDColor);

            }, true);
            Buttons.Button(extensions.getmenu(Colors), "Buttons", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.ButtonColor[0], Settings.ConfigVars.ButtonColor[1], Settings.ConfigVars.ButtonColor[2], Settings.ConfigVars.ButtonColor[3]);
                tochange = nameof(Settings.ConfigVars.ButtonColor);
                csliderv(Settings.ConfigVars.ButtonColor);

            }, true);
            Buttons.Button(extensions.getmenu(Colors), "Text", () =>
            {
                btnt.color = new Color(Settings.ConfigVars.textcolor[0], Settings.ConfigVars.textcolor[1], Settings.ConfigVars.textcolor[2], Settings.ConfigVars.textcolor[3]);
                tochange = nameof(Settings.ConfigVars.textcolor);
                csliderv(Settings.ConfigVars.textcolor);

            }, true);
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        }
        private static void csliderv(float[] flarray)
        {
            sliderarray[0].value = flarray[0];
            sliderarray[1].value = flarray[1];
            sliderarray[2].value = flarray[2];
            sliderarray[3].value = flarray[3];


        }

    }
}
