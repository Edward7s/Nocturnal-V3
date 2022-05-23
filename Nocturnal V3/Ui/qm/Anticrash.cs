using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Ui.qm;
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
            var AntiCrash = submenu.Submenu("AntiCrash", Main.mainpage);
            Main.mainpage.getmenu().submenu("AntiCrash", AntiCrash, Settings.Download_Files.Anitcrash, false, 0, 2);

            Apis.qm.Toggle.toggle("SelfAnti", AntiCrash.getmenu(), () => ConfigVars.selfanti = true, () => ConfigVars.selfanti = false,ConfigVars.selfanti);

            Apis.qm.Toggle.toggle("Particles", AntiCrash.getmenu(), () => ConfigVars.particlep = true, () => ConfigVars.particlep = false, ConfigVars.particlep);

            Apis.qm.Toggle.toggle("Shaders", AntiCrash.getmenu(), () => ConfigVars.ShaderP = true, () => ConfigVars.ShaderP = false, ConfigVars.ShaderP);

            Apis.qm.Toggle.toggle("Audio Sources", AntiCrash.getmenu(), () => ConfigVars.audiosourcep = true, () => ConfigVars.audiosourcep = false, ConfigVars.audiosourcep);

            Apis.qm.Toggle.toggle("Ligh Sources", AntiCrash.getmenu(), () => ConfigVars.lightsp = true, () => ConfigVars.lightsp = false, ConfigVars.lightsp);

            Apis.qm.Toggle.toggle("Line Renderers", AntiCrash.getmenu(), () => ConfigVars.linerenderp = true, () => ConfigVars.linerenderp = false, ConfigVars.linerenderp);

            Apis.qm.Toggle.toggle("Meshes", AntiCrash.getmenu(), () => ConfigVars.meshp = true, () => ConfigVars.meshp = false, ConfigVars.meshp);

            Apis.qm.Toggle.toggle("Vertecies", AntiCrash.getmenu(), () => ConfigVars.verticiesp = true, () => ConfigVars.verticiesp = false, ConfigVars.verticiesp);

            Apis.qm.Toggle.toggle("Log Shaders in Console", AntiCrash.getmenu(), () => ConfigVars.logshaderstoconsole = true, () => ConfigVars.logshaderstoconsole = false, ConfigVars.logshaderstoconsole);

            GameObject maxaud = null;
            maxaud = Buttons.Button(AntiCrash.getmenu(), $"[{Settings.ConfigVars.maxaudiosources}] Max Audio Sources", () =>
            {
                try
                {
                    Apis.inputpopout.run("Max Audio Sources", value => Settings.ConfigVars.maxaudiosources = int.Parse(value), () => { maxaud.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxaudiosources}] Max Audio Sources"; });
                }
                catch { }
              

            });
            GameObject maxm = null;

            maxm = Buttons.Button(AntiCrash.getmenu(), $"[{Settings.ConfigVars.maxmaterials}] Max Materials", () =>
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

            maxme = Buttons.Button(AntiCrash.getmenu(), $"[{Settings.ConfigVars.maxmeshes}] Max Meshes", () =>
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

            maxp = Buttons.Button(AntiCrash.getmenu(), $"[{Settings.ConfigVars.maxparticles}] Max Particles", () =>
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

            maxv = Buttons.Button(AntiCrash.getmenu(), $"[{Settings.ConfigVars.maxverticies}] Max Verticies", () =>
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

            maxpsy=Buttons.Button(AntiCrash.getmenu(), $"[{Settings.ConfigVars.particlesystem}] Max Particle Systems", () =>
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
