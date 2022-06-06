using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;
namespace Nocturnal.Monobehaviours
{
    internal class Boomorbit : MonoBehaviour
    {

        private static bool firstpickup = true;
        public Boomorbit(IntPtr ptr) : base(ptr)
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

            for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
            {
                VRC.SDKBase.Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, Exploits.Pickups.Pickupsobs[i].gameObject);
                Exploits.Pickups.Pickupsobs[i].transform.position = this.transform.position;
            }
            GameObject.Destroy(gameObject);
        }
        }
    }
