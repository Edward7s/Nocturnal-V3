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
        internal static void inject()
        {
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social").gameObject.AddComponent<monobehaviours.pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.AddComponent<monobehaviours.pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo").gameObject.AddComponent<monobehaviours.pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").gameObject.AddComponent<monobehaviours.pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.AddComponent<monobehaviours.pagemanager>();

        }
    }
}
