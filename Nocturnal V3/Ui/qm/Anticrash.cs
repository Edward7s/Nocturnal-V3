
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using Nocturnal.Settings;
using UnityEngine;
namespace Nocturnal.Ui.qm
{
    internal class Anticrash
    {

        internal static void runanti()
        {
            var AntiCrash = submenu.Create("AntiCrash", Main._mainpage);
            Main._mainpage.Getmenu().Create("AntiCrash", AntiCrash, Settings.Download_Files.imagehandler.Anitcrash, false, 0, 2);

            Toggle.Create("SelfAnti", AntiCrash.Getmenu(), () => ConfigVars.selfanti = true, () => ConfigVars.selfanti = false,ConfigVars.selfanti);

            Toggle.Create("Particles", AntiCrash.Getmenu(), () => ConfigVars.particlep = true, () => ConfigVars.particlep = false, ConfigVars.particlep);

            Toggle.Create("Shaders", AntiCrash.Getmenu(), () => ConfigVars.ShaderP = true, () => ConfigVars.ShaderP = false, ConfigVars.ShaderP);

            Toggle.Create("Audio Sources", AntiCrash.Getmenu(), () => ConfigVars.audiosourcep = true, () => ConfigVars.audiosourcep = false, ConfigVars.audiosourcep);

            Toggle.Create("Ligh Sources", AntiCrash.Getmenu(), () => ConfigVars.lightsp = true, () => ConfigVars.lightsp = false, ConfigVars.lightsp);

            Toggle.Create("Line Renderers", AntiCrash.Getmenu(), () => ConfigVars.linerenderp = true, () => ConfigVars.linerenderp = false, ConfigVars.linerenderp);

            Toggle.Create("Meshes", AntiCrash.Getmenu(), () => ConfigVars.meshp = true, () => ConfigVars.meshp = false, ConfigVars.meshp);

            Toggle.Create("Vertecies", AntiCrash.Getmenu(), () => ConfigVars.verticiesp = true, () => ConfigVars.verticiesp = false, ConfigVars.verticiesp);

            Toggle.Create("Log Shaders in Console", AntiCrash.Getmenu(), () => ConfigVars.logshaderstoconsole = true, () => ConfigVars.logshaderstoconsole = false, ConfigVars.logshaderstoconsole);

            GameObject maxaud = null;
            maxaud = Buttons.Create(AntiCrash.Getmenu(), $"[{Settings.ConfigVars.maxaudiosources}] Max Audio Sources", () =>
            {
                try
                {
                    Apis.Inputpopout.Run("Max Audio Sources", value => Settings.ConfigVars.maxaudiosources = int.Parse(value), () => { maxaud.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxaudiosources}] Max Audio Sources"; });
                }
                catch { }
              

            });
            GameObject maxm = null;

            maxm = Buttons.Create(AntiCrash.Getmenu(), $"[{Settings.ConfigVars.maxmaterials}] Max Materials", () =>
            {
                try
                {
                    Apis.Inputpopout.Run("Max Materials", value => Settings.ConfigVars.maxmaterials = int.Parse(value), () => {
                        maxm.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxmaterials}] Max Audio Sources";
                    });

                }
                catch { }
            });
            GameObject maxme = null;

            maxme = Buttons.Create(AntiCrash.Getmenu(), $"[{Settings.ConfigVars.maxmeshes}] Max Meshes", () =>
            {
                try
                {
                    Apis.Inputpopout.Run("Max Meshes", value => Settings.ConfigVars.maxmeshes = int.Parse(value), () => {
                        maxme.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxmeshes}] Max Audio Sources";
                    });

                }
                catch { }
            });
            GameObject maxp = null;

            maxp = Buttons.Create(AntiCrash.Getmenu(), $"[{Settings.ConfigVars.maxparticles}] Max Particles", () =>
            {
                try
                {
                    Apis.Inputpopout.Run("Max Particles", value => Settings.ConfigVars.maxparticles = int.Parse(value), () => {
                        maxp.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxparticles}] Max Audio Sources";
                    });

                }
                catch { }
            });

            GameObject maxv = null;

            maxv = Buttons.Create(AntiCrash.Getmenu(), $"[{Settings.ConfigVars.maxverticies}] Max Verticies", () =>
            {
                try
                {
                    Apis.Inputpopout.Run("Max Verticies", value => Settings.ConfigVars.maxverticies = int.Parse(value), () => {
                        maxv.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxverticies}] Max Audio Sources";
                    });

                }
                catch { }
            });
            GameObject maxpsy = null;

            maxpsy=Buttons.Create(AntiCrash.Getmenu(), $"[{Settings.ConfigVars.particlesystem}] Max Particle Systems", () =>
            {
                try
                {
                    Apis.Inputpopout.Run("Max Particle Systems", value => Settings.ConfigVars.particlesystem = int.Parse(value), () => {
                        maxpsy.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.particlesystem}] Max Audio Sources";
                    });

                }
                catch { }
            });
        }
    }
}
