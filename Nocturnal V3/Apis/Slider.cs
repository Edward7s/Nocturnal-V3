using System;
using UnityEngine;
namespace Nocturnal.Apis
{
	internal class Slider
	{
#pragma warning disable IDE0060 // Remove unused parameter
		internal static GameObject Create(GameObject parent, Action<float> setOutput, float prevolume = 876.412f, Action todo = null, bool onqm = false, string title = "")
#pragma warning restore IDE0060 // Remove unused parameter
		{
			var path = parent.transform;
			if (onqm)
			{
				var slider = new GameObject("Slider");
				slider.transform.parent = parent.transform;
				slider.AddComponent<UnityEngine.UI.LayoutElement>();
				slider.transform.localPosition = Vector3.zero;
				slider.transform.localScale = Vector3.one;
				slider.transform.localEulerAngles = Vector3.zero;
				var newgmj = new GameObject("Blank");
				newgmj.transform.parent = parent.transform;
				newgmj.AddComponent<UnityEngine.UI.LayoutElement>();
				path = slider.transform;
			}
			var toinst = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Settings/VolumePanel/VolumeGameAvatars").gameObject;
			var instanciated = GameObject.Instantiate(toinst, path);
			Component.DestroyImmediate(instanciated.GetComponent<UiSettingConfig>());
			GameObject.DestroyImmediate(instanciated.transform.Find("Label").gameObject);
			instanciated.transform.rotation = new Quaternion(0, 0, 0, 0);
			instanciated.transform.localScale = new Vector3(1, 1, 1);
			instanciated.transform.localPosition = new Vector3(0, 0, 1);

			var sliderg = instanciated.GetComponent<UnityEngine.UI.Slider>();
			if (prevolume != 876.412f)
				sliderg.value = (float)prevolume;
			sliderg.onValueChanged.RemoveAllListeners();
			sliderg.m_OnValueChanged.RemoveAllListeners();
			var slidertext = instanciated.transform.Find("SliderLabel").GetComponent<UnityEngine.UI.Text>();
			slidertext.text = $"{prevolume * 100}%";
			sliderg.onValueChanged.AddListener((UnityEngine.Events.UnityAction<float>)sliderstuff);

			void sliderstuff(float values)
			{

				slidertext.text = $"{values * 100}%";
				setOutput(values);
				if (todo != null)
					todo.Invoke();
			}
			if (onqm)
			{
				instanciated.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(440, 70);
				instanciated.transform.Find("SliderLabel").transform.localScale = new Vector3(1.1f, 1.1f, 1);
				var bg = GameObject.Instantiate(slidertext.gameObject, slidertext.transform.parent);
				var textcomp = bg.gameObject.GetComponent<UnityEngine.UI.Text>();
				textcomp.text = title;
				textcomp.horizontalOverflow = HorizontalWrapMode.Overflow;
				bg.transform.localPosition = new Vector3(225, -15, 1);
				instanciated.transform.localPosition = new Vector3(-100, 0, 1);
			}

			return instanciated.gameObject;
		}
	}
}

