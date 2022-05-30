using Nocturnal.Apis.QM;
using Nocturnal.Settings;
using Nocturnal.Settings.Wrappers;
using UnityEngine;
namespace Nocturnal.Ui.QM
{
	internal class AntiCrashUI
	{

		internal static void CreateUI()
		{
			var AntiCrash = SubMenu.Create("AntiCrash", Main.mainPage);
			Main.mainPage.GetMenu().Create("AntiCrash", AntiCrash, Settings.DownloadFiles.anticrash, false, 0, 2);

			Apis.QM.Toggle.Create("SelfAnti", AntiCrash.GetMenu(), () => ConfigVars.selfanti = true, () => ConfigVars.selfanti = false, ConfigVars.selfanti);

			Apis.QM.Toggle.Create("Particles", AntiCrash.GetMenu(), () => ConfigVars.particlep = true, () => ConfigVars.particlep = false, ConfigVars.particlep);

			Apis.QM.Toggle.Create("Shaders", AntiCrash.GetMenu(), () => ConfigVars.ShaderP = true, () => ConfigVars.ShaderP = false, ConfigVars.ShaderP);

			Apis.QM.Toggle.Create("Audio Sources", AntiCrash.GetMenu(), () => ConfigVars.audiosourcep = true, () => ConfigVars.audiosourcep = false, ConfigVars.audiosourcep);

			Apis.QM.Toggle.Create("Ligh Sources", AntiCrash.GetMenu(), () => ConfigVars.lightsp = true, () => ConfigVars.lightsp = false, ConfigVars.lightsp);

			Apis.QM.Toggle.Create("Line Renderers", AntiCrash.GetMenu(), () => ConfigVars.linerenderp = true, () => ConfigVars.linerenderp = false, ConfigVars.linerenderp);

			Apis.QM.Toggle.Create("Meshes", AntiCrash.GetMenu(), () => ConfigVars.meshp = true, () => ConfigVars.meshp = false, ConfigVars.meshp);

			Apis.QM.Toggle.Create("Vertecies", AntiCrash.GetMenu(), () => ConfigVars.verticiesp = true, () => ConfigVars.verticiesp = false, ConfigVars.verticiesp);

			Apis.QM.Toggle.Create("Log Shaders in Console", AntiCrash.GetMenu(), () => ConfigVars.logshaderstoconsole = true, () => ConfigVars.logshaderstoconsole = false, ConfigVars.logshaderstoconsole);

			GameObject maxaud = null;
			maxaud = Button.Create(AntiCrash.GetMenu(), $"[{Settings.ConfigVars.maxaudiosources}] Max Audio Sources", () =>
			{
				try
				{
					Apis.InputPopup.Run("Max Audio Sources", value => Settings.ConfigVars.maxaudiosources = int.Parse(value), () => { maxaud.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxaudiosources}] Max Audio Sources"; });
				}
				catch { }


			});
			GameObject maxm = null;

			maxm = Button.Create(AntiCrash.GetMenu(), $"[{Settings.ConfigVars.maxmaterials}] Max Materials", () =>
			{
				try
				{
					Apis.InputPopup.Run("Max Materials", value => Settings.ConfigVars.maxmaterials = int.Parse(value), () =>
					{
						maxm.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxmaterials}] Max Audio Sources";
					});

				}
				catch { }
			});
			GameObject maxme = null;

			maxme = Button.Create(AntiCrash.GetMenu(), $"[{Settings.ConfigVars.maxmeshes}] Max Meshes", () =>
			{
				try
				{
					Apis.InputPopup.Run("Max Meshes", value => Settings.ConfigVars.maxmeshes = int.Parse(value), () =>
					{
						maxme.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxmeshes}] Max Audio Sources";
					});

				}
				catch { }
			});
			GameObject maxp = null;

			maxp = Button.Create(AntiCrash.GetMenu(), $"[{Settings.ConfigVars.maxparticles}] Max Particles", () =>
			{
				try
				{
					Apis.InputPopup.Run("Max Particles", value => Settings.ConfigVars.maxparticles = int.Parse(value), () =>
					{
						maxp.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxparticles}] Max Audio Sources";
					});

				}
				catch { }
			});

			GameObject maxv = null;

			maxv = Button.Create(AntiCrash.GetMenu(), $"[{Settings.ConfigVars.maxverticies}] Max Verticies", () =>
			{
				try
				{
					Apis.InputPopup.Run("Max Verticies", value => Settings.ConfigVars.maxverticies = int.Parse(value), () =>
					{
						maxv.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.maxverticies}] Max Audio Sources";
					});

				}
				catch { }
			});
			GameObject maxpsy = null;

			maxpsy = Button.Create(AntiCrash.GetMenu(), $"[{Settings.ConfigVars.particlesystem}] Max Particle Systems", () =>
			{
				try
				{
					Apis.InputPopup.Run("Max Particle Systems", value => Settings.ConfigVars.particlesystem = int.Parse(value), () =>
					{
						maxpsy.transform.Find("Text_H4").GetComponent<TMPro.TextMeshProUGUI>().text = $"[{Settings.ConfigVars.particlesystem}] Max Audio Sources";
					});

				}
				catch { }
			});
		}
	}
}
