using System;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal  class Minibuttn
    {
        private GameObject _ButtonGameobject { get; set; }
        private Button _ButtonComponent { get; set; }
        private GameObject _ButtonIcon { get; set; }

        ~Minibuttn()
        {
            this._ButtonGameobject = null;
            this._ButtonComponent = null;
            this._ButtonIcon = null;
        }
        public Minibuttn(GameObject path, string text, Action action, string icon)
        {
            _ButtonGameobject = GameObject.Instantiate(Ui.Objects._QMexpand, path.transform);
            _ButtonComponent = _ButtonGameobject.gameObject.GetComponent<Button>();
            Component.DestroyImmediate(_ButtonGameobject.GetComponent<VRC.DataModel.Core.BindingComponent>());
            _ButtonComponent.onClick.RemoveAllListeners();
            _ButtonComponent.onClick.AddListener(action);
            _ButtonIcon = _ButtonGameobject.transform.Find("Icon").gameObject;
            Component.DestroyImmediate(_ButtonIcon.GetComponent<VRC.UI.Core.Styles.StyleElement>());
            _ButtonIcon.Loadfrombytes(icon);
            _ButtonGameobject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = text;
            _ButtonIcon.gameObject.GetComponent<Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
        }
      
    }
}
