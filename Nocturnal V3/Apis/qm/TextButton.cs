using System;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.qm
{
    internal class TextButton
    {
        private GameObject _ButtonGameobject { get; set; }
        private UnityEngine.UI.Button _ButtonComponent { get; set; }
        private GameObject _ButtonIcon { get; set; }
        private GameObject _Text { get; set; }
        private TMPro.TextMeshProUGUI _TextComponent { get; set; }

        ~TextButton()
        {
            this._ButtonGameobject = null;
            this._ButtonComponent = null;
            this._ButtonIcon = null;
            this._Text = null;
            this._TextComponent = null;
        }
        public TextButton(Transform path, string text, string id, VRC.Player user)
        {
            _ButtonGameobject = new GameObject("BTN_" + id);
            _ButtonGameobject.transform.parent = path;
            _ButtonGameobject.transform.localScale = new Vector3(8.7f, 0.7f, 1);
            _ButtonGameobject.transform.localPosition = Vector3.zero;
            _ButtonGameobject.transform.localEulerAngles = Vector3.zero;
            _ButtonIcon = GameObject.Instantiate(_ButtonGameobject, _ButtonGameobject.transform).gameObject;
            _Text = GameObject.Instantiate(_ButtonIcon, _ButtonIcon.transform).gameObject;
            _ButtonIcon.transform.localPosition = new Vector3(-1.6f, 0, 0);
            _ButtonIcon.transform.localScale = new Vector3(0.93f, 0.7f, 1);
            _ButtonIcon.gameObject.AddComponent<UnityEngine.UI.Image>().color = new Color(0, 0, 0, 0.5f);
            _ButtonComponent = _ButtonGameobject.AddComponent<UnityEngine.UI.Button>();
            _ButtonGameobject.AddComponent<UnityEngine.UI.Button>();
            _ButtonGameobject.AddComponent<LayoutElement>();
            _TextComponent = _Text.AddComponent<TMPro.TextMeshProUGUI>();
            _TextComponent.richText = true;
            _TextComponent.enableWordWrapping = false;
            _TextComponent.text = text;
            _TextComponent.alignment = TMPro.TextAlignmentOptions.Left;
            _TextComponent.transform.localScale = new Vector3(0.1f, 1.2f, 1);
            _TextComponent.fontSize = 49;
            _TextComponent.transform.localPosition = new Vector3(-40, 0, 0);
            _ButtonComponent.onClick.AddListener(new Action(() => VRC.DataModel.UserSelectionManager.field_Private_Static_UserSelectionManager_0.Method_Public_Void_APIUser_2(user.field_Private_APIUser_0)));
            Apis.Change_Image.Loadfrombytes(_ButtonIcon, Settings.Download_Files.imagehandler.quickmenumask);
        }
      
    }
}
