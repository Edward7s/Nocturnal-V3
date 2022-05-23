using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Settings;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal static class minibuttn
    {
        internal static GameObject minib(this GameObject path,string text,Action action,byte[] icon)
        {
            var insts = GameObject.Instantiate(Ui.objects.qmexpand, path.transform);
            var buttoncompf = insts.gameObject.GetComponent<UnityEngine.UI.Button>();
            Component.DestroyImmediate(insts.GetComponent<VRC.DataModel.Core.BindingComponent>());
            buttoncompf.onClick.RemoveAllListeners();
            buttoncompf.onClick.AddListener(action);
            var iconin = insts.transform.Find("Icon").gameObject;
            Component.DestroyImmediate(iconin.GetComponent<VRC.UI.Core.Styles.StyleElement>());
          //  insts.transform.SetSiblingIndex(0);
            iconin.Loadfrombytes(icon);
            insts.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            iconin.gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
            return insts;
        }
    }
}
