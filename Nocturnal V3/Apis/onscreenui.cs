using System.Collections;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis
{
	internal class OnScreenUI
	{
		private static GameObject textGameObject;
		private static TMPro.TextMeshProUGUI tmpro;
		private static int countdown = 0;
		internal static void GenerateUIMessage()
		{
			var toinst = GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/AlertTextParent/Capsule").gameObject;
			textGameObject = GameObject.Instantiate(toinst, GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud"));
			textGameObject.SetActive(true);
			textGameObject.GetComponent<UnityEngine.UI.ContentSizeFitter>().verticalFit = ContentSizeFitter.FitMode.PreferredSize;
			textGameObject.name = "ONscreennotui";
			textGameObject.transform.localPosition = new Vector3(150, 0, 0);
			tmpro = textGameObject.GetComponentInChildren<TMPro.TextMeshProUGUI>();
			tmpro.alignment = TMPro.TextAlignmentOptions.TopLeft;
			tmpro.fontSize = 17;
			tmpro.richText = true;
			textGameObject.gameObject.SetActive(false);
		}

		internal static void ShowMessage(string strings) => MelonLoader.MelonCoroutines.Start(ShowMessageIEnumerator(strings));



		internal static IEnumerator ShowMessageIEnumerator(string strings)
		{
			if (!Settings.ConfigVars.toggleonscreenlogger)
				yield break;
			tmpro.text += strings + "\n";

			if (countdown == 0)
			{
				textGameObject.SetActive(true);
				countdown = 3;
				while (countdown > 0)
				{
					yield return new WaitForSeconds(1f);
					countdown -= 1;

					if (countdown == 1)
					{
						tmpro.text = "";
						textGameObject.SetActive(false);
						countdown = 0;

					}




				}
			}
			else
			{
				textGameObject.SetActive(true);
				countdown = 3;
			}


			yield return null;
		}

	}
}
