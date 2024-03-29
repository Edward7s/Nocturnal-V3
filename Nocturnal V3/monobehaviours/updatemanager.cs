﻿using Nocturnal.Settings;
using System;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using System.Linq;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.XR;
using System.Threading;

namespace Nocturnal.Monobehaviours
{
    internal class UpdateManager : MonoBehaviour
    {
        private GameObject _SecondCamera = null;
        private bool _Isthirdpersonback = false;
        private bool _Isthirdp = false;
        private UnityEngine.Rendering.PostProcessing.PostProcessLayer _postProc {get;set;}

        private GUIStyle _GUIStlye { get; set; }
        internal static string User { get; set; }
        internal static string Rank { get; set; }

        public UpdateManager(IntPtr ptr) : base(ptr)
        {

        }

        void Start()
        {
            NocturnalC.Log("Initializing OnUpdate And OnGui", "Monobehaviour",ConsoleColor.Green);
            InvokeRepeating(nameof(updatehud), -1, 2f);
            _GUIStlye = new GUIStyle();
            _GUIStlye.fontSize = 17;
            _GUIStlye.richText = false;
            _GUIStlye.wordWrap = false;
            _GUIStlye.normal.textColor = Color.white;
        }

        void updatehud()
        {
            try { if (VRC.Player.prop_Player_0.gameObject == null) return; } catch { return; }

            try
            {
                if (Main2._queueDictionary.Count != 0)
                {
                    for (int i = 0; i < Main2._queueDictionary.Count; i++)
                        Main2._queueDictionary.ElementAt(i).Value.Invoke();

                }
            }
            catch { }


            if (!Settings.ConfigVars.QmHud)
                return;
            try
            {
                Ui.Qm_basic._GUIInfo.text = $"{string.Format("{0:hh:mm:ss tt}", DateTime.Now)}\nLobby: {Hooks._PlayersInLobby}/{Hooks._RoomCapacity}\nF: {Ui.Objects._OnlineFriends.Count}/{Ui.Objects._OfflineFriends.Count}\nIn: {Settings.Hooks._TypeOfWorld}" +
                    $"\nGtime: {Main2._CurentP.UserProcessorTime.Hours}:{Main2._CurentP.UserProcessorTime.Minutes}:{Main2._CurentP.UserProcessorTime.Seconds}";
            }
            catch { }
        }


        void StopObjs() => Exploits.Pickups.Stopobjs();
        void OwnerPickups() => Exploits.Pickups.Ownerpickups();
        void OrbitUser() => Exploits.Orbit.orbituser();

        private int _Flycount { get; set; } = 0;
        private float _Time { get; set; } = 0;

        /*    IEnumerator StartVr(bool toggle)
            {
              //  for (int i = 0; i < XRSettings.supportedDevices.Length; i++)
                  //  NocturnalC.Log(XRSettings.supportedDevices[i]);

                    if (toggle)
                {
                    XRSettings.LoadDeviceByName("OpenVR");
                    yield return new WaitForSeconds(1f);
                    XRSettings.enabled = toggle;
                    VRC.SDKBase.Networking.GoToRoom(RoomManager.prop_String_0);
                    yield break;
                }
                XRSettings.LoadDeviceByName("None");
                yield return new WaitForSeconds(1f);
                XRSettings.enabled = toggle;
                yield break;


             if (Input.GetKeyDown(KeyCode.G))
                {
                    XRSettings.LoadDeviceByName("OpenVR");
                    XRSettings.enabled = true;

                }
            }*/



        void LateUpdate()
        {
            try { if (VRC.Player.prop_Player_0.gameObject == null) return; } catch { return; }
            
            if (Settings.ConfigVars.bhop && Input.GetKey(KeyCode.Space) || Settings.ConfigVars.bhop && Input.GetKey(KeyCode.JoystickButton1))
                if (VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0.IsPlayerGrounded()) Exploits.Misc.Jump();

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
                            GameObject.Destroy(_SecondCamera);
                            _SecondCamera = null;
                            Settings.Hooks.cameraeye.gameObject.SetActive(true);
                            _Isthirdp = false;

                        }
                        else if (!_Isthirdpersonback)
                        {

                            _SecondCamera = new GameObject("Camera Holder");
                            _SecondCamera.AddComponent<Camera>();
                            _postProc = _SecondCamera.AddComponent<PostProcessLayer>();
                            _postProc.volumeLayer = 16;
                            _postProc.m_Resources = Resources.FindObjectsOfTypeAll<UnityEngine.Rendering.PostProcessing.PostProcessResources>().Where(x => x.name == "DefaultPostProcessResources").FirstOrDefault();


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

                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown (KeyCode.JoystickButton1))
                {
                    if (Settings.ConfigVars.forcejump)
                        Exploits.Misc.Jump();
                    _Flycount++;
                }
                if (_Flycount != 0)
                {
                    _Time += Time.smoothDeltaTime;
                    if (_Time > 0.7f)
                    {
                        _Flycount = 0;
                        _Time = 0;
                    }
                    else if (_Flycount > 1)
                    {
                        if (Settings.ConfigVars.RocketJump)
                            Exploits.Misc.Jump(3);

                        if (Settings.ConfigVars.DoubleSpaceFly)
                            Ui.Inject_monos._FlyManager.SetActive(!Ui.Inject_monos._FlyManager.activeSelf);
                        _Flycount = 0;
                        _Time = 0;
                    }
                }

            }
            catch { }
          
            Exploits.Zoom._Zoom();
     //       Apis.KeyBindsManager.ManageKeybinds();
        }


        void OnGUI()
        {
            if (Hooks._IsInVr) return;
            try
            {
                GUI.Label(new Rect(Screen.width / 1.4f, 0, 0, 0), $"[{string.Format("{0:hh:mm:ss tt}", DateTime.Now)}] [{Hooks._TypeOfWorld}] [{Hooks._PlayersInLobby}/{Hooks._RoomCapacity}] [F:{Ui.Objects._OnlineFriends.Count}/{Ui.Objects._OfflineFriends.Count}] [Fps:{(int)(1.0f / Time.smoothDeltaTime)}] [Ping:{VRC.Player.prop_Player_0.prop_PlayerNet_0.field_Private_Int16_0}]", _GUIStlye);
            }
            catch { }
        }



    }
}
