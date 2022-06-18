using System;
using UnityEngine;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.Monobehaviours
{
    internal class Fly : MonoBehaviour
    {
        public Fly(IntPtr ptr) : base(ptr) { }  
        public void OnEnable() => extensions.togglecontroller(false);
        public void OnDisable() => extensions.togglecontroller(true);
        void LateUpdate() => Exploits.Fly.fly();
    }
}
