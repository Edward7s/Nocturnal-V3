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
        ~BButton()
        {
            this._ButtonGameobject = null;
            this._ButtonComp = null;
        }
        public BButton(string name, GameObject path, Action action)
        {
            _ButtonGameobject = GameObject.Instantiate(Objects._Bbutton, path.transform);
            Component.DestroyImmediate(_ButtonGameobject.GetComponent<VRCUiButton>());
            _ButtonGameobject.name = "NBTN_" + name;
            _ButtonGameobject.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = name;
            _ButtonComp = _ButtonGameobject.gameObject.GetComponent<Button>();
            _ButtonComp.onClick.RemoveAllListeners();
            _ButtonComp.onClick.AddListener(action);
            _ButtonGameobject.transform.localEulerAngles = Vector3.zero;
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
        }
       
    }
}
