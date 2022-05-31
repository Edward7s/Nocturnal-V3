using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Ui;
namespace Nocturnal.Apis.qm
{
    internal class smallbutton
    {
        internal static GameObject Create(GameObject path, Action action, byte[] img = null)
        {

            var button = GameObject.Instantiate(objects.ButtonPrefab, path.transform);
            button.transform.Find("Text_H4").gameObject.SetActive(false);
            button.name = "_Button_Small";
            var buttoncomp = button.gameObject.GetComponent<UnityEngine.UI.Button>();
            buttoncomp.onClick.RemoveAllListeners();
            buttoncomp.onClick.AddListener(action);
            button.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().enabled = false;
            button.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(-98, -76);
            button.transform.Find("Icon").transform.localScale = new Vector3(0.9f, 0.9f, 1);
            button.transform.Find("Icon").transform.localPosition = new Vector3(0, 35, 0);

            if (img != null)
            {
                Component.DestroyImmediate(button.transform.Find("Icon").GetComponent<VRC.UI.Core.Styles.StyleElement>());
                button.transform.Find("Icon").gameObject.Loadfrombytes(img);
                button.transform.Find("Icon").gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            }
            return button;
        }
    }
}
