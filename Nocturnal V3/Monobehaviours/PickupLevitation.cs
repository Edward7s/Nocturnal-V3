using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC.SDKBase;
namespace Nocturnal.Monobehaviours
{
    internal class PickupLevitation : MonoBehaviour
    {
        private Rigidbody _rigidBody { get; set; }
        public PickupLevitation(IntPtr ptr) : base(ptr) { }
        void Start()  {
            _rigidBody = this.gameObject.GetComponent<Rigidbody>();
            InvokeRepeating(nameof(LevitationHandler), -1, 0.1f);
        }
        void LevitationHandler() {
            Networking.SetOwner(VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0, gameObject);
            _rigidBody.useGravity = false;
            _rigidBody.AddForce(new Vector3(0, 0.1f, 0), ForceMode.Impulse);
        } 
        void OnDestroy() => CancelInvoke(nameof(LevitationHandler));
     
    }
}
