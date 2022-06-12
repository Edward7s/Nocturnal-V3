using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Nocturnal.Apis;
using System;

namespace Nocturnal.Ui
{
     class Qm_basic
    {
       internal static Thread runs = new Thread(Setupstuff);

        internal static TMPro.TextMeshProUGUI _debugtext = null;
        internal static AudioSource _audiosourcenotification = null;
        internal static TMPro.TextMeshProUGUI _firsttext = null;
        internal static TMPro.TextMeshProUGUI _secondtext = null;
        internal static TMPro.TextMeshProUGUI _Thirdtext = null;
        internal static TMPro.TextMeshProUGUI _GUIInfo = null;
        internal static Transform _playerlistmenu;
        internal static TMPro.TextMeshProUGUI playercounter = null;

        internal static void Setupstuff()
        {
            var styletimer = System.Diagnostics.Stopwatch.StartNew();

            var DashBoardV = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup").transform;

            if (Settings.ConfigVars.qmdebug)
            {
                DashBoardV.Find("Carousel_Banners").gameObject.SetActive(false);
                DashBoardV.Find("Header_QuickActions").gameObject.SetActive(false);
                DashBoardV.Find("Header_QuickLinks").gameObject.SetActive(false);

                var childs = DashBoardV.gameObject.GetComponentsInChildren<Button>(true);
                for (int i = 0; i < childs.Length; i++)
                {
                    //  if (childs[i].transform.Find("Background") == null)
                    try
                    {
                        childs[i].transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
                        var ico = childs[i].transform.Find("Icon").gameObject;
                        ico.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                        ico.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
                        var text = childs[i].transform.Find("Text_H4").gameObject;
                        text.transform.localScale = new Vector3(0.9f, 0.9f, 1);
                        text.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);
                        childs[i].transform.Find("Badge_MMJump").transform.localPosition = new Vector3(88.8256f, 34.0999f, 0f);


                        if (childs[i].name == "Button_SelectUser")
                        {

                            childs[i].transform.Find("Text_H4").gameObject.transform.localPosition = new Vector3(18.58f, 70, 0);
                            childs[i].transform.Find("Icon").transform.localPosition = new Vector3(-75.5186f, -70, 0);

                            //Icon
                        }
                        if (childs[i].name == " Button_InteractionPauseWithState")
                        {
                            childs[i].transform.Find("Text_H4").gameObject.transform.localPosition = new Vector3(18.58f, 70, 0);
                            childs[i].transform.Find("Icon").transform.localPosition = new Vector3(-75.5186f, -70, 0);

                        }

                    }
                    catch { }
                   


                }

                var vrcpbanner = DashBoardV.transform.Find("VRC+_Banners").gameObject;
                var debbuger = GameObject.Instantiate(vrcpbanner, vrcpbanner.transform.parent).gameObject;
                Component.DestroyImmediate(debbuger.GetComponent<VRC.UI.Core.Styles.StyleElement>());
                GameObject.DestroyImmediate(debbuger.transform.Find("ThankYouMM").gameObject);
                debbuger.name = "N_Debbuger";
                var mask = debbuger.transform.Find("SupportVRChat").gameObject;
                Component.DestroyImmediate(mask.GetComponent<Button>());
                Component.DestroyImmediate(mask.GetComponent<RawImage>());
                Component.DestroyImmediate(mask.GetComponent<VRC.DataModel.Core.BindingComponent>());
                debbuger.transform.SetSiblingIndex(0);
                debbuger.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(950, 570);
                debbuger.gameObject.SetActive(true);
                mask.AddComponent<UnityEngine.UI.Image>();
                mask.AddComponent<UnityEngine.UI.Mask>();
                var img2 = GameObject.Instantiate(mask, mask.transform).gameObject;
                var maskimg = mask.gameObject.GetComponent<Image>();
                var img2i = img2.gameObject.GetComponent<Image>();
                MelonLoader.MelonCoroutines.Start(Change_Image.LoadIMGTSprite(maskimg, "https://nocturnal-client.xyz/Resources/mask%20qm.png"));
                MelonLoader.MelonCoroutines.Start(Change_Image.LoadIMGTSprite(img2i,Settings.ConfigVars.QmDebbugerImg));
                img2i.color = new Color(1, 1, 1, Settings.ConfigVars.debuggeropacity);
                img2i.color = Color.white;
                img2.gameObject.transform.localPosition = Vector3.zero;
                Component.DestroyImmediate(img2.GetComponent<Mask>());
                maskimg.GetComponent<Image>().color = new Color(0, 0, 0, 0.1f);
                var img3 = GameObject.Instantiate(img2, img2.transform).gameObject;
                var img3i = img3.gameObject.GetComponent<Image>();
              
                img3.transform.localPosition = Vector3.zero;
                MelonLoader.MelonCoroutines.Start(Change_Image.LoadIMGTSprite(img3i, "https://nocturnal-client.xyz/Resources/border.png"));
                mask.transform.localPosition = new Vector3(0, 295, 0);
                mask.transform.localScale = new Vector3(1.05f, 2.61f, 1f);
                var debbugertxt = new GameObject();
                _debugtext = debbugertxt.AddComponent<TMPro.TextMeshProUGUI>();
                _debugtext.text = "";
                _debugtext.enableWordWrapping = false;
                _debugtext.fontSize = 8;
                _debugtext.maxVisibleLines = 18;
                debbugertxt.gameObject.transform.parent = img3.transform;
                debbugertxt.transform.localPosition = new Vector3(-150f, -53.86f, 1);
                debbugertxt.transform.localScale = new Vector3(2.65f,1,1);
                Style.Debbuger.Debugermsg($"<color=#2700c2>Nocturnal V3</color> Made by <color=#ff1934>Edward7");

            }

