using System;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal static class Minibuttn
    {
        internal static GameObject Create(this GameObject path,string text,Action action,string icon)
        {
            var insts = GameObject.Instantiate(Ui.Objects._qmexpand, path.transform);
            var buttoncompf = insts.gameObject.GetComponent<Button>();
            Component.DestroyImmediate(insts.GetComponent<VRC.DataModel.Core.BindingComponent>());
            buttoncompf.onClick.RemoveAllListeners();
            buttoncompf.onClick.AddListener(action);
            var iconin = insts.transform.Find("Icon").gameObject;
            Component.DestroyImmediate(iconin.GetComponent<VRC.UI.Core.Styles.StyleElement>());
          //  insts.transform.SetSiblingIndex(0);
            iconin.Loadfrombytes(icon);
            insts.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            iconin.gameObject.GetComponent<Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            return insts;
        }
    }
}
