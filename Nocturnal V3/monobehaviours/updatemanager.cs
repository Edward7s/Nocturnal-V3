using Nocturnal.Settings;
using Nocturnal.Settings.wrappers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using VRC;
using VRC.SDKBase;
namespace Nocturnal.Monobehaviours
{
    internal class UpdateManager : MonoBehaviour
    {
        private static GameObject _SecondCamera = null;
        private static bool _Isthirdpersonback = false;
        private static bool _Isthirdp = false;
        private static VRC.UI.FriendsListManager _Friends { get; set; }
        private static System.Diagnostics.Process _CurentProcess { get; set; }

        public UpdateManager(IntPtr ptr) : base(ptr)
        {

        }

        void Start()
        {
           NocturnalC.Log("Initializing OnUpdate And OnGui", "Monobehaviour",ConsoleColor.Green);

            _Friends = Ui.Objects._friendlistmanager;
            _CurentProcess = System.Diagnostics.Process.GetCurrentProcess();

            InvokeRepeating(nameof(updatehud), -1, 1.5f);
            
        }

        void updatehud()
        {
            


            if (!Settings.ConfigVars.hudUi)
                return;
                
     
                int player = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.Count;
                try
                {
                    Ui.Qm_basic._GUIInfo.text = $"{string.Format("{0:hh:mm:ss tt}", DateTime.Now)}\nLobby: {player}\nF: {_Friends.field_Private_List_1_IUser_1.Count}/{_Friends.field_Private_List_1_IUser_0.Count}\nIn: {Settings.Hooks._TypeOfWorld}" +
                        $"\nGtime: {_CurentProcess.UserProcessorTime.Hours}:{_CurentProcess.UserProcessorTime.Minutes}:{_CurentProcess.UserProcessorTime.Seconds}";

                }
                catch { }


        }

  





       

     

       

        void LateUpdate()
        {
            if (Main2._Queue.Count != 0)
            {
                for (int i = 0; i < Main2._Queue.Count; i++)
                {
                    Main2._Queue.ToArray()[i].Invoke();
                }
             Main2._Queue.Clear();

            }

            try { if (VRC.Player.prop_Player_0.transform == null) return; } catch { return; }
            
            if (Settings.ConfigVars.bhop && Input.GetKey(KeyCode.Space) || Settings.ConfigVars.bhop && Input.GetKey(KeyCode.JoystickButton1))
                if (VRC.SDKBase.Networking.LocalPlayer.GetVelocity().y == 0) Exploits.Misc.Jump();

            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKeyDown(KeyCode.F))
                    Ui.Inject_monos._FlyManager.SetActive(!Ui.Inject_monos._FlyManager.activeSelf);


                if (Settings.ConfigVars.Thidperson)
                {
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        if (_SecondCamera != null && !_Isthirdpersonback)
                        {
                            GameObject.DestroyImmediate(_SecondCamera);
                            _SecondCamera = null;
                            Settings.Hooks.cameraeye.gameObject.SetActive(true);
                            _Isthirdp = false;

                        }
                        else if (!_Isthirdpersonback)
                        {

                            _SecondCamera = new GameObject("Camera Holder");
                            _SecondCamera.AddComponent<Camera>();
                            _SecondCamera.transform.parent = Settings.Hooks.cameraeye.transform;
                            _SecondCamera.transform.localEulerAngles = Vector3.zero;
                            _SecondCamera.transform.localScale = Vector3.one;
                            _SecondCamera.transform.localPosition = new Vector3(0, 0, -2);
                            Settings.Hooks.cameraeye.gameObject.SetActive(false);
                            _Isthirdpersonback = true;
                            _Isthirdp = true;
                        }
                        else
                        {
                            _SecondCamera.transform.localPosition = new Vector3(0, 0, 2);
                            _SecondCamera.transform.localEulerAngles = new Vector3(0, -180, 0);
                            _Isthirdpersonback = false;
                        }
                    }

                    if (_Isthirdp)
                    {
                        if (Input.mouseScrollDelta.y == 1)
                        {
                            _SecondCamera.transform.localPosition = new Vector3(0, 0, _SecondCamera.transform.localPosition.z - 0.15f);
                        }


                        if (Input.mouseScrollDelta.y == -1)
                        {
                            _SecondCamera.transform.localPosition = new Vector3(0, 0, _SecondCamera.transform.localPosition.z + 0.15f);
                        }
                    }

                }



            }
            try
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton1))
                {
                    if (Exploits.Sitonparts._IsSiting)
                    {
                        Exploits.Sitonparts._IsSiting = false;
                        Settings.wrappers.extensions.togglecontroller(true);
                    }
                    if (Settings.ConfigVars.infinitejump)
                        Exploits.Misc.Jump();


                }

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton1))
                {
                    if (Networking.LocalPlayer.GetJumpImpulse() == 0)
                        Networking.LocalPlayer.SetJumpImpulse(1);
                    if (Settings.ConfigVars.forcejump)
                        Exploits.Misc.Jump();
                }


            }
            catch { }
            Exploits.Pickups.Stopobjs();
            Exploits.Pickups.Ownerpickups();
            Exploits.Orbit.orbituser();
            Exploits.Zoom._Zoom();
        }

       

       
    }
}