            GameObject.Find("/UserInterface").transform.Find("MenuContent/Backdrop/Backdrop").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(400, 80);
            Objects._userinfpannel.transform.Find("User Panel").transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            var userblackbackground = Objects._userinfpannel.transform.Find("User Panel/Panel").gameObject;
            var ldimg = Objects._userinfpannel.transform.Find("User Panel/PanelHeaderBackground").gameObject.GetComponent<Image>();
            ldimg.color = Color.white;
            MelonLoader.MelonCoroutines.Start(Change_Image.LoadIMGTSprite(ldimg, "https://nocturnal-client.xyz/cl/Download/Media/offwhite.png"));
            var bgimg = userblackbackground.gameObject.GetComponent<Image>();
            MelonLoader.MelonCoroutines.Start(Change_Image.LoadIMGTSprite(bgimg, "https://nocturnal-client.xyz/Resources/Normalborder.png"));
            bgimg.color = Color.black;
            bgimg.raycastTarget = false;

            userblackbackground.transform.localScale = new Vector3(1.05f, 0.6f, 1);
            userblackbackground.transform.localPosition = new Vector3(400f, -512.4001f, 0);
            var bio = Objects._userinfpannel.transform.Find("User Panel/UserBio").transform;
            bio.localScale = new Vector3(0.95f, 0.95f, 1);
            bio.transform.localPosition = new Vector3(365.1563f, -511.416f, 0);
            var userblackbg2 = GameObject.Instantiate(userblackbackground, userblackbackground.transform.parent).transform;

            userblackbg2.transform.localScale = new Vector3(1.05f, 0.34f, 1);
            userblackbg2.transform.localPosition = new Vector3(400f, -135.7954f, 0);
            userblackbg2.SetSiblingIndex(0);
          
            MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(userblackbg2.gameObject.GetComponent<Image>(), "https://nocturnal-client.xyz/Resources/Normalborder.png"));


