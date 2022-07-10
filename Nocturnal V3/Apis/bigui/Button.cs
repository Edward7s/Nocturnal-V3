using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.bigui
{
    internal class BButton
    {
        private GameObject _ButtonGameobject { get; set; }
        private UnityEngine.UI.Button _ButtonComp { get; set; }
        private LayoutElement _layoutElement { get; set; }

        ~BButton()
        {
            this._ButtonGameobject = null;
            this._ButtonComp = null;
            this._layoutElement = null;
        }
        public BButton(bool paramd,string name, GameObject path, Action action ,Vector3? size = null)
        {
             _ButtonGameobject = GameObject.Instantiate(Objects._Bbutton, path.transform);
            Component.DestroyImmediate(_ButtonGameobject.GetComponent<VRCUiButton>());
            _ButtonGameobject.name = "NBTN_" + name;
            _ButtonGameobject.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = name;
             _ButtonComp = _ButtonGameobject.gameObject.GetComponent<Button>();
            _ButtonComp.onClick.RemoveAllListeners();
            _ButtonComp.onClick.AddListener(action);
            _ButtonGameobject.transform.localEulerAngles = Vector3.zero;
            _layoutElement = _ButtonGameobject.GetComponent<LayoutElement>();
            _layoutElement.minHeight = 30;
            _layoutElement.minWidth = 30;
            Component.DestroyImmediate(_ButtonGameobject.transform.Find("Image").GetComponent<Image>());
            if (size == null) return;
            _ButtonGameobject.transform.localScale = (Vector3)size;
        }
        public BButton(string name, GameObject path, Action action,Vector3? size = null,string Buttonname = "Default")
        {
            _ButtonGameobject = GameObject.Instantiate(Objects._Bbutton, path.transform);
            Component.DestroyImmediate(_ButtonGameobject.GetComponent<VRCUiButton>());
            _ButtonGameobject.name = Buttonname;
            _ButtonGameobject.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = name;
            _ButtonComp = _ButtonGameobject.gameObject.GetComponent<Button>();
            _ButtonComp.onClick.RemoveAllListeners();
            _ButtonComp.onClick.AddListener(action);
            _ButtonGameobject.transform.localEulerAngles = Vector3.zero;
            _layoutElement = _ButtonGameobject.GetComponent<LayoutElement>();
            _layoutElement.minHeight = 30;
            _layoutElement.minWidth = 30;
            if (size == null) return;
            _ButtonGameobject.transform.localScale = (Vector3)size;
            _ButtonGameobject.gameObject.SetActive(true);

        }
        public BButton(out GameObject Instance, string name, GameObject path, Action action)
        {
            _ButtonGameobject = GameObject.Instantiate(Objects._Bbutton, path.transform);
            Component.DestroyImmediate(_ButtonGameobject.GetComponent<VRCUiButton>());
            _ButtonGameobject.name = "NBTN_" + name;
            _ButtonGameobject.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = name;
            _ButtonComp = _ButtonGameobject.gameObject.GetComponent<Button>();
            _ButtonComp.onClick.RemoveAllListeners();
            _ButtonComp.onClick.AddListener(action);
            _ButtonGameobject.transform.localEulerAngles = Vector3.zero;
            Instance = _ButtonGameobject;
            _ButtonGameobject.gameObject.SetActive(true);
        }
       
    }
}
