using System.IO;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using UnityEngine.Rendering.PostProcessing;
namespace Nocturnal.Ui.qm
{
    internal class PostProccesingConfigs
    {
        internal static UnityEngine.GameObject s_postProccesingConfigMenu { get; private set; }
        internal static void start()
        {

            Inject_monos.s_NocturanlPostProccesing.LoadConfig(Settings.ConfigVars.CurrentConfig);

            s_postProccesingConfigMenu = submenu.Create("Configs", PostProccesing.s_postProccess);
            new Submenubutton(PostProccesing.s_postProccess.Getmenu(), "Post Proccesing", s_postProccesingConfigMenu, Settings.Download_Files.imagehandler.PostProccessing);


            var files = new DirectoryInfo(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\PostProccesing").GetFiles();
            foreach (var file in files)
                new NButton(s_postProccesingConfigMenu.Getmenu(), file.Name.Replace(".json",""), () =>
                {
                    Settings.ConfigVars.CurrentConfig = file.Name.Replace(".json", "");
                    Inject_monos.s_NocturanlPostProccesing.LoadConfig(file.Name.Replace(".json", ""));
                    Inject_monos.s_NocturanlPostProccesing.VisualUpdate();

                });  

        }

    }
}
