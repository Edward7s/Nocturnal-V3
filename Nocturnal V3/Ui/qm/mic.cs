using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal.Apis;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
namespace Nocturnal.Ui.qm
{
    internal class mic
    {
        internal static TMPro.TextMeshProUGUI chattext = null;
        internal static void start()
        {
            var mic = submenu.Submenu("Mic", Main.mainpage);
            Main.mainpage.getmenu().submenu("Mic", mic, Settings.Download_Files.micmenu, true, 1, 5);


            Buttons.Button(mic.getmenu(), "Default Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_24K);
            Buttons.Button(mic.getmenu(), "20k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_20K);
            Buttons.Button(mic.getmenu(), "18k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_18K);
            Buttons.Button(mic.getmenu(), "16k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_16K);
            Buttons.Button(mic.getmenu(), "10k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_10K);
            Buttons.Button(mic.getmenu(), "8k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_8K);

            Buttons.Button(mic.getmenu(), "Default Mic Volume", () => USpeaker.field_Internal_Static_Single_1 = 1);
            Buttons.Button(mic.getmenu(), "Max Volume]", () => USpeaker.field_Internal_Static_Single_1 = float.MaxValue);

            Buttons.Button(mic.getmenu(), "Mic Volume [+]", () => USpeaker.field_Internal_Static_Single_1 += 1);
            Buttons.Button(mic.getmenu(), "Mic Volume [-]", () => USpeaker.field_Internal_Static_Single_1 -= 1);



        }

    }
}
