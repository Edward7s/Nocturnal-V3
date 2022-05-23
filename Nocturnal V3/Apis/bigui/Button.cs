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
        internal static GameObject NormalButton(string name,GameObject path, Action action)
        {
            var _Button = GameObject.Instantiate(objects.Bbutton, path.transform);
            Component.DestroyImmediate(_Button.GetComponent<VRCUiButton>());
            _Button.name = "NBTN_" + name;
            _Button.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = name;
            var btncomp = _Button.gameObject.GetComponent<Button>();
            btncomp.onClick.RemoveAllListeners();
            btncomp.onClick.AddListener(action);
            return _Button;
        }
    }
}
