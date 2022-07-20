using Nocturnal.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Nocturnal.Monobehaviours
{
    internal class Trail : MonoBehaviour
    {
        public Trail(IntPtr ptr) : base(ptr)
        {

        }
        private GameObject _trailGameobject { get; set; }
        private Material _trailMaterial { get; set; }
        private TrailRenderer _trailComponent { get; set; }

        void Start()
        {
            _trailGameobject = new GameObject("Trail Manager");
            _trailGameobject.transform.parent = this.transform;
            _trailGameobject.transform.localPosition = new Vector3(0, 0.025f, 0);
            _trailGameobject.transform.localScale = Vector3.one;
            _trailGameobject.transform.localEulerAngles = Vector3.zero;
            _trailComponent = _trailGameobject.AddComponent<TrailRenderer>();
            _trailMaterial = _trailComponent.material = new Material(Shader.Find("Legacy Shaders/Particles/Alpha Blended"));
            _trailMaterial.SetColor("_TintColor", new Color(ConfigVars.HuDColor[0], ConfigVars.HuDColor[1], ConfigVars.HuDColor[2], 0.1f));
            _trailComponent.startWidth = 0.01f;
            _trailComponent.endWidth = 0.008f;
        }

        void OnDestroy()
        {
            try
            {
                GameObject.Destroy(_trailGameobject);
            }
            catch { }
        }
    }
}
