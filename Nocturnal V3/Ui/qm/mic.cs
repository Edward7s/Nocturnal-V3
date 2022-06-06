
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.Ui.qm
{
    internal class Mic
    {
        internal static TMPro.TextMeshProUGUI chattext = null;
        internal static void start()
        {
            var mic = submenu.Create("Mic", Main._mainpage);
            Main._mainpage.Getmenu().Create("Mic", mic, Settings.Download_Files.imagehandler.micmenu, true, 1, 5);


            Buttons.Create(mic.Getmenu(), "Default Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_24K);
            Buttons.Create(mic.Getmenu(), "20k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_20K);
            Buttons.Create(mic.Getmenu(), "18k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_18K);
            Buttons.Create(mic.Getmenu(), "16k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_16K);
            Buttons.Create(mic.Getmenu(), "10k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_10K);
            Buttons.Create(mic.Getmenu(), "8k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_8K);

            Buttons.Create(mic.Getmenu(), "Default Mic Volume", () => USpeaker.field_Internal_Static_Single_1 = 1);
            Buttons.Create(mic.Getmenu(), "Max Volume]", () => USpeaker.field_Internal_Static_Single_1 = float.MaxValue);

            Buttons.Create(mic.Getmenu(), "Mic Volume [+]", () => USpeaker.field_Internal_Static_Single_1 += 1);
            Buttons.Create(mic.Getmenu(), "Mic Volume [-]", () => USpeaker.field_Internal_Static_Single_1 -= 1);



        }

    }
}
