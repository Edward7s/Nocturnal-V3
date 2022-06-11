using System;
using UnityEngine;
using VRC.SDKBase;
namespace Nocturnal.Monobehaviours
{
    internal class Svastica : MonoBehaviour
    {
        internal static GameObject orbitplace = null;
        internal static float size = 0.1f;

        public Svastica(IntPtr ptr) : base(ptr)
        {

        }

        void Start()
        {
            orbitplace = new GameObject("Svastica");
        }


        void LateUpdate()
        {
            orbitplace.transform.position = Settings.wrappers.Target.targertuser.prop_VRCPlayer_1.field_Internal_Animator_0.GetBoneTransform(HumanBodyBones.Head).position;
            float last = 0;
            float lasten = 0;

            bool firstv =false;
            float xval = 0;
            float xval2 = 0;
            float yval2 = 0;

            for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
            {






                VRC.SDKBase.Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0,Exploits.Pickups.Pickupsobs[i].gameObject);
                //   Exploits.Pickups.Pickupsobs[i].transform.LookAt(orbitplace.transform);
                Exploits.Pickups.Pickupsobs[i].transform.Rotate(new Vector3(0, 360 / Exploits.Pickups.Pickupsobs.Length, 0));
                if (i < Exploits.Pickups.Pickupsobs.Length / 3)
                {
                    if (i != 0)
                    {
                        Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(Exploits.Pickups.Pickupsobs[i - 1].transform.position.x, Exploits.Pickups.Pickupsobs[i - 1].transform.position.y + size, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                        last = Exploits.Pickups.Pickupsobs[i].transform.position.y;
                        lasten = i;
                        continue;
                    }

                    Exploits.Pickups.Pickupsobs[i].transform.position = orbitplace.transform.position;
                    continue;
                }
                if (i < Exploits.Pickups.Pickupsobs.Length / 2.5f)
                {
                    Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(Exploits.Pickups.Pickupsobs[i - 1].transform.position.x - size * 1.1f, last - (size * lasten - size) /2 , Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                    xval = Exploits.Pickups.Pickupsobs[i].transform.position.x;

                    continue;
                }
                if (i < Exploits.Pickups.Pickupsobs.Length / 2)
                {
                    if (!firstv)
                    {
                        Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(orbitplace.transform.position.x, last + (size * lasten - size) / 2, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                        firstv = true;
                        continue;
                    }
                    Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(Exploits.Pickups.Pickupsobs[i - 1].transform.position.x + size * 1.1f, last - (size * lasten - size) / 2, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                    xval2 = Exploits.Pickups.Pickupsobs[i].transform.position.x;
                    yval2 = Exploits.Pickups.Pickupsobs[i].transform.position.y;
                    continue;
                }
                if (i < Exploits.Pickups.Pickupsobs.Length / 1.75f)
                {
                    if (firstv)
                    {
                        Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(orbitplace.transform.position.x - size / 2, last, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                        firstv = false;
                        continue;

                    }
                    Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(Exploits.Pickups.Pickupsobs[i - 1].transform.position.x - size / 2, last, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                    continue;
                }
                if (i < Exploits.Pickups.Pickupsobs.Length / 1.5f)
                {
                    if (!firstv)
                    {
                        Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(orbitplace.transform.position.x + size / 2, last, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                        firstv = true;
                        continue;

                    }
                    Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(Exploits.Pickups.Pickupsobs[i - 1].transform.position.x + size / 2, orbitplace.transform.position.y, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                    continue;
                }
                if (i < Exploits.Pickups.Pickupsobs.Length / 1.25f)
                {
                    if (firstv)
                    {
                        Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(xval, yval2 - size / 2, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                        firstv = false;
                        continue;

                    }

                    Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(xval , Exploits.Pickups.Pickupsobs[i - 1].transform.position.y - size / 2, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                    continue;
                }
              if (i < Exploits.Pickups.Pickupsobs.Length)
                {
                    if (!firstv)
                    {
                    Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(xval2, yval2 + size / 2, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                        firstv = true;
                        continue;
                    }

                    Exploits.Pickups.Pickupsobs[i].transform.position = new Vector3(xval2, Exploits.Pickups.Pickupsobs[i - 1].transform.position.y + size /2, Exploits.Pickups.Pickupsobs[i - 1].transform.position.z);
                    continue;
                }





            }

        }




    }
}
