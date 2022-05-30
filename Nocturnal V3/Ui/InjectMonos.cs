using UnityEngine;
namespace Nocturnal.Ui
{
	internal class InjectMonos
	{
		internal static void Run()
		{
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social").gameObject.AddComponent<MonoBehaviours.PageManager>();
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.AddComponent<MonoBehaviours.PageManager>();
			GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo").gameObject.AddComponent<MonoBehaviours.PageManager>();
			GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").gameObject.AddComponent<MonoBehaviours.PageManager>();
			GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.AddComponent<MonoBehaviours.PageManager>();

		}
	}
}
