﻿using Nocturnal.Settings;
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
        private GameObject _SecondCamera = null;
        private bool _Isthirdpersonback = false;
        private bool _Isthirdp = false;
        private System.Diagnostics.Process _CurentProcess { get; set; }
        private GUIStyle _GUIStlye { get; set; }
        internal static string User { get; set; }
        internal static string Rank { get; set; }

        public UpdateManager(IntPtr ptr) : base(ptr)
        {

        }

        void Start()
        {
           NocturnalC.Log("Initializing OnUpdate And OnGui", "Monobehaviour",ConsoleColor.Green);
            _CurentProcess = System.Diagnostics.Process.GetCurrentProcess();
            InvokeRepeating(nameof(updatehud), -1, 1.5f);
            _GUIStlye = new GUIStyle();
            _GUIStlye.fontSize = 17;
            _GUIStlye.richText = false;
            _GUIStlye.wordWrap = false;
            _GUIStlye.normal.textColor = Color.white;
        }

        void updatehud()
        {
            if (!Settings.ConfigVars.hudUi)
                return;
                try
                {
                    Ui.Qm_basic._GUIInfo.text = $"{string.Format("{0:hh:mm:ss tt}", DateTime.Now)}\nLobby: {Hooks._PlayersInLobby}/{Hooks._RoomCapacity}\nF: {Ui.Objects._OnlineFriends.Count}/{Ui.Objects._OfflineFriends.Count}\nIn: {Settings.Hooks._TypeOfWorld}" +
                        $"\nGtime: {_CurentProcess.UserProcessorTime.Hours}:{_CurentProcess.UserProcessorTime.Minutes}:{_CurentProcess.UserProcessorTime.Seconds}";
                }
                catch { }
        }



        void OnGUI()
        {
            if (Hooks._IsInVr) return;
            try
            {
                GUI.Label(new Rect(Screen.width / 1.4f, 0, 0, 0), $"[{string.Format("{0:hh:mm:ss tt}", DateTime.Now)}] [{Hooks._TypeOfWorld}] [{Hooks._PlayersInLobby}/{Hooks._RoomCapacity}] [F:{Ui.Objects._OnlineFriends.Count}/{Ui.Objects._OfflineFriends.Count}] [Fps:{(int)(1.0f / Time.smoothDeltaTime)}] [Ping{VRC.Player.prop_Player_0.prop_PlayerNet_0.field_Private_Int16_0}]", _GUIStlye) ;
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
