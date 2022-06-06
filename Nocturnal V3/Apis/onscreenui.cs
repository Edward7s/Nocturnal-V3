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
        private static GameObject textgameobj;
        private static TMPro.TextMeshProUGUI tmpro;
        private static int countdown =0;
        internal static void generateuimsg()
        {
            var toinst = GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/AlertTextParent/Capsule").gameObject;
            textgameobj = GameObject.Instantiate(toinst, GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud"));
            textgameobj.SetActive(true);
            textgameobj.GetComponent<UnityEngine.UI.ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            textgameobj.name = "ONscreennotui";
            textgameobj.transform.localPosition = new Vector3(150, 0, 0);
            tmpro = textgameobj.GetComponentInChildren<TMPro.TextMeshProUGUI>();
            tmpro.alignment = TMPro.TextAlignmentOptions.TopLeft;
            tmpro.fontSize = 17;
            tmpro.richText = true;
            textgameobj.gameObject.SetActive(false);
        }

        internal static void showmsg(string strings) => MelonLoader.MelonCoroutines.Start(showmsgienum(strings));



        internal static IEnumerator showmsgienum(string strings)
        {
            if (!Settings.ConfigVars.toggleonscreenlogger)
                yield break;
            tmpro.text += strings + "\n";

            if (countdown == 0)
            {
                textgameobj.SetActive(true);
                countdown = 3;
                while (countdown > 0)
                {
                    yield return new WaitForSeconds(1f);
                    countdown -= 1;

                    if (countdown == 1)
                    {
                        tmpro.text = "";
                        textgameobj.SetActive(false);
                        countdown = 0;

                    }


                    

                }
            }
            else
            {
                textgameobj.SetActive(true);
                countdown = 3;
            }
          

            yield return null;        
        }

    }
}