            //Load music
            var qm = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.AddComponent<AudioSource>();
            qm.loop = true;
            qm.playOnAwake = true;
            MelonLoader.MelonCoroutines.Start(Settings.wrappers.extensions.loadaudio(qm, Settings.Download_Files.musicpath));
            qm.volume = Settings.ConfigVars.clientvolume;
            qm.GetComponent<AudioSource>().enabled = Settings.ConfigVars.qmmusic;

        
       
          
           // image.gameObject.AddComponent<VerticalLayoutGroup>();
           // border.gameObject.AddComponent<LayoutElement>().ignoreLayout = true;
            
          
            Component.DestroyImmediate(Objects._qmbackground.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            var qmimage = GameObject.Instantiate(Objects._qmbackground, Objects._qmbackground.transform);
            qmimage.name = "_Background";
            var imagecomponentqm = qmimage.gameObject.GetComponent<Image>();
            MelonLoader.MelonCoroutines.Start(Change_Image.LoadIMGTSprite(imagecomponentqm, Settings.ConfigVars.QmImg));
            imagecomponentqm.color = new Color(1, 1, 1, Settings.ConfigVars.QMopacity);
            var qmmask = Objects._qmbackground.AddComponent<Mask>();
            qmmask.showMaskGraphic = false;
            Objects._qmbackground.gameObject.Loadfrombytes(Settings.Download_Files.imagehandler.quickmenumask);
            qmimage.transform.localPosition = Vector3.zero;
            qmimage.transform.localScale = Vector3.one;


            Transform pathp = Settings.ConfigVars.rightsideplayerlist ? GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Right/Button").transform : GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Wing_Left/Button").transform;
            Vector3 pozp = Settings.ConfigVars.rightsideplayerlist ? new Vector3(515, 0, 0) : new Vector3(-515, 0, 0);
            var instanciatedmenu = GameObject.Instantiate(GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window"), pathp.transform);
            instanciatedmenu.name = "Playerlist";
            instanciatedmenu.gameObject.SetActive(Settings.ConfigVars.playerlist);
            var recivedchilds = instanciatedmenu.GetComponentsInChildren<RectTransform>(true);
            for (int i = 0; i < recivedchilds.Length; i++)
            {
                try
                {

                    if (recivedchilds[i].name == "Handle") continue;

                    if (recivedchilds[i].transform.parent.gameObject.name == "QMParent" && recivedchilds[i].name != "Menu_Settings")
                        GameObject.Destroy(recivedchilds[i].gameObject);


                    if (recivedchilds[i].transform.parent.parent.parent.parent.gameObject.name == "Menu_Settings")
                       GameObject.Destroy(recivedchilds[i].gameObject);

                    if (recivedchilds[i].name == "Menu_Settings")
                    {
                      //  Component.Destroy(recivedchilds[i].GetComponent<VRC.DataModel.Core.BindingComponent>());
                        GameObject.Destroy(recivedchilds[i].transform.Find("QMHeader_H1").gameObject);
                        var comps = recivedchilds[i].GetComponents<Component>();
                        for (int i2 = 0; i2 < comps.Length; i2++)
                        {
                            // NocturnalC.Log(comps[i2].GetType());
                            if (comps[i2].ToString().Contains(".RectTransform") || comps[i2].ToString().Contains(".CanvasGroup")) continue;

                           Component.DestroyImmediate(comps[i2]);

                        }
                        recivedchilds[i].gameObject.SetActive(true);
                       // GameObject scrollbgmj = recivedchilds[i].gameObject.transform.Find("Panel_QM_ScrollRect/Scrollbar").gameObject;
                       // scrollbgmj.gameObject.SetActive(true);
                     

                       // NocturnalC.Log(recivedchilds[i].gameObject.activeSelf);
                    }

                    if (recivedchilds[i].transform.parent.gameObject != instanciatedmenu.gameObject || recivedchilds[i].gameObject.name == "QMParent") continue;
                    GameObject.Destroy(recivedchilds[i].gameObject);


                }
                catch { }


            }

            instanciatedmenu.transform.localPosition = pozp;

         GameObject playerlistmask = new GameObject("Playerlistmask");
            playerlistmask.transform.parent = instanciatedmenu.transform;
            playerlistmask.AddComponent<Image>();
            playerlistmask.transform.localScale = new Vector3(8.5f, 11, 1);
            playerlistmask.transform.localPosition = Vector3.one;
            playerlistmask.transform.localEulerAngles = Vector3.zero;
            GameObject playerlistbackground = GameObject.Instantiate(playerlistmask, playerlistmask.transform);
            playerlistbackground.transform.localPosition = Vector3.zero;
            playerlistbackground.transform.localScale = Vector3.one;
            GameObject Borrder = GameObject.Instantiate(playerlistbackground, playerlistmask.transform);


            GameObject becomingg = GameObject.Instantiate(Borrder, Borrder.transform.parent.parent);
            becomingg.GetComponent<Image>().color = new Color(0, 0, 0, 0.6f);
            GameObject title = GameObject.Instantiate(becomingg, becomingg.transform);
            Component.DestroyImmediate(title.GetComponent<Image>());

            playercounter = title.AddComponent<TMPro.TextMeshProUGUI>();
            playercounter.alignment = TMPro.TextAlignmentOptions.Center;
            playercounter.richText = true;
            becomingg.transform.localPosition = new Vector3(0, 575, 0);
            becomingg.transform.localScale = new Vector3(6.1f, 0.7f, 1);
            playercounter.transform.localScale = new Vector3(0.145f, 1.25f, 1);
            playercounter.transform.localPosition = Vector3.zero;
            playerlistmask.gameObject.Loadfrombytes(Settings.Download_Files.imagehandler.playerlistmask);
            Borrder.gameObject.Loadfrombytes(Settings.Download_Files.imagehandler.playerlistborder);
            Borrder.transform.localScale = new Vector3(1.01f, 1.001f, 1);
            Borrder.transform.localPosition = Vector3.zero;


            Borrder.GetComponent<Image>().color = new Color(1, 1, 1, Settings.ConfigVars.QMopacity);
            MelonLoader.MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(playerlistbackground.gameObject.GetComponent<Image>(), Settings.ConfigVars.PlayerListImg));
            playerlistmask.AddComponent<Mask>().showMaskGraphic = false;
            Borrder.gameObject.GetComponent<Image>().raycastTarget = false;

