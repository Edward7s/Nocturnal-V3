
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using UnityEngine.Rendering.PostProcessing;
namespace Nocturnal.Ui.qm
{
    internal class PostProccesing
    {
        internal static UnityEngine.GameObject s_postProccess { get; set; }
        internal static void start()
        {
            s_postProccess = submenu.Create("Post Proccesing", Main.s_mainpage);
            new Submenubutton(Main.s_mainpage.Getmenu(), "Post Proccesing", s_postProccess, Settings.Download_Files.imagehandler.PostProccessing, true, 2, 5);

            PostProccesingConfigs.start();

            new Apis.qm.NToggle("Custom Post Proccesing", s_postProccess.Getmenu(), ()=>
            {
                Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.PostProccesing = true;
                Inject_monos.s_postProccessing.gameObject.SetActive(true);
            },()=> {
                Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.PostProccesing = false;
                Inject_monos.s_postProccessing.gameObject.SetActive(false);
            });
            new Apis.qm.NToggle("Color Gradinat", s_postProccess.Getmenu(), () =>
            {
                Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.ColorGradinat = true;
                Inject_monos.s_NocturanlPostProccesing.ToggleColorGradinat(true);
            }, () => {
                Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.ColorGradinat = false;
                Inject_monos.s_NocturanlPostProccesing.ToggleColorGradinat(false);
            });
            new Apis.qm.NToggle("Bloom", s_postProccess.Getmenu(), () =>
            {
                Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.BloomTogg = true;
                Inject_monos.s_NocturanlPostProccesing.ToggleBloom(true);
            }, () => {
                Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.BloomTogg = false;
                Inject_monos.s_NocturanlPostProccesing.ToggleBloom(false);
            });
            new NButton(s_postProccess.Getmenu(), "Save Config", () => Inject_monos.s_NocturanlPostProccesing.SaveCurrentConfig(Settings.ConfigVars.CurrentConfig));
            new NButton(s_postProccess.Getmenu(), "New Config", () => Inject_monos.s_NocturanlPostProccesing.SaveNewConfig());


            new Apis.Slider(s_postProccess.Getmenu(), val => Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Exposure = val, Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Exposure, () => Inject_monos.s_NocturanlPostProccesing.UpdateExposure(Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Exposure), true, "Exposure");
            new Apis.Slider(s_postProccess.Getmenu(), val => Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Saturation = val, Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Saturation, () => Inject_monos.s_NocturanlPostProccesing.UpdateSaturation(Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Saturation), true, "Saturation");
            new Apis.Slider(s_postProccess.Getmenu(), val => Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Temperature = val, Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Temperature, () => Inject_monos.s_NocturanlPostProccesing.UpdateTemperature(Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Temperature), true, "Temperature");
            new Apis.Slider(s_postProccess.Getmenu(), val => Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Tint = val, Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Tint, () => Inject_monos.s_NocturanlPostProccesing.UpdateTint(Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Tint), true, "Tint");
            new Apis.Slider(s_postProccess.Getmenu(), val => Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Gamma[0] = val, Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Gamma[0], () => Inject_monos.s_NocturanlPostProccesing.gammaX(Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Gamma[0]), true, "Gamma R");
            new Apis.Slider(s_postProccess.Getmenu(), val => Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Gamma[1] = val, Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Gamma[1], () => Inject_monos.s_NocturanlPostProccesing.gammaY(Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Gamma[1]), true, "Gamma G");
            new Apis.Slider(s_postProccess.Getmenu(), val => Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Gamma[2] = val, Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Gamma[2], () => Inject_monos.s_NocturanlPostProccesing.gammaZ(Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Gamma[2]), true, "Gamma B");
            new Apis.Slider(s_postProccess.Getmenu(), val => Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Bloom = val, Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Bloom, () => Inject_monos.s_NocturanlPostProccesing.UpdateBloom(Inject_monos.s_NocturanlPostProccesing.PostProccesingJson.Bloom), true, "Bloom");





            Inject_monos.s_NocturanlPostProccesing.VisualUpdate();


        }

    }
}
