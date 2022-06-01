using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;
namespace Nocturnal.monobehaviours
{
    internal class Teleportobj : MonoBehaviour
    {

        private static bool firstpickup = true;
        public Teleportobj(IntPtr ptr) : base(ptr)
        {

        }
        //Inspired for Late Night
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
            if (this.gameObject.GetComponent<VRC.SDKBase.VRC_Pickup>().currentPlayer != null) return;


            VRC.Player.prop_Player_0.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 0.2f, this.transform.position.z);
            GameObject.Destroy(gameObject);
        }
    }
}
