
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using UnityEngine.Rendering.PostProcessing;
namespace Nocturnal.Ui.qm
{
    internal class PostProccesing
    {
        internal static void start()
        {
            var postProccess = submenu.Create("Post Proccesing", Main.s_mainpage);
            new Submenubutton(Main.s_mainpage.Getmenu(), "Post Proccesing", postProccess, Settings.Download_Files.imagehandler.PostProccessing, true, 2, 5);

            new Apis.qm.NToggle("Custom Post Proccesing",postProccess.Getmenu(), ()=>
            {
                Settings.ConfigVars.PostProccesing = true;
                Inject_monos.s_postProccessing.gameObject.SetActive(true);
            },()=> {
                Settings.ConfigVars.PostProccesing = false;
                Inject_monos.s_postProccessing.gameObject.SetActive(false);
            }, Settings.ConfigVars.PostProccesing);
            new Apis.qm.NToggle("Color Gradinat", postProccess.Getmenu(), () =>
            {
                Settings.ConfigVars.ColorGradinat = true;
                Inject_monos.s_NocturanlPostProccesing.ToggleColorGradinat(true);
            }, () => {
            Settings.ConfigVars.ColorGradinat = false;
            Inject_monos.s_NocturanlPostProccesing.ToggleColorGradinat(false);
            }, Settings.ConfigVars.ColorGradinat);
            new Apis.qm.NToggle("Bloom", postProccess.Getmenu(), () =>
            {
                Settings.ConfigVars.BloomTogg = true;
                Inject_monos.s_NocturanlPostProccesing.ToggleBloom(true);
            }, () => {
                Settings.ConfigVars.BloomTogg = false;
                Inject_monos.s_NocturanlPostProccesing.ToggleBloom(false);
            }, Settings.ConfigVars.BloomTogg);
            new Apis.qm.NToggle("Nothing", postProccess.Getmenu(), () =>
            {
              
            }, () => {
              
            }, Settings.ConfigVars.BloomTogg);

            new Apis.Slider(postProccess.Getmenu(), val => Settings.ConfigVars.Exposure = val, Settings.ConfigVars.Exposure, () => Inject_monos.s_NocturanlPostProccesing.UpdateExposure(Settings.ConfigVars.Exposure), true, "Exposure");
            new Apis.Slider(postProccess.Getmenu(), val => Settings.ConfigVars.Saturation = val, Settings.ConfigVars.Saturation, () => Inject_monos.s_NocturanlPostProccesing.UpdateSaturation(Settings.ConfigVars.Saturation), true, "Saturation");
            new Apis.Slider(postProccess.Getmenu(), val => Settings.ConfigVars.Temperature = val, Settings.ConfigVars.Temperature, () => Inject_monos.s_NocturanlPostProccesing.UpdateTemperature(Settings.ConfigVars.Temperature), true, "Temperature");
            new Apis.Slider(postProccess.Getmenu(), val => Settings.ConfigVars.Tint = val, Settings.ConfigVars.Tint, () => Inject_monos.s_NocturanlPostProccesing.UpdateTint(Settings.ConfigVars.Tint), true, "Tint");
            new Apis.Slider(postProccess.Getmenu(), val => Settings.ConfigVars.Gamma[0] = val, Settings.ConfigVars.Gamma[0], () => Inject_monos.s_NocturanlPostProccesing.gammaX(Settings.ConfigVars.Gamma[0]), true, "Gamma R");
            new Apis.Slider(postProccess.Getmenu(), val => Settings.ConfigVars.Gamma[1] = val, Settings.ConfigVars.Gamma[1], () => Inject_monos.s_NocturanlPostProccesing.gammaY(Settings.ConfigVars.Gamma[1]), true, "Gamma G");
            new Apis.Slider(postProccess.Getmenu(), val => Settings.ConfigVars.Gamma[2] = val, Settings.ConfigVars.Gamma[2], () => Inject_monos.s_NocturanlPostProccesing.gammaZ(Settings.ConfigVars.Gamma[2]), true, "Gamma B");
            new Apis.Slider(postProccess.Getmenu(), val => Settings.ConfigVars.Bloom = val, Settings.ConfigVars.Bloom, () => Inject_monos.s_NocturanlPostProccesing.UpdateBloom(Settings.ConfigVars.Bloom), true, "Bloom");








        }

    }
}
