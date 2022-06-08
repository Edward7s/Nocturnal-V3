
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using System.IO;
using Newtonsoft.Json;
namespace Nocturnal.Ui.qm
{
    internal class Discord
    {
        internal static TMPro.TextMeshProUGUI chattext = null;
        internal static void start()
        {
            var disc = submenu.Create("Discord", Main._mainpage);
            new Submenubutton(Main._mainpage.Getmenu(), "Discord", disc, Settings.Download_Files.imagehandler.Discord, true, 2, 4);
            NocturnalC.Log("Starting Discord RPC", "DiscordRPC");
            new NToggle("Discord Presence", disc.Getmenu(), () =>
            {
                var str = JsonConvert.DeserializeObject<Settings.jsonmanager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
                str.ison = true;
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", JsonConvert.SerializeObject(str));
                Settings.Download_Files.activitymanager.Invoke(Settings.Download_Files.activitymanager, null);
                Settings.ConfigVars.discordrichpresence = true;
            }, () =>
            {
                try
                {
                    var str = JsonConvert.DeserializeObject<Settings.jsonmanager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
                    str.ison = false;
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", JsonConvert.SerializeObject(str));
                    Settings.Download_Files.activitymanager.Invoke(Settings.Download_Files.activitymanager, null);
                    Settings.ConfigVars.discordrichpresence = false;
                }
                catch { }
            }, Settings.ConfigVars.discordrichpresence);
            Settings.Download_Files.activitymanager.Invoke(Settings.Download_Files.activitymanager, null);
           

             new NButton(disc.Getmenu(), "Details", () =>
            {
                   var str = JsonConvert.DeserializeObject<Settings.jsonmanager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
                var tobstring = "";
                Apis.Inputpopout.Run("Details", value => tobstring = value, () => {
                str.Details = tobstring;
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc",JsonConvert.SerializeObject(str));
                    Settings.Download_Files.activitymanager.Invoke(Settings.Download_Files.activitymanager, null);

                });
            });

             new NButton(disc.Getmenu(), "State", () =>
            {
                var str = JsonConvert.DeserializeObject<Settings.jsonmanager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
                var tobstring = "";
                Apis.Inputpopout.Run("State", value => tobstring = value, () => {
                    str.State = tobstring;
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", JsonConvert.SerializeObject(str));
                    Settings.Download_Files.activitymanager.Invoke(Settings.Download_Files.activitymanager, null);

                });
            });
             new NButton(disc.Getmenu(), "Image", () =>
            {
                var str = JsonConvert.DeserializeObject<Settings.jsonmanager.discordrpc>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc"));
                var tobstring = "";
                Apis.Inputpopout.Run("Image", value => tobstring = value, () => {
                    str.LargeImage = tobstring;
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\Discord.rpc", JsonConvert.SerializeObject(str));
                    Settings.Download_Files.activitymanager.Invoke(Settings.Download_Files.activitymanager, null);

                });
            });

            
        }

    }
}
