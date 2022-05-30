using Nocturnal.Ui;
using System;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.BigUI
{
	internal class BigButton
	{
		internal static GameObject NormalButton(string name, GameObject path, Action action)
		{
			var button = GameObject.Instantiate(Objects.bigButton, path.transform);
			Component.DestroyImmediate(button.GetComponent<VRCUiButton>());
			button.name = "NBTN_" + name;
			button.transform.Find("Image/Text").gameObject.GetComponent<Text>().text = name;
			var btnComp = button.gameObject.GetComponent<Button>();
			btnComp.onClick.RemoveAllListeners();
			btnComp.onClick.AddListener(action);
			button.transform.localEulerAngles = Vector3.zero;
			return button;
		}
	}
}
