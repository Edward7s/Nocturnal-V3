using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.IO;
using Newtonsoft.Json;
using Nocturnal.Settings.wrappers;
using UnityEngine.UI;
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
        private GameObject _completMenu { get; set; }

        public Settings.jsonmanager.PostProccesingJs PostProccesingJson { get; set; }

        void Start()
        {
            Component = gameObject.AddComponent<PostProcessVolume>();
            Component.isGlobal = true;
            Component.priority = float.MaxValue;
            Component.weight = 1;
            PostProcessProfile profile = new PostProcessProfile();  
            Component.profile = profile;
            Component.sharedProfile = profile;
            gameObject.layer = 4;
            _colorGradinat = new ColorGrading();
            _colorGradinat.active = true;  
            _bloom = new Bloom();
            _bloom.active = true;
            profile.AddSettings(_bloom);
            profile.AddSettings(_colorGradinat);

        }
        public void UpdateExposure(float val) => _colorGradinat.postExposure.Override(-val * 9);
        public void UpdateSaturation(float val) => _colorGradinat.saturation.Override(val * 100);
        public void UpdateTint(float val) => _colorGradinat.tint.Override(val * 60);
        public void UpdateTemperature(float val) => _colorGradinat.temperature.Override(val * 100);
        public void gammaX(float val) => _colorGradinat.gamma.Override(new Vector4(val * 3, PostProccesingJson.Gamma[1] * 3, PostProccesingJson.Gamma[2] * 3, 0));
        public void gammaY(float val) => _colorGradinat.gamma.Override(new Vector4(PostProccesingJson.Gamma[0] * 3, val * 3, PostProccesingJson.Gamma[2] * 3, 0));
        public void gammaZ(float val) => _colorGradinat.gamma.Override(new Vector4(PostProccesingJson.Gamma[0] * 3, PostProccesingJson.Gamma[1] * 3, val * 3, 0));
        public void UpdateBloom(float val) => _bloom.intensity.Override(val * 20);
        public void ToggleColorGradinat(bool Val) => _colorGradinat.enabled.Override(Val);
        public void ToggleBloom(bool Val) => _bloom.enabled.Override(Val);

        public void LoadConfig(string config)
        {
            if (!File.Exists(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\PostProccesing\\" + config + ".json"))
            {
                PostProccesingJson = JsonConvert.DeserializeObject<Settings.jsonmanager.PostProccesingJs>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\PostProccesing\\" + "DefaultProccesing" + ".json"));
                Settings.ConfigVars.CurrentConfig = "DefaultProccesing";
            }
            else
            PostProccesingJson = JsonConvert.DeserializeObject<Settings.jsonmanager.PostProccesingJs>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\PostProccesing\\" + config + ".json"));
            UpdateTemperature(PostProccesingJson.Temperature);
            UpdateTint(PostProccesingJson.Tint);
            UpdateExposure(PostProccesingJson.Exposure);
            UpdateSaturation(PostProccesingJson.Saturation);
            UpdateBloom(PostProccesingJson.Bloom);
            _colorGradinat.enabled.Override(PostProccesingJson.ColorGradinat);
            _bloom.enabled.Override(PostProccesingJson.BloomTogg);
            gameObject.SetActive(PostProccesingJson.PostProccesing);
            gammaX(PostProccesingJson.Gamma[0]);
            gammaY(PostProccesingJson.Gamma[1]);
            gammaZ(PostProccesingJson.Gamma[2]);

        }
        public void VisualUpdate()
        {
            _completMenu = Ui.qm.PostProccesing.s_postProccess.Getmenu();
            _completMenu.transform.Find("Exposure/VolumeGameAvatars(Clone)").GetComponent<Slider>().value = PostProccesingJson.Exposure;
            _completMenu.transform.Find("Saturation/VolumeGameAvatars(Clone)").GetComponent<Slider>().value = PostProccesingJson.Saturation;
            _completMenu.transform.Find("Temperature/VolumeGameAvatars(Clone)").GetComponent<Slider>().value = PostProccesingJson.Temperature;
            _completMenu.transform.Find("Tint/VolumeGameAvatars(Clone)").GetComponent<Slider>().value = PostProccesingJson.Tint;
            _completMenu.transform.Find("Gamma R/VolumeGameAvatars(Clone)").GetComponent<Slider>().value = PostProccesingJson.Gamma[0];
            _completMenu.transform.Find("Gamma G/VolumeGameAvatars(Clone)").GetComponent<Slider>().value = PostProccesingJson.Gamma[1];
            _completMenu.transform.Find("Gamma B/VolumeGameAvatars(Clone)").GetComponent<Slider>().value = PostProccesingJson.Gamma[2];
            _completMenu.transform.Find("Bloom/VolumeGameAvatars(Clone)").GetComponent<Slider>().value = PostProccesingJson.Bloom;
            UpdateToggle(_completMenu.transform.Find("Toggle_Custom Post Proccesing").gameObject, PostProccesingJson.PostProccesing);
            UpdateToggle(_completMenu.transform.Find("Toggle_Color Gradinat").gameObject, PostProccesingJson.ColorGradinat);
            UpdateToggle(_completMenu.transform.Find("Toggle_Bloom").gameObject, PostProccesingJson.BloomTogg);
            gammaX(PostProccesingJson.Gamma[0]);
            gammaY(PostProccesingJson.Gamma[1]);
            gammaZ(PostProccesingJson.Gamma[2]);
        }

        private void UpdateToggle(GameObject gamobj, bool toggle)
        {
            gamobj.GetComponent<Toggle>().isOn = toggle;
            if (toggle)
            {
                gamobj.transform.Find("Icon_On").GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
                gamobj.transform.Find("Icon_Off").GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
                return;
            }
            gamobj.transform.Find("Icon_On").GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 0.1f);
            gamobj.transform.Find("Icon_Off").GetComponent<Image>().color = new Color(0.415f, 0.890f, 0.976f, 1f);
        }

        public void SaveCurrentConfig(string config) => File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\PostProccesing\\" + config + ".json", JsonConvert.SerializeObject(PostProccesingJson));

        public void SaveNewConfig()
        {
            string ah = "";
            Settings.XRefedMethods.PopOutInput("Enter A Name For The Post Proccesing Config", x => ah = x, () => {
                Settings.ConfigVars.CurrentConfig = ah;
            SaveCurrentConfig(ah);

                var Objects = Ui.qm.PostProccesingConfigs.s_postProccesingConfigMenu.Getmenu().GetComponentsInChildren<LayoutElement>();
                for (int i = 0; i < Objects.Count; i++)
                {
                    try
                    {
                        GameObject.DestroyImmediate(Objects[i].gameObject);
                    }
                    catch { }
                }
                var files = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\PostProccesing").GetFiles();
                foreach (var file in files)
                    new Apis.qm.NButton(Ui.qm.PostProccesingConfigs.s_postProccesingConfigMenu.Getmenu(), file.Name.Replace(".json", ""), () =>
                    {
                        Settings.ConfigVars.CurrentConfig = file.Name.Replace(".json", "");
                        LoadConfig(file.Name.Replace(".json", ""));
                        VisualUpdate();
                    });
            });
        }
    }
}