            GameObject holderplayerlist = new GameObject("Holder");
            holderplayerlist.transform.parent = playerlistmask.transform;
            holderplayerlist.transform.localEulerAngles = Vector3.zero;
            holderplayerlist.transform.localScale = new Vector3(1, 1, 1);
            Transform qmparent = instanciatedmenu.transform.Find("QMParent").transform;
            qmparent.parent = holderplayerlist.transform;
            qmparent.transform.localPosition = new Vector3(-174.3137f, -46.8702f, 0);
            qmparent.transform.localScale = new Vector3(0.09f, 0.092f, 1);
            Component.DestroyImmediate(qmparent.GetComponent<RectMask2D>());
            Component.DestroyImmediate(qmparent.GetComponent<UIInvisibleGraphic>());
            holderplayerlist.transform.SetSiblingIndex(1);

            GameObject holder = holderplayerlist.transform.Find("QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup").gameObject;
            Component.DestroyImmediate(holder.GetComponent<VerticalLayoutGroup>());
            GridLayoutGroup gridl = holder.AddComponent<GridLayoutGroup>();
            gridl.constraintCount = 100;
            gridl.constraint = GridLayoutGroup.Constraint.FixedRowCount;
            gridl.cellSize = new Vector2(0, 50); 
            holder.transform.localPosition = new Vector3(450, 412, 0);
            Component.DestroyImmediate(holder.transform.parent.GetComponent<RectMask2D>());
            holderplayerlist.transform.localPosition = new Vector3(179, 9.1654f, -1.3837f);
            Transform scrollbar = holderplayerlist.transform.Find("QMParent/Menu_Settings/Panel_QM_ScrollRect/Scrollbar").transform;
            scrollbar.localPosition = new Vector3(-470, 0, 0);
            scrollbar.localScale = new Vector3(1.5f, 1, 1);
            holder.transform.parent.localPosition = Vector3.zero;
            _playerlistmenu = holder.transform;
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/BackgroundLayer02").gameObject.SetActive(false);
            Ui.uicolors.hudcolors();
            Ui.uicolors.applybutton();
            Ui.uicolors.ApplyText();

