using Nocturnal.Apis;
using UnityEngine;
namespace Nocturnal.Ui
{
	internal class ResourceImages
	{

		internal static void setupc()
		{
			var gmj = Resources.FindObjectsOfTypeAll<ImageThreeSlice>();
			for (int i = 0; i < gmj.Length; i++)
			{
				if (gmj[i].name == "Background" && gmj[i].transform.parent.name == "Main")
				{
					Apis.ChangeImage.Loadfrombytes(gmj[i].gameObject, Settings.DownloadFiles.nameplates, false);
					gmj[i].transform.parent.parent.transform.Find("Icon/Background").gameObject.Loadfrombytes(Settings.DownloadFiles.nameplateIcon);
				}
			}
		}
	}
}
