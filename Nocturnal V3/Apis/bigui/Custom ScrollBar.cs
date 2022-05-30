using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.BigUI
{
	internal class CustomScrollbar
	{
		internal static Scrollbar Scroll(GameObject path, float x, float y, float sizeX, float sizeY)
		{
			var scrollbar = GameObject.Instantiate(Ui.Objects.scrollbarObj, path.transform).gameObject;
			// Component.DestroyImmediate(scrollbar.GetComponent<VRC.UI.Core.Styles.StyleElement>());
			//  Component.DestroyImmediate(scrollbar.transform.Find("Sliding Area/Handle").gameObject.GetComponent<VRC.UI.Core.Styles.StyleElement>());

			scrollbar.transform.localScale = new Vector3(sizeX, sizeY, 1);
			scrollbar.transform.rotation = new Quaternion(0, 0, 0, 0);
			scrollbar.transform.localPosition = new Vector3(x * 10, y * 10, 1);
			return scrollbar.GetComponent<Scrollbar>();
		}
	}
}
