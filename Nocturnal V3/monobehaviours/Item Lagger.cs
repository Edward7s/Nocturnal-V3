using System;
using UnityEngine;
using VRC.SDKBase;
namespace Nocturnal.Monobehaviours
{
    internal class ItemLagger : MonoBehaviour
    {

        private static bool back = true;
        public ItemLagger(IntPtr ptr) : base(ptr) { }
        

        void OnEnable() => InvokeRepeating(nameof(Lag), -1, 0.2f);
        void OnDisable() => CancelInvoke(nameof(Lag));

        void Lag()
        {
            back = !back;
            if (!back)
            {
                for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                {
                    Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, Exploits.Pickups.Pickupsobs[i].gameObject);
                    Exploits.Pickups.Pickupsobs[i].transform.localPosition = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
                }
                return;
            }

            for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
            {
                Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, Exploits.Pickups.Pickupsobs[i].gameObject);
                Exploits.Pickups.Pickupsobs[i].transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }
}
