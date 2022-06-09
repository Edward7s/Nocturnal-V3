using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Nocturnal.Ui
{
    internal class Inject_monos
    {
        internal static void Inject()
        {
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social").gameObject.AddComponent<Monobehaviours.Pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.AddComponent<Monobehaviours.Pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo").gameObject.AddComponent<Monobehaviours.Pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").gameObject.AddComponent<Monobehaviours.Pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.AddComponent<Monobehaviours.Pagemanager>();
            GameObject flym = new GameObject("Nocturnal Fly");
            flym.transform.parent = GameObject.Find("/_Application").transform;
                flym.AddComponent<Monobehaviours.Fly>().gameObject.SetActive(false);
        }
    }
}
