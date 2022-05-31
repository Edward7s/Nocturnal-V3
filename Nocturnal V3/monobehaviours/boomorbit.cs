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
            var owner = this.gameObject.GetComponent<VRC.SDKBase.VRC_Pickup>().currentPlayer;
            if (owner == null) return;
           firstpickup = false;
           this.GetComponent<Rigidbody>().useGravity = true;
            
        }

        void OnCollisionEnter(Collision col)
        {
            if (firstpickup) return;
            for (int i = 0; i < exploits.pickups.pickupsobs.Length; i++)
            {
                exploits.pickups.pickupsobs[i].transform.position = this.transform.position;
            }
            GameObject.Destroy(gameObject);
        }
        }
    }
