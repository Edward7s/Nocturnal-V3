
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.Ui.qm
{
    internal class Mic
    {
        internal static TMPro.TextMeshProUGUI chattext = null;
        internal static void start()
        {
            var mic = submenu.Create("Mic", Main.s_mainpage);
            new Submenubutton(Main.s_mainpage.Getmenu(), "Mic", mic, Settings.Download_Files.imagehandler.micmenu, true, 1, 5);


            new NButton(mic.Getmenu(), "Default Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_24K);
             new NButton(mic.Getmenu(), "20k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_20K);
             new NButton(mic.Getmenu(), "18k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_18K);
             new NButton(mic.Getmenu(), "16k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_16K);
             new NButton(mic.Getmenu(), "10k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_10K);
             new NButton(mic.Getmenu(), "8k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_8K);

             new NButton(mic.Getmenu(), "Default Mic Volume", () => USpeaker.field_Internal_Static_Single_1 = 1);
             new NButton(mic.Getmenu(), "Max Volume]", () => USpeaker.field_Internal_Static_Single_1 = float.MaxValue);

             new NButton(mic.Getmenu(), "Mic Volume [+]", () => USpeaker.field_Internal_Static_Single_1 += 1);
             new NButton(mic.Getmenu(), "Mic Volume [-]", () => USpeaker.field_Internal_Static_Single_1 -= 1);



        }

    }
}
