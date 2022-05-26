using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Settings;
using UnityEngine.UI;
namespace Nocturnal.Ui
{
    internal class uicolors
    {
        internal static void hudcolors()
        {
            var color = new Color(ConfigVars.HuDColor[0], ConfigVars.HuDColor[1], ConfigVars.HuDColor[2], ConfigVars.HuDColor[3]);

            var unscaledhud = GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud").gameObject;
            unscaledhud.transform.Find("VoiceDotParent/VoiceDotDisabled").gameObject.GetComponent<UnityEngine.UI.Image>().color = color;

            unscaledhud.transform.Find("AFK/Icon").gameObject.GetComponent<UnityEngine.UI.Image>().color = color;

            unscaledhud.transform.Find("VoiceDotParent/PushToTalkKeybd").gameObject.GetComponent<UnityEngine.UI.Image>().color = color;

            unscaledhud.transform.Find("VoiceDotParent/PushToTalkXbox").gameObject.GetComponent<UnityEngine.UI.Image>().color = color;

            unscaledhud.transform.Find("ReticleParent/Reticle").gameObject.GetComponent<UnityEngine.UI.Image>().color = color;

            HighlightsFX.field_Private_Static_HighlightsFX_0.field_Protected_Material_0.color = color;
            GameObject.Find("_Application/CursorManager/MouseArrow/VRCUICursorIcon").gameObject.GetComponent<UnityEngine.SpriteRenderer>().color = color;
        }

