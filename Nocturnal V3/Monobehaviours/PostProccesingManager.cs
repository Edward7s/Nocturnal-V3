using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Nocturnal.Monobehaviours
{
    internal class PostProccesingManager :MonoBehaviour
    {
        public PostProccesingManager(IntPtr ptr) : base(ptr)
        {

        }

        private PostProcessVolume Component { get; set; }
        private ColorGrading _colorGradinat { get; set; }
        private Bloom _bloom { get; set; }

        void Start()
        {
            Component = gameObject.AddComponent<PostProcessVolume>();
            Component.isGlobal = true;
            Component.priority = 200;
            Component.weight = 1;
            PostProcessProfile profile = new PostProcessProfile();
          
            Component.profile = profile;
            Component.sharedProfile = profile;
            gameObject.layer = 4;

            _colorGradinat = new ColorGrading();
            _colorGradinat.enabled.Override(false);
            _colorGradinat.active = true;
            _colorGradinat.gamma.Override(new Vector4(Settings.ConfigVars.Gamma[0] * 4, Settings.ConfigVars.Gamma[1] * 4, Settings.ConfigVars.Gamma[2] * 4, 0));
            UpdateTemperature(Settings.ConfigVars.Temperature);
            UpdateTint(Settings.ConfigVars.Tint);
            UpdateExposure(Settings.ConfigVars.Exposure);
            UpdateSaturation(Settings.ConfigVars.Saturation);

            profile.AddSettings(_colorGradinat);

            _bloom = new Bloom();
            _bloom.enabled.Override(false);
            _bloom.active = true;
            UpdateBloom(Settings.ConfigVars.Bloom);
            profile.AddSettings(_bloom);

        }
        public void UpdateExposure(float val) => _colorGradinat.postExposure.Override(-val * 9);
        public void UpdateSaturation(float val) => _colorGradinat.saturation.Override(val * 100);
        public void UpdateTint(float val) => _colorGradinat.tint.Override(val * 60);
        public void UpdateTemperature(float val) => _colorGradinat.temperature.Override(val * 100);
        public void gammaX(float val) => _colorGradinat.gamma.Override(new Vector4(val * 4, Settings.ConfigVars.Gamma[1] * 3, Settings.ConfigVars.Gamma[2] * 3, 0));
        public void gammaY(float val) => _colorGradinat.gamma.Override(new Vector4(Settings.ConfigVars.Gamma[0] * 3, val * 3, Settings.ConfigVars.Gamma[2] * 3, 0));
        public void gammaZ(float val) => _colorGradinat.gamma.Override(new Vector4(Settings.ConfigVars.Gamma[0] * 3, Settings.ConfigVars.Gamma[1] * 3, val * 3, 0));
        public void UpdateBloom(float val) => _bloom.intensity.Override(val * 20);
        public void ToggleColorGradinat(bool Val) => _colorGradinat.enabled.Override(Val);
        public void ToggleBloom(bool Val) => _bloom.enabled.Override(Val);




    }
}
