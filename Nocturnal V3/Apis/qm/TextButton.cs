using System;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal class TextButton
    {

        public TextButton(Transform path, string text, string id, VRC.Player user)
        {
            GameObject geng = new GameObject("BTN_" + id);
            geng.transform.parent = path;
            geng.transform.localScale = new Vector3(8.7f, 0.7f, 1);
            geng.transform.localPosition = Vector3.zero;
            geng.transform.localEulerAngles = Vector3.zero;
            GameObject img = GameObject.Instantiate(geng, geng.transform).gameObject;
            GameObject textg = GameObject.Instantiate(img, img.transform).gameObject;
            img.transform.localPosition = new Vector3(-1.6f, 0, 0);
            img.transform.localScale = new Vector3(0.93f, 0.7f, 1);
            img.gameObject.AddComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0.5f);
            Button buttoncomp = geng.AddComponent<Button>();
            geng.AddComponent<Button>();
            geng.AddComponent<LayoutElement>();
            var textcomp = textg.AddComponent<TMPro.TextMeshProUGUI>();
            textcomp.richText = true;
            textcomp.enableWordWrapping = false;
            textcomp.text = text;
            textcomp.alignment = TMPro.TextAlignmentOptions.Left;
            textcomp.transform.localScale = new Vector3(0.1f, 1.2f, 1);
            textcomp.fontSize = 49;
            textcomp.transform.localPosition = new Vector3(-40, 0, 0);
            buttoncomp.onClick.AddListener(new Action(() => VRC.DataModel.UserSelectionManager.field_Private_Static_UserSelectionManager_0.Method_Public_Void_APIUser_2(user.field_Private_APIUser_0)));
            Apis.Change_Image.Loadfrombytes(img, Settings.Download_Files.imagehandler.quickmenumask);
        }
      
    }
}
