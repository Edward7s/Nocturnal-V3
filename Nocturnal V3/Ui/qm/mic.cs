using Nocturnal.Apis.QM;
using Nocturnal.Settings.Wrappers;
namespace Nocturnal.Ui.QM
{
	internal class Mic
	{
		internal static TMPro.TextMeshProUGUI chatText = null;
		internal static void CreateUI()
		{
			var mic = SubMenu.Create("Mic", Main.mainPage);
			Main.mainPage.GetMenu().Create("Mic", mic, Settings.DownloadFiles.micmenu, true, 1, 5);
			Button.Create(mic.GetMenu(), "Default Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_24K);
			Button.Create(mic.GetMenu(), "20k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_20K);
			Button.Create(mic.GetMenu(), "18k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_18K);
			Button.Create(mic.GetMenu(), "16k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_16K);
			Button.Create(mic.GetMenu(), "10k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_10K);
			Button.Create(mic.GetMenu(), "8k Bitrate", () => VRCPlayer.field_Internal_Static_VRCPlayer_0.field_Private_USpeaker_0.field_Private_BitRate_0 = BitRate.BitRate_8K);

			Button.Create(mic.GetMenu(), "Default Mic Volume", () => USpeaker.field_Internal_Static_Single_1 = 1);
			Button.Create(mic.GetMenu(), "Max Volume]", () => USpeaker.field_Internal_Static_Single_1 = float.MaxValue);

			Button.Create(mic.GetMenu(), "Mic Volume [+]", () => USpeaker.field_Internal_Static_Single_1 += 1);
			Button.Create(mic.GetMenu(), "Mic Volume [-]", () => USpeaker.field_Internal_Static_Single_1 -= 1);
		}
	}
}
