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
        internal static GameObject _UpdateManager { get; set; }
        internal static GameObject _FlyManager { get; set; }
        internal static GameObject _ItemMover { get; set; }

        internal static void Inject()
        {

            _UpdateManager = new GameObject("NocturnalUpdateManager");
            _UpdateManager.transform.parent = GameObject.Find("/_Application").transform;
            _UpdateManager.AddComponent<Monobehaviours.UpdateManager>();
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Social").gameObject.AddComponent<Monobehaviours.Pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.AddComponent<Monobehaviours.Pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo").gameObject.AddComponent<Monobehaviours.Pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").gameObject.AddComponent<Monobehaviours.Pagemanager>();
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject.AddComponent<Monobehaviours.Pagemanager>();
            _FlyManager = new GameObject("Nocturnal Fly");
            _FlyManager.transform.parent = GameObject.Find("/_Application").transform;
            _FlyManager.AddComponent<Monobehaviours.Fly>().gameObject.SetActive(false);
            _ItemMover = new GameObject("Item Mover");
            _ItemMover.transform.parent = GameObject.Find("/_Application").transform;
            _ItemMover.gameObject.SetActive(false);
            _ItemMover.AddComponent<Monobehaviours.ItemMover>();
        }
    }
}
