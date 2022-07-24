using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal;
using UnityEngine;
using MelonLoader;
using UnityEngine.UI;
using Nocturnal.Apis;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.Ui
{
    internal class QuickMenu
    {
        internal static void Style()
        {
            GameObject backGround = GameObject.Instantiate(Objects._qmbackground, Objects._qmbackground.transform.parent);
            backGround.SetActive(true);
            Component.DestroyImmediate(backGround.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            var qmImage = GameObject.Instantiate(backGround, backGround.transform);
            qmImage.name = "_Background";
            Image imageComponent = qmImage.gameObject.GetComponent<Image>();
            backGround.AddComponent<Mask>().showMaskGraphic = false;
            backGround.gameObject.Loadfrombytes(Settings.Download_Files.imagehandler.quickmenumask);
            qmImage.transform.localPosition = Vector3.zero;
            qmImage.transform.localScale = Vector3.one;
            backGround.transform.localScale = new Vector3(1.03f, 1, 1);
            MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(imageComponent, Settings.ConfigVars.MiddleQm));
            GameObject leftWindow = Objects._QuickMenuCanvas.transform.Find("Container/Window/Wing_Left/Container/InnerContainer/Background").gameObject;
            Component.DestroyImmediate(leftWindow.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(leftWindow.GetComponent<Image>(), Settings.ConfigVars.LeftWing));
            GameObject righttWindow = Objects._QuickMenuCanvas.transform.Find("Container/Window/Wing_Right/Container/InnerContainer/Background").gameObject;
            righttWindow.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, Settings.ConfigVars.BackgoundsOpaacity);
            leftWindow.GetComponent<UnityEngine.UI.Image>().color = new Color(1, 1, 1, Settings.ConfigVars.BackgoundsOpaacity);
            imageComponent.color = new Color(1, 1, 1, Settings.ConfigVars.BackgoundsOpaacity);
            Component.DestroyImmediate(righttWindow.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            MelonCoroutines.Start(Apis.Change_Image.LoadIMGTSprite(righttWindow.GetComponent<Image>(), Settings.ConfigVars.RightWing));
            backGround.transform.SetSiblingIndex(0);
            ChangeQuickMenuButtons();
        }

        private static VRC.UI.Core.Styles.StyleElement[] s_buttonsArr { get; set; }
        private static Toggle[] s_togglessArr { get; set; }

        private static GameObject s_background  { get; set; }
        private static Image s_imageComp { get; set; }


        internal static void ChangeQuickMenuButtons()
        {
            s_buttonsArr = Objects._QuickMenuCanvas.GetComponentsInChildren<VRC.UI.Core.Styles.StyleElement>(true).Where(x => x.transform.Find("Background") != null && x.transform.Find("Background").gameObject.GetComponent<Image>() != null && !x.name.StartsWith("Page_")).ToArray();
            for (int i = 0; i < s_buttonsArr.Length; i++)
            {
                s_background = s_buttonsArr[i].transform.Find("Background").gameObject;
                Component.DestroyImmediate(s_background.GetComponent<Image>());
                s_imageComp = s_background.AddComponent<Image>();
                s_imageComp.color = extensions.FloatArrToColor(Settings.ConfigVars.ButtonColor);
                s_imageComp.type = Image.Type.Sliced;
                s_imageComp.pixelsPerUnitMultiplier = 69;
                s_background.Loadfrombytes(Settings.Download_Files.imagehandler.Button, new Vector4(35, 35, 35, 35), 2);
            }

            s_buttonsArr = Objects._QuickMenuCanvas.GetComponentsInChildren<VRC.UI.Core.Styles.StyleElement>(true).Where(x => x.transform.Find("Container") != null && x.transform.Find("Container/Background") != null).ToArray();
            for (int i = 0; i < s_buttonsArr.Length; i++)
            {
                s_background = s_buttonsArr[i].transform.Find("Container/Background").gameObject;
                Component.DestroyImmediate(s_background.GetComponent<Image>());
                s_imageComp = s_background.AddComponent<Image>();
                s_imageComp.color = extensions.FloatArrToColor(Settings.ConfigVars.ButtonColor);
                s_imageComp.type = Image.Type.Sliced;
                s_imageComp.pixelsPerUnitMultiplier = 69;
                s_background.Loadfrombytes(Settings.Download_Files.imagehandler.Button, new Vector4(35, 35, 35, 35), 2);
            }


            s_buttonsArr = Objects._QuickMenuCanvas.GetComponentsInChildren<VRC.UI.Core.Styles.StyleElement>(true).Where(x => x.transform.Find("Background (1)") != null).ToArray();
            for (int i = 0; i < s_buttonsArr.Length; i++)
            {
                s_background = s_buttonsArr[i].transform.Find("Background (1)").gameObject;
                Component.DestroyImmediate(s_background.GetComponent<Image>());
                s_imageComp = s_background.AddComponent<Image>();
                s_imageComp.color = extensions.FloatArrToColor(Settings.ConfigVars.ButtonColor);
                s_imageComp.type = Image.Type.Sliced;
                s_imageComp.pixelsPerUnitMultiplier = 69;
                s_background.Loadfrombytes(Settings.Download_Files.imagehandler.Button, new Vector4(35, 35, 35, 35), 2);
            }


            s_buttonsArr = Objects._QuickMenuCanvas.GetComponentsInChildren<VRC.UI.Core.Styles.StyleElement>(true).Where(x => x.transform.Find("Background (2)") != null).ToArray();
            for (int i = 0; i < s_buttonsArr.Length; i++)
            {
                s_background = s_buttonsArr[i].transform.Find("Background (2)").gameObject;
                Component.DestroyImmediate(s_background.GetComponent<Image>());
                s_imageComp = s_background.AddComponent<Image>();
                s_imageComp.color = extensions.FloatArrToColor(Settings.ConfigVars.ButtonColor);
                s_imageComp.type = Image.Type.Sliced;
                s_imageComp.pixelsPerUnitMultiplier = 69;
                s_background.Loadfrombytes(Settings.Download_Files.imagehandler.Button, new Vector4(35, 35, 35, 35), 2);
            }


            s_buttonsArr = Objects._QuickMenuCanvas.GetComponentsInChildren<VRC.UI.Core.Styles.StyleElement>(true).Where(x => x.name == "Background" && x.transform.parent.gameObject.name.StartsWith("Button_")).ToArray();
            for (int i = 0; i < s_buttonsArr.Length; i++)
            {
                s_background = s_buttonsArr[i].gameObject;
              //  Component.DestroyImmediate(s_background.GetComponent<Image>());
                Component.DestroyImmediate(s_background.GetComponent<VRC.UI.Core.Styles.StyleElement>());
                s_imageComp = s_background.GetComponent<Image>();
                s_imageComp.type = Image.Type.Sliced;
                s_imageComp.pixelsPerUnitMultiplier = 54;
                s_background.Loadfrombytes(Settings.Download_Files.imagehandler.Button, new Vector4(35, 35, 35, 35), 2);
                s_imageComp.color = extensions.FloatArrToColor(Settings.ConfigVars.ButtonColor);

            }

            s_buttonsArr = Objects._QuickMenuCanvas.GetComponentsInChildren<VRC.UI.Core.Styles.StyleElement>(true).Where(x => x.transform.Find("Background") != null && x.transform.Find("Background").gameObject.GetComponent<Image>() != null && x.name.StartsWith("Page_")).ToArray();
            for (int i = 0; i < s_buttonsArr.Length; i++)
            {
                s_background = s_buttonsArr[i].transform.Find("Background").gameObject;
                Component.DestroyImmediate(s_background.GetComponent<Image>());
                s_imageComp = s_background.AddComponent<Image>();
                s_imageComp.color = extensions.FloatArrToColor(Settings.ConfigVars.ButtonColor);
                s_imageComp.type = Image.Type.Sliced;
                s_imageComp.pixelsPerUnitMultiplier = 69;
                s_background.Loadfrombytes(Settings.Download_Files.imagehandler.TabIcon, new Vector4(35, 35, 35, 35), 2);
            }


            Objects._QuickMenuCanvas.transform.Find("Container/Window/MicButton").gameObject.GetComponent<Image>().color = extensions.FloatArrToColor(Settings.ConfigVars.ButtonColor);


            Objects._QuickMenuCanvas.transform.Find("Container/Window/Toggle_SafeMode").gameObject.GetComponent<Image>().color = extensions.FloatArrToColor(Settings.ConfigVars.ButtonColor);


            Objects._QuickMenuCanvas.transform.Find("Container/Window/QMParent/Menu_Camera/Panel_Info/Icon_Info").GetComponent<RawImage>().color = Color.red;

        }

    }
}
