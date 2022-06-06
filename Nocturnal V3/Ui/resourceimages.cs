
using UnityEngine;
using Nocturnal.Apis;
namespace Nocturnal.Ui
{
    internal class resourceimages
    {

        internal static void Setupc()
        {
            var gmj = Resources.FindObjectsOfTypeAll<ImageThreeSlice>();
            for (int i = 0; i < gmj.Length; i++)
            {
                if (gmj[i].name == "Background" && gmj[i].transform.parent.name == "Main")
                {
                    Apis.Change_Image.Loadfrombytes(gmj[i].gameObject, Settings.Download_Files.imagehandler.nameplates, false);
                    gmj[i].transform.parent.parent.transform.Find("Icon/Background").gameObject.Loadfrombytes(Settings.Download_Files.imagehandler.Nameplateicon);
                }
            }
        }
    }
}
