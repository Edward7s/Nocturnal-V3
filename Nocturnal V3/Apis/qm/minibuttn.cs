using System;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal  class Minibuttn
    {

        public Minibuttn(GameObject path, string text, Action action, string icon)
        {
            GameObject Instanciated = GameObject.Instantiate(Ui.Objects._qmexpand, path.transform);
            Button ButtonComp = Instanciated.gameObject.GetComponent<Button>();
            Component.DestroyImmediate(Instanciated.GetComponent<VRC.DataModel.Core.BindingComponent>());
            ButtonComp.onClick.RemoveAllListeners();
            ButtonComp.onClick.AddListener(action);
            GameObject Icon = Instanciated.transform.Find("Icon").gameObject;
            Component.DestroyImmediate(Icon.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            Icon.Loadfrombytes(icon);
            Instanciated.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            Icon.gameObject.GetComponent<Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
        }
      
    }
}
