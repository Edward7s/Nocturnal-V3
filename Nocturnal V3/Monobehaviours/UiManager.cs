using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
namespace Nocturnal.Monobehaviours
{
    internal class UiManager : MonoBehaviour
    {

        public UiManager(IntPtr ptr) : base(ptr)
        {

        }
        private Thread t_socketThread = new Thread(server.setup.serversetup);


        void Start()
        {

            InvokeRepeating(nameof(WaitForUserInterface), -1, 0.05f);
            InvokeRepeating(nameof(WaitForApiUser), -1, 0.05f);
            InvokeRepeating(nameof(WaitForAvatars), -1, 2f);
            InvokeRepeating(nameof(WaitForTab), -1, 0.05f);

            Exploits.Anticrash.s_shaderArr = Resources.FindObjectsOfTypeAll<Shader>();
           
  
        }
        void WaitForUserInterface()
        {
            if (GameObject.Find("/UserInterface") == null) return;
            NocturnalC.Log("Founded UserInteface");
            Ui.Bundles.loadnotifications();
            var images = Resources.FindObjectsOfTypeAll<ImageThreeSlice>().ToArray();
            for (int i = 0; i < images.Length; i++)
                images[i].raycastTarget = false;
            Ui.LoadingScreen.runti();
            InvokeRepeating(nameof(WaitForQuickMenu), -1, 0.05f);
            CancelInvoke(nameof(WaitForUserInterface));

        }

        void WaitForApiUser()
        {
            if (VRC.Core.APIUser.CurrentUser == null) return;
            NocturnalC.Log("User Logged in");
            Console.Title = $"Nocturnal V3 {{Welcome: [{VRC.Core.APIUser.CurrentUser.displayName}]}}";
            t_socketThread.Start();
            MelonCoroutines.Start(Settings.wrappers.extensions.clientmessagewaiter($"Hi {VRC.Core.APIUser.CurrentUser.displayName} <3"));
            CancelInvoke(nameof(WaitForApiUser));

        }

        void WaitForQuickMenu()
        {

            if (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)") == null) return;
            NocturnalC.Log("Founded QuickMenu");
            Ui.Bundles.Loadshader();
            Ui.Bundles.Loadingscreen();
            Ui.Objects.Collectobjs();
            Ui.Qm_basic.Setupstuff();
            Ui.Inject_monos.Inject();
            Ui.buttons_b.Runbuttons();

            InvokeRepeating(nameof(WaitForWindow), -1, 0.05f);
            CancelInvoke(nameof(WaitForQuickMenu));

        }

        void WaitForWindow()
        {
          
            if (GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window").gameObject.GetComponent<BoxCollider>() == null) return;
            GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window").gameObject.GetComponent<BoxCollider>().extents = new Vector3(880, 712, 0.5f);
            CancelInvoke(nameof(WaitForWindow));

        }

        void WaitForTab()
        {
            if (GameObject.FindObjectOfType<VRC.UI.Elements.MenuStateController>() == null) return;
            NocturnalC.Log("Initializing Custom Menu");
            Ui.qm.Main.Createmenu();
            Ui.resourceimages.Setupc();
            CancelInvoke(nameof(WaitForTab));
        }

        void WaitForAvatars()
        {
            try
            {
                if (GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/FavoriteContent/avatars1") == null) return;

            }
            catch {

                return;
            }
            Ui.Favorites.Run();
            CancelInvoke(nameof(WaitForAvatars  ));

        }

    }
}
