using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;
namespace Nocturnal.monobehaviours
{
    internal class boomorbit : MonoBehaviour
    {

        private static bool firstpickup = true;
        public boomorbit(IntPtr ptr) : base(ptr)
        {

        }

        void Start()
        {
            firstpickup = true;
        }

         void Update()
        {
            if (!firstpickup) return;
            VRCPlayerApi owner = this.gameObject.GetComponent<VRC.SDKBase.VRC_Pickup>().currentPlayer;
            if (owner == null) return;
           firstpickup = false;
           this.GetComponent<Rigidbody>().useGravity = true;
            
        }

        void OnCollisionEnter(Collision col)
        {
            if (firstpickup) return;
            if (this.gameObject.GetComponent<VRC.SDKBase.VRC_Pickup>().currentPlayer != null) return;

            for (int i = 0; i < exploits.pickups.pickupsobs.Length; i++)
            {
                VRC.SDKBase.Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, exploits.pickups.pickupsobs[i].gameObject);
                exploits.pickups.pickupsobs[i].transform.position = this.transform.position;
            }
            GameObject.Destroy(gameObject);
        }
        }
    }
