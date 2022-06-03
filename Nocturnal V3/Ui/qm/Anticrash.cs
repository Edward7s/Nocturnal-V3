
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
            var AntiCrash = submenu.Create("AntiCrash", Main.mainpage);
            Main.mainpage.getmenu().Create("AntiCrash", AntiCrash, Settings.Download_Files.Anitcrash, false, 0, 2);

            Toggle.Create("SelfAnti", AntiCrash.getmenu(), () => ConfigVars.selfanti = true, () => ConfigVars.selfanti = false,ConfigVars.selfanti);

            Toggle.Create("Particles", AntiCrash.getmenu(), () => ConfigVars.particlep = true, () => ConfigVars.particlep = false, ConfigVars.particlep);

            Toggle.Create("Shaders", AntiCrash.getmenu(), () => ConfigVars.ShaderP = true, () => ConfigVars.ShaderP = false, ConfigVars.ShaderP);

            Toggle.Create("Audio Sources", AntiCrash.getmenu(), () => ConfigVars.audiosourcep = true, () => ConfigVars.audiosourcep = false, ConfigVars.audiosourcep);

            Toggle.Create("Ligh Sources", AntiCrash.getmenu(), () => ConfigVars.lightsp = true, () => ConfigVars.lightsp = false, ConfigVars.lightsp);

            Toggle.Create("Line Renderers", AntiCrash.getmenu(), () => ConfigVars.linerenderp = true, () => ConfigVars.linerenderp = false, ConfigVars.linerenderp);

            Toggle.Create("Meshes", AntiCrash.getmenu(), () => ConfigVars.meshp = true, () => ConfigVars.meshp = false, ConfigVars.meshp);

            Toggle.Create("Vertecies", AntiCrash.getmenu(), () => ConfigVars.verticiesp = true, () => ConfigVars.verticiesp = false, ConfigVars.verticiesp);

            Toggle.Create("Log Shaders in Console", AntiCrash.getmenu(), () => ConfigVars.logshaderstoconsole = true, () => ConfigVars.logshaderstoconsole = false, ConfigVars.logshaderstoconsole);

            GameObject maxaud = null;
            maxaud = Buttons.Create(AntiCrash.getmenu(), $"[{Settings.ConfigVars.maxaudiosources}] Max Audio Sources", () =>
            {
                try
                {
                    Apis.inputpopout.run("Max Audio Sources", value => Settings.ConfigVars.maxaudiosources = int.Parse(value), () => { maxaud.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxaudiosources}] Max Audio Sources"; });
                }
                catch { }
              

            });
            GameObject maxm = null;

            maxm = Buttons.Create(AntiCrash.getmenu(), $"[{Settings.ConfigVars.maxmaterials}] Max Materials", () =>
            {
                try
                {
                    Apis.inputpopout.run("Max Materials", value => Settings.ConfigVars.maxmaterials = int.Parse(value), () => {
                        maxm.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxmaterials}] Max Audio Sources";
                    });

                }
                catch { }
            });
            GameObject maxme = null;

            maxme = Buttons.Create(AntiCrash.getmenu(), $"[{Settings.ConfigVars.maxmeshes}] Max Meshes", () =>
            {
                try
                {
                    Apis.inputpopout.run("Max Meshes", value => Settings.ConfigVars.maxmeshes = int.Parse(value), () => {
                        maxme.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxmeshes}] Max Audio Sources";
                    });

                }
                catch { }
            });
            GameObject maxp = null;

            maxp = Buttons.Create(AntiCrash.getmenu(), $"[{Settings.ConfigVars.maxparticles}] Max Particles", () =>
            {
                try
                {
                    Apis.inputpopout.run("Max Particles", value => Settings.ConfigVars.maxparticles = int.Parse(value), () => {
                        maxp.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxparticles}] Max Audio Sources";
                    });

                }
                catch { }
            });

            GameObject maxv = null;

            maxv = Buttons.Create(AntiCrash.getmenu(), $"[{Settings.ConfigVars.maxverticies}] Max Verticies", () =>
            {
                try
                {
                    Apis.inputpopout.run("Max Verticies", value => Settings.ConfigVars.maxverticies = int.Parse(value), () => {
                        maxv.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxverticies}] Max Audio Sources";
                    });

                }
                catch { }
            });
            GameObject maxpsy = null;

            maxpsy=Buttons.Create(AntiCrash.getmenu(), $"[{Settings.ConfigVars.particlesystem}] Max Particle Systems", () =>
            {
                try
                {
                    Apis.inputpopout.run("Max Particle Systems", value => Settings.ConfigVars.particlesystem = int.Parse(value), () => {
                        maxpsy.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.particlesystem}] Max Audio Sources";
                    });

                }
                catch { }
            });
        }
    }
}