        internal static void applybutton()
        {
            var button = GameObject.Find("/UserInterface/MenuContent").GetComponentsInChildren<Button>(true);
            for (int i = 0; i < button.Length; i++)
            {
                try
                {
                    ColorBlock cb = button[i].colors;
                    cb.normalColor = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3] - 0.25f);
                    cb.highlightedColor = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3] - 0.1f);
                    cb.pressedColor = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3]);
                    cb.disabledColor = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3] - 0.5f);
                    cb.selectedColor = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3] - 0.1f);
                    button[i].colors = cb;
                }
                catch { }
            }

            var Sliders = GameObject.Find("/UserInterface/MenuContent").GetComponentsInChildren<Slider>(true);
            for (int i = 0; i < Sliders.Length; i++)
            {
                try
                {


                    switch (true)
                    {
                        case true when Sliders[i].gameObject.transform.Find("Background") != null:
                            Sliders[i].gameObject.transform.Find("Background").gameObject.GetComponent<Image>().color = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3] - 0.3f);
                            Sliders[i].gameObject.transform.Find("Handle Slide Area/Handle").GetComponent<Image>().color = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3]);
                            break;
                        case true when Sliders[i].gameObject.transform.Find("Fill Area/Fill") != null:
                            Sliders[i].gameObject.GetComponent<Image>().color = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3] - 0.3f);
                            Sliders[i].gameObject.transform.Find("Fill Area/Fill").GetComponent<Image>().color = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3]);
                            break;
                        case true when Sliders[i].gameObject.transform.Find("FillArea/Fill") != null:
                            Sliders[i].gameObject.transform.Find("FillArea/Fill").GetComponent<Image>().color = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3]);
                            Sliders[i].gameObject.GetComponent<Image>().color = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], ConfigVars.ButtonColor[3] - 0.3f);
                            break;



                    }

                }
                catch { }
            }

            var imgi =  GameObject.Find("/UserInterface").transform.Find("MenuContent").gameObject.GetComponentsInChildren<Image>(true);
            for (int i = 0; i < imgi.Length; i++)
            {
                try
                {


                    switch (true)
                    {
                        case true when imgi[i].gameObject.name == "TitlePanel":
                            imgi[i].color = new Color(0, 0, 0, 0.572f);
                            break;
                        case true when imgi[i].gameObject.name == "Panel_Header":
                            imgi[i].color = new Color(ConfigVars.ButtonColor[0], ConfigVars.ButtonColor[1], ConfigVars.ButtonColor[2], 0.7f);
                            break;
                        case true when imgi[i].gameObject.name.Contains("Panel") && imgi[i].gameObject.transform.parent.name != "User Panel":
                            imgi[i].color = new Color(0, 0, 0, 0.572f);
                            break;
                        case true when imgi[i].gameObject.name == "Panel" && imgi[i].gameObject.transform.parent.name != "User Panel":
                            imgi[i].color = new Color(0, 0, 0, 0.572f);
                            break;
                        case true when imgi[i].gameObject.name == "BorderImage":
                            imgi[i].color = new Color(ConfigVars.ButtonColor[0] /1.5f, ConfigVars.ButtonColor[1] /1.5f, ConfigVars.ButtonColor[2] /1.5f, 0.9f);
                            break;
                        case true when imgi[i].gameObject.name == "Rectangle":
                            imgi[i].color = new Color(ConfigVars.ButtonColor[0] / 1.5f, ConfigVars.ButtonColor[1] / 1.5f, ConfigVars.ButtonColor[2] / 1.5f, 0.9f);
                            break;
                        case true when imgi[i].gameObject.name == "InputField":
                            imgi[i].color = new Color(ConfigVars.ButtonColor[0] / 1.5f, ConfigVars.ButtonColor[1] / 1.5f, ConfigVars.ButtonColor[2] / 1.5f, 0.9f);
                            break;
                        case true when imgi[i].gameObject.name == "Background":
                            imgi[i].color = new Color(ConfigVars.ButtonColor[0] / 1.5f, ConfigVars.ButtonColor[1] / 1.5f, ConfigVars.ButtonColor[2] / 1.5f, 0.9f);
                            break;
                        case true when imgi[i].gameObject.name == "UserVolumeOptions":
                            imgi[i].color = new Color(ConfigVars.ButtonColor[0] / 1.5f, ConfigVars.ButtonColor[1] / 1.5f, ConfigVars.ButtonColor[2] / 1.5f, 0.9f);
                            break;
                        case true when imgi[i].gameObject.name == "ON":
                            imgi[i].color = new Color(ConfigVars.ButtonColor[0] / 1.5f, ConfigVars.ButtonColor[1] / 1.5f, ConfigVars.ButtonColor[2] / 1.5f, 0.9f);
                            break;
                        case true when imgi[i].gameObject.name == "ON":
                            imgi[i].color = new Color(ConfigVars.ButtonColor[0] / 1.5f, ConfigVars.ButtonColor[1] / 1.5f, ConfigVars.ButtonColor[2] / 1.5f, 0.9f);
                            break;
                        case true when imgi[i].gameObject.name == "_Description_SafetyLevel":
                            imgi[i].color = new Color(ConfigVars.ButtonColor[0] / 1.5f, ConfigVars.ButtonColor[1] / 1.5f, ConfigVars.ButtonColor[2] / 1.5f, 0.9f);
                            break;
                        case true when imgi[i].gameObject.name == "Checkmark":
                            imgi[i].color = new Color(ConfigVars.textcolor[0] / 1.5f, ConfigVars.textcolor[1] / 1.5f, ConfigVars.textcolor[2] / 1.5f, 0.9f);
                            break;
                        case true when imgi[i].gameObject.name == "Lighter" && imgi[i].gameObject.transform.parent.name != "User Panel":
                            imgi[i].color = new Color(0, 0, 0, 0.572f);
                            break;
                    }

                }
                catch { }
            }
        }

        internal static void ApplyText()
        {
            var text = GameObject.Find("/UserInterface/MenuContent").GetComponentsInChildren<Text>(true);
            for (int i = 0; i < text.Length; i++)
            {
                try
                {
                    text[i].color = new Color(ConfigVars.textcolor[0], ConfigVars.textcolor[1], ConfigVars.textcolor[2], ConfigVars.textcolor[3]);
                }
                catch { }
            }
            var texttmp = GameObject.Find("/UserInterface/MenuContent").GetComponentsInChildren<TMPro.TextMeshProUGUI>(true);
            for (int i = 0; i < texttmp.Length; i++)
            {
                try
                {
                    texttmp[i].color = new Color(ConfigVars.textcolor[0], ConfigVars.textcolor[1], ConfigVars.textcolor[2], ConfigVars.textcolor[3]);
                }
                catch { }
            }

        }

    }
}
