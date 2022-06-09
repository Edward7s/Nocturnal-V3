using System;
using UnityEngine;
using VRC.SDKBase;
namespace Nocturnal.Monobehaviours
{
    internal class Fly : MonoBehaviour
    {
        public Fly(IntPtr ptr) : base(ptr)
        {

        }        


        void LateUpdate() => Exploits.Fly.fly();



    }
}