            var joinsound = new GameObject("Joinsound");
            joinsound.transform.parent = GameObject.Find("/UserInterface").transform;
            _audiosourcenotification = joinsound.AddComponent<AudioSource>();
            _audiosourcenotification.playOnAwake = false;
            _audiosourcenotification.volume = Settings.ConfigVars.clientvolume / 6;
            MelonLoader.MelonCoroutines.Start(Settings.wrappers.extensions.loadaudio(_audiosourcenotification, Settings.Download_Files.joinsound));
            var infop =  GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMNotificationsArea/DebugInfoPanel");
            var secondp = GameObject.Instantiate(infop, infop.transform.parent);
            secondp.GetComponent<UnityEngine.UI.LayoutElement>().enabled = true;
            Component.DestroyImmediate(secondp.GetComponent<VRC.UI.Elements.DebugInfoPanel>());
            Component.DestroyImmediate(secondp.GetComponent<VRC.DataModel.Core.BindingComponent>());
            secondp.gameObject.SetActive(Settings.ConfigVars.qminfopannel);
            secondp.transform.SetSiblingIndex(2);
            _firsttext = secondp.transform.Find("Panel/Text_FPS").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            _secondtext = secondp.transform.Find("Panel/Text_Ping").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            _Thirdtext = GameObject.Instantiate(_secondtext, _secondtext.transform.parent);
            _Thirdtext.transform.localPosition = new Vector3(380,0,0);
            secondp.transform.Find("Panel/Background").transform.localPosition = new Vector3(300, 0, 0);
            secondp.transform.Find("Panel/Background").GetComponent<RectTransform>().sizeDelta = new Vector2(200, 0);
            _Thirdtext.enableWordWrapping = false;
            _secondtext.enableWordWrapping = false;
            _firsttext.transform.localPosition = new Vector3(_firsttext.transform.localPosition.x - 30, 0, 0);
            _secondtext.transform.localPosition = new Vector3(_secondtext.transform.localPosition.x - 30, 0, 0);
            var texts = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_AvInteractions/Button_ToggleSelfInteract/Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>();
            texts.text = texts.text += " /Self ERP";

            //meObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)Container/Window/QMParent/Menu_Dashboard/Header_H1/LeftItemContainer/Text_Title").gameObject.transform.localPosition = new Vector3(-32, 0, 0);
            var pushtotalkxbox = GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/VoiceDotParent/PushToTalkXbox").gameObject;
            var instanciatedpushb = GameObject.Instantiate(pushtotalkxbox, pushtotalkxbox.transform.parent.parent);
            var _Imageb = instanciatedpushb.GetComponent<Image>();
            _Imageb.sprite = null;
            _Imageb.color = new Color(0, 0, 0, 0.6f);
            instanciatedpushb.name = "InfoPannel";
            instanciatedpushb.SetActive(true);
            instanciatedpushb.transform.localPosition = new Vector3(-357, - 285.0831f, 663.0096f);
            instanciatedpushb.transform.localScale = new Vector3(1.3f, 1.5f, 1);
            var tobetext = GameObject.Instantiate(instanciatedpushb, instanciatedpushb.transform).gameObject;
            Component.DestroyImmediate(tobetext.GetComponent<Image>());
            _GUIInfo = tobetext.AddComponent<TMPro.TextMeshProUGUI>();
            _GUIInfo.text = "Loading";
            _GUIInfo.fontSize = 13;
            _GUIInfo.alignment = TMPro.TextAlignmentOptions.Center;
            _GUIInfo.transform.localPosition = Vector3.zero;
            _GUIInfo.color = new Color(Settings.ConfigVars.HuDColor[0], Settings.ConfigVars.HuDColor[1], Settings.ConfigVars.HuDColor[2]);
            tobetext.transform.localPosition = Vector3.zero;
            tobetext.transform.localScale = Vector3.one;
            Apis.Onscreenui.generateuimsg();
            instanciatedpushb.gameObject.SetActive(Settings.ConfigVars.hudUi);
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer").transform.localScale = new Vector3(0.9f,0.9f,1);



            //    GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window").gameObject.GetComponent<BoxCollider>().extents = new Vector3(712, 712, 0.5f);


            styletimer.Stop();
            NocturnalC.Log($"Qm Style Loaded in {styletimer.Elapsed.ToString("hh\\:mm\\:ss\\.ff")} ", "Style", ConsoleColor.Green);

        }
    }
}
