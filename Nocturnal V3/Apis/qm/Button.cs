using Nocturnal.Ui;
using System;
using UnityEngine;
namespace Nocturnal.Apis.QM
{
	internal class Button
	{
		internal static GameObject Create(GameObject path, string name, Action action, bool half = false, byte[] img = null, float X = 628, float Y = 628)
		{
			float yvalue = half ? -140 - (Y * (200 / 2) - 45) : -140 - Y * 200;

			var button = GameObject.Instantiate(Objects.buttonPrefab, path.transform);
			button.transform.Find("Text_H4").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = name;
			button.name = "_Button_" + name;
			var buttoncomp = button.gameObject.GetComponent<UnityEngine.UI.Button>();
			buttoncomp.onClick.RemoveAllListeners();
			buttoncomp.onClick.AddListener(action);
			button.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = name;

			if (X != 628 && Y != 628)
			{
				button.transform.localPosition = new Vector3(-350 + X * 240, yvalue);
			}
			if (img != null)
			{
				Component.DestroyImmediate(button.transform.Find("Icon").GetComponent<VRC.UI.Core.Styles.StyleElement>());
				button.transform.Find("Icon").gameObject.Loadfrombytes(img);
				button.transform.Find("Icon").gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0.415f, 0.89f, 0.976f, 1);


			}
			if (!half)
				return button;

			button.transform.Find("Background").gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(0, -90);
			var ico = button.transform.Find("Icon").gameObject;
			ico.transform.localScale = new Vector3(0.5f, 0.5f, 1);
			ico.transform.localPosition = new Vector3(-75.5186f, 18.8227f, 0);
			var text = button.transform.Find("Text_H4").gameObject;
			text.transform.localScale = new Vector3(0.9f, 0.9f, 1);
			text.transform.localPosition = new Vector3(18.58f, -21.0801f, 0);


			return button;
		}
	}
}
