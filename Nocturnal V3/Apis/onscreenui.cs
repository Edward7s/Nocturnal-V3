using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Nocturnal.Settings;
namespace Nocturnal.Apis
{
    internal class Onscreenui
    {
        private static GameObject s_textGameObject { get; set; }
        private static TMPro.TextMeshProUGUI s_tmpPro { get; set; }
        private static ImageThreeSlice s_imageThreeSlice { get; set; }

        private static float countdown =0;
        internal static void generateuimsg()
        {
            var toinst = GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/AlertTextParent/Capsule").gameObject;
            s_textGameObject = GameObject.Instantiate(toinst, GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud"));
            s_textGameObject.SetActive(true);
            s_textGameObject.GetComponent<UnityEngine.UI.ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            s_textGameObject.name = "ONscreennotui";
            s_textGameObject.transform.localPosition = new Vector3(60,-250, 0);
            s_tmpPro = s_textGameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            s_tmpPro.alignment = TMPro.TextAlignmentOptions.TopLeft;
            s_tmpPro.fontSize = 17;
            s_tmpPro.richText = true;
            s_textGameObject.gameObject.SetActive(false);
            s_imageThreeSlice = s_textGameObject.gameObject.GetComponent<ImageThreeSlice>();
        }

        internal static void showmsg(string strings) => MelonLoader.MelonCoroutines.Start(showmsgienum(strings));

        internal static IEnumerator showmsgienum(string strings)
        {
            if (!Main2.s_shouldRun) yield break;

            if (!Settings.ConfigVars.toggleonscreenlogger)
                yield break;
            s_tmpPro.text += strings + "\n";

            if (countdown == 0)
            {
                s_textGameObject.SetActive(true);
                countdown = 6;
                while (countdown > 0)
                {
                    yield return new WaitForSeconds(1f);
                    countdown -= 1;

                    if (countdown == 1)
                    {
                        s_tmpPro.text = "";
                        s_textGameObject.SetActive(false);
                        countdown = 0;

                    }
                }
            }
            else
            {
                s_textGameObject.SetActive(true);
                countdown = 6;
            }
          

            yield return null;        
        }

    }
}
