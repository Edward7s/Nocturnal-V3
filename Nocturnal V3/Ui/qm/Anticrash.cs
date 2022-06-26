using Nocturnal.Settings;
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
            new Submenubutton(Main._mainpage.Getmenu(), "AntiCrash", AntiCrash, Settings.Download_Files.imagehandler.Anitcrash, false, 0, 2);

            new NToggle("SelfAnti", AntiCrash.Getmenu(), () => ConfigVars.selfanti = true, () => ConfigVars.selfanti = false, ConfigVars.selfanti);
            new NToggle("Particles", AntiCrash.Getmenu(), () => ConfigVars.particlep = true, () => ConfigVars.particlep = false, ConfigVars.particlep);
            new NToggle("Shaders", AntiCrash.Getmenu(), () => ConfigVars.ShaderP = true, () => ConfigVars.ShaderP = false, ConfigVars.ShaderP);
            new NToggle("Audio Sources", AntiCrash.Getmenu(), () => ConfigVars.audiosourcep = true, () => ConfigVars.audiosourcep = false, ConfigVars.audiosourcep);
            new NToggle("Ligh Sources", AntiCrash.Getmenu(), () => ConfigVars.lightsp = true, () => ConfigVars.lightsp = false, ConfigVars.lightsp);
            new NToggle("Line Renderers", AntiCrash.Getmenu(), () => ConfigVars.linerenderp = true, () => ConfigVars.linerenderp = false, ConfigVars.linerenderp);
            new NToggle("Meshes", AntiCrash.Getmenu(), () => ConfigVars.meshp = true, () => ConfigVars.meshp = false, ConfigVars.meshp);
            new NToggle("Vertecies", AntiCrash.Getmenu(), () => ConfigVars.verticiesp = true, () => ConfigVars.verticiesp = false, ConfigVars.verticiesp);
            new NToggle("Log Shaders in Console", AntiCrash.Getmenu(), () => ConfigVars.logshaderstoconsole = true, () => ConfigVars.logshaderstoconsole = false, ConfigVars.logshaderstoconsole);
            GameObject maxaud = null;
            new NButton(out maxaud,AntiCrash.Getmenu(), $"[{ConfigVars.maxaudiosources}] Max Audio Sources", () =>
            {
                try
                {
                     XRefedMethods.PopOutNumbersKeyboard("Max Audio Sources", value => ConfigVars.maxaudiosources = value, () => { maxaud.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxaudiosources}] Max Audio Sources"; });
                }
                catch { }
            });

            GameObject maxm = null;
            new NButton(out maxm, AntiCrash.Getmenu(), $"[{ConfigVars.maxmaterials}] Max Materials", () =>
            {
                try
                {
                    XRefedMethods.PopOutNumbersKeyboard("Max Materials", value => ConfigVars.maxmaterials = value, () => {
                        maxm.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{ConfigVars.maxmaterials}] Max Audio Sources";
                    });

                }
                catch { }
            });

            GameObject maxme = null;
            new NButton(out maxm, AntiCrash.Getmenu(), $"[{ConfigVars.maxmeshes}] Max Meshes", () =>
            {
                try
                {
                    XRefedMethods.PopOutNumbersKeyboard("Max Meshes", value => ConfigVars.maxmeshes = value, () => {
                        maxme.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{ConfigVars.maxmeshes}] Max Audio Sources";
                    });

                }
                catch { }
            });


            GameObject maxp = null;
            new NButton(out maxp, AntiCrash.Getmenu(), $"[{Settings.ConfigVars.maxparticles}] Max Particles", () =>
            {
                try
                {
                    XRefedMethods.PopOutNumbersKeyboard("Max Particles", value => ConfigVars.maxparticles = value, () => {
                        maxp.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxparticles}] Max Audio Sources";
                    });

                }
                catch { }
            });
            GameObject maxv = null;
            new NButton(out maxp, AntiCrash.Getmenu(), $"[{ConfigVars.maxverticies}] Max Verticies", () =>
            {
                try
                {
                    XRefedMethods.PopOutNumbersKeyboard("Max Verticies", value => ConfigVars.maxverticies = value, () => {
                        maxv.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{ConfigVars.maxverticies}] Max Audio Sources";
                    });

                }
                catch { }
            });


            GameObject maxpsy = null;
            new NButton(out maxpsy, AntiCrash.Getmenu(), $"[{Settings.ConfigVars.particlesystem}] Max Particle Systems", () =>
            {
                try
                {
                    XRefedMethods.PopOutNumbersKeyboard("Max Particle Systems", value => Settings.ConfigVars.particlesystem = value, () => {
                        maxpsy.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{ConfigVars.particlesystem}] Max Audio Sources";
                    });

                }
                catch { }
            });
        }
    }
}
