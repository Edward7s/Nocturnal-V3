using System;
using UnityEngine;
using UnityEngine.UI;
using Nocturnal.Ui;
namespace Nocturnal.Apis.qm
{
    internal class SmallButton
    {
        private GameObject _ButtonGameobject { get; set; }
        private Button _ButtonComponent { get; set; }
        private Transform _ButtonIcon { get; set; }
        ~SmallButton()
        {
            this._ButtonGameobject = null;
            this._ButtonComponent = null;
            this._ButtonIcon = null;
        }
        public SmallButton(out GameObject instance,GameObject path, Action action, string img = null)
        {
            _ButtonGameobject = GameObject.Instantiate(Objects._ButtonPrefab, path.transform);
            _ButtonGameobject.transform.Find("Text_H4").gameObject.SetActive(false);
            _ButtonGameobject.name = "_Button_Small";
            _ButtonComponent = _ButtonGameobject.gameObject.GetComponent<UnityEngine.UI.Button>();
            _ButtonComponent.onClick.RemoveAllListeners();
            _ButtonComponent.onClick.AddListener(action);
            _ButtonGameobject.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().enabled = false;
            _ButtonGameobject.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(-98, -76);
            _ButtonIcon = _ButtonGameobject.transform.Find("Icon");
            _ButtonIcon.localScale = new Vector3(0.9f, 0.9f, 1);
            _ButtonIcon.localPosition = new Vector3(0, 35, 0);
            instance = _ButtonGameobject;
            if (img == null) return;
            Component.DestroyImmediate(_ButtonGameobject.transform.Find("Icon").GetComponent<VRC.UI.Core.Styles.StyleElement>());
            _ButtonIcon.gameObject.Loadfrombytes(img);
            _ButtonIcon.gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);
        }


    }
}
