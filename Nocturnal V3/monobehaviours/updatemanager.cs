using System;
using UnityEngine;
using VRC.SDKBase;
namespace Nocturnal.Monobehaviours
{
    internal class UpdateManager : MonoBehaviour
    {
        internal static GameObject secondcamera = null;
        internal static bool isthirdpersonback = false;
        internal static bool isthirdp = false;
        public UpdateManager(IntPtr ptr) : base(ptr)
        {

        }

        void Start()
        {
           NocturnalC.Log("Initializing OnUpdate And OnGui", "Monobehaviour",ConsoleColor.Green);
        }


        void LateUpdate()
        {
            if (VRC.Player.prop_Player_0.transform == null)
                return;


            if (Settings.ConfigVars.bhop && Input.GetKey(KeyCode.Space) || Settings.ConfigVars.bhop && Input.GetKey(KeyCode.JoystickButton1))
                if (VRC.SDKBase.Networking.LocalPlayer.GetVelocity().y == 0) Exploits.Misc.Jump();

            if (Input.GetKey(KeyCode.LeftControl))
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    Exploits.Fly.flytoggle = !Exploits.Fly.flytoggle;

                    Settings.wrappers.extensions.togglecontroller(!Exploits.Fly.flytoggle);
                    GameObject.Find("/_Application").transform.Find("Nocturnal Fly").gameObject.SetActive(Exploits.Fly.flytoggle);
                }

                if (Settings.ConfigVars.Thidperson)
                {
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        if (secondcamera != null && !isthirdpersonback)
                        {
                            GameObject.DestroyImmediate(secondcamera);
                            secondcamera = null;
                            Settings.Hooks.cameraeye.gameObject.SetActive(true);
                            isthirdp = false;

                        }
                        else if (!isthirdpersonback)
                        {

                            secondcamera = new GameObject("Camera Holder");
                            secondcamera.AddComponent<Camera>();
                            secondcamera.transform.parent = Settings.Hooks.cameraeye.transform;
                            secondcamera.transform.localEulerAngles = Vector3.zero;
                            secondcamera.transform.localScale = Vector3.one;
                            secondcamera.transform.localPosition = new Vector3(0, 0, -2);
                            Settings.Hooks.cameraeye.gameObject.SetActive(false);
                            isthirdpersonback = true;
                            isthirdp = true;
                        }
                        else
                        {
                            secondcamera.transform.localPosition = new Vector3(0, 0, 2);
                            secondcamera.transform.localEulerAngles = new Vector3(0, -180, 0);
                            isthirdpersonback = false;
                        }
                    }

                    if (isthirdp)
                    {
                        if (Input.mouseScrollDelta.y == 1)
                        {
                            secondcamera.transform.localPosition = new Vector3(0, 0, secondcamera.transform.localPosition.z - 0.15f);
                        }


                        if (Input.mouseScrollDelta.y == -1)
                        {
                            secondcamera.transform.localPosition = new Vector3(0, 0, secondcamera.transform.localPosition.z + 0.15f);
                        }
                    }

                }



            }
            try
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton1))
                {
                    if (Exploits.Sitonparts.issiting)
                    {
                        Exploits.Sitonparts.issiting = false;
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
