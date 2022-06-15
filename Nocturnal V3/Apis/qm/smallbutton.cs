using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Ui;
namespace Nocturnal.Apis.qm
{
    internal class SmallButton
    {
        public SmallButton(out GameObject instance,GameObject path, Action action, string img = null)
        {
            var button = GameObject.Instantiate(Objects._ButtonPrefab, path.transform);
            button.transform.Find("Text_H4").gameObject.SetActive(false);
            button.name = "_Button_Small";
            var buttoncomp = button.gameObject.GetComponent<UnityEngine.UI.Button>();
            buttoncomp.onClick.RemoveAllListeners();
            buttoncomp.onClick.AddListener(action);
            button.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().enabled = false;
            button.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(-98, -76);
            Transform Icon = button.transform.Find("Icon");
            Icon.localScale = new Vector3(0.9f, 0.9f, 1);
            Icon.localPosition = new Vector3(0, 35, 0);
            instance = button;
            if (img != null)
            {
                Component.DestroyImmediate(button.transform.Find("Icon").GetComponent<VRC.UI.Core.Styles.StyleElement>());
                Icon.gameObject.Loadfrombytes(img);
                Icon.gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            }
        }

         
    }
}
