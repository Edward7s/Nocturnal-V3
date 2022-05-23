using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using Nocturnal.Ui;
namespace Nocturnal.Apis.qm
{
    internal static class Submenubutton
    {
        private static float speed = 1f;

        internal static GameObject submenu(this GameObject menu,string text, GameObject menutoopen,byte[] img = null, bool half = false, float X = 628, float Y = 628)
        {
            float yvalue = half ? -140 - (Y * (200 / 2) - 45) : -140 - Y * 200;
           

            var instanciated = GameObject.Instantiate(objects.ButtonPrefab, menu.transform).gameObject;
            Component.DestroyImmediate(instanciated.transform.Find("Icon").gameObject.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            instanciated.name = $"SubBtn_{text}";
            instanciated.transform.rotation = new Quaternion(0, 0, 0, 0);
            var buttoni = instanciated.GetComponent<UnityEngine.UI.Button>();
            buttoni.onClick.RemoveAllListeners();
            buttoni.onClick.AddListener(new Action(() =>
            {
                foreach (GameObject gmj in qm.submenu.submenuslist)
                    if (gmj != menutoopen)
                    {

                        gmj.SetActive(false);
                    }
                    else
                    {
                        Page.lastmen = gmj;
                        gmj.SetActive(true);
                        MelonCoroutines.Start(timedeltaspeed(gmj));
                    }


            }));
            instanciated.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            instanciated.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            if (img != null)
            {
                Apis.Change_Image.Loadfrombytes(instanciated.transform.Find("Icon").gameObject, img);
                instanciated.transform.Find("Icon").gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);

            }
            
            //  if (!settings.nconfig.Overwritetextcolor)
            //  instanciated.transform.Find("Icon").gameObject.GetComponent<UnityEngine.UI.Image>().color = Color.gray;
            if (X != 628 && Y != 628)
            {
                instanciated.transform.localPosition = new Vector3(-350 + X * 240, yvalue);
            }
            if (!half)
                return instanciated;

            instanciated.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
            var ico = instanciated.transform.Find("Icon").gameObject;
            ico.transform.localScale = new Vector3(0.5f, 0.5f, 1);
            ico.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
            var texts = instanciated.transform.Find("Text_H4").gameObject;
            texts.transform.localScale = new Vector3(0.9f, 0.9f, 1);
            texts.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);
            return instanciated;
        }
        internal static IEnumerator timedeltaspeed(GameObject gmj)
        {
            for (; ; )
            {
                speed += Time.deltaTime * 7000;
                if (gmj.name != "Main menu")
                    gmj.transform.localPosition = new Vector3(1000 - speed, gmj.transform.localPosition.y, 0);

                else
                    gmj.transform.localPosition = new Vector3(1000 - speed, gmj.transform.localPosition.y, 0);
                if (gmj.transform.localPosition.x <= 0)
                {
                    if (gmj.name != "Main menu")
                        gmj.transform.localPosition = new Vector3(0, gmj.transform.localPosition.y, 0);
                    else
                        gmj.transform.localPosition = new Vector3(0, gmj.transform.localPosition.y, 0);
                    speed = 1;
                    yield break;
                }


                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
