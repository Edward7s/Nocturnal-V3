using System;
using UnityEngine;
using Nocturnal.Ui.qm;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using Nocturnal.Settings;
namespace Nocturnal.Ui.qm
{
    internal class Toggles
    {
        internal static void Runantoggles()
        {
            var toggles = submenu.Create("Toggles", Main.s_mainpage);
            new Submenubutton(Main.s_mainpage.Getmenu(), "Toggles", toggles, Settings.Download_Files.imagehandler.Toggles, false, 3, 1);

           new NToggle("Hwid Spoofer", toggles.Getmenu(), () => ConfigVars.HwidSpoof = true, () => ConfigVars.HwidSpoof = false, ConfigVars.HwidSpoof);
           new NButton(toggles.Getmenu(), "Change HWID", () => ConfigVars.SpoofedHWID = Guid.NewGuid().ToString().Replace("-", "3"));
            new NToggle("Fly On Space DoubleTap", toggles.Getmenu(), () => ConfigVars.DoubleSpaceFly = true, () => ConfigVars.DoubleSpaceFly = false, ConfigVars.DoubleSpaceFly);
            new NToggle("Rocket Jump", toggles.Getmenu(), () => ConfigVars.RocketJump = true, () => ConfigVars.RocketJump = false, ConfigVars.RocketJump);
            new NToggle("Force Jump", toggles.Getmenu(), () => ConfigVars.forcejump = true, () => ConfigVars.forcejump = false, ConfigVars.forcejump);
            new NToggle("Infinite Jump", toggles.Getmenu(), () => ConfigVars.infinitejump = true, () => ConfigVars.infinitejump = false, ConfigVars.infinitejump);
            new NToggle("Third Person", toggles.Getmenu(), () => ConfigVars.Thidperson = true, () => ConfigVars.Thidperson = false, ConfigVars.Thidperson);
            new NToggle("Bhop", toggles.Getmenu(), () => ConfigVars.bhop = true, () => ConfigVars.bhop = false, ConfigVars.bhop);
            new NToggle("Join Sound", toggles.Getmenu(), () => ConfigVars.joinsound = true, () => ConfigVars.joinsound = false, ConfigVars.joinsound);
            new NToggle("Join Friends Sound Only", toggles.Getmenu(), () => ConfigVars.onlyfriendjoin = true, () => ConfigVars.onlyfriendjoin = false, ConfigVars.onlyfriendjoin);
            new NToggle("Hide Questies", toggles.Getmenu(), () =>{
                ConfigVars.hidequests = true;
                var playes = extensions.getallplayers();
                for (int i = 0; i < playes.Length; i++)
                {
                    if (playes[i].prop_APIUser_0.last_platform != "standalonewindows" && !playes[i].IsFriend())
                        playes[i].gameObject.SetActive(false);
                }
            }, () => {
                ConfigVars.hidequests = false;
                var playes = extensions.getallplayers();
                for (int i = 0; i < playes.Length; i++)
                {
                    if (playes[i].prop_APIUser_0.last_platform != "standalonewindows" && !playes[i].IsFriend())
                        playes[i].gameObject.SetActive(true);
                }
            }, ConfigVars.hidequests);

        
            new NToggle("Udon Block", toggles.Getmenu(), () => Settings.ConfigVars.udonblock = true, () => Settings.ConfigVars.udonblock = false, Settings.ConfigVars.udonblock);
            new NToggle("Only Friends Portal", toggles.Getmenu(), () => Settings.ConfigVars.OnlyFriendsPortals = true, () => Settings.ConfigVars.OnlyFriendsPortals = false, Settings.ConfigVars.OnlyFriendsPortals);
            new NToggle("No Portals", toggles.Getmenu(), () => Settings.ConfigVars.NoPortals = true, () => Settings.ConfigVars.NoPortals = false, Settings.ConfigVars.NoPortals);
            new NToggle("Offline Spoof", toggles.Getmenu(), () => Settings.ConfigVars.OfflineSpoof = true, () => Settings.ConfigVars.OfflineSpoof = false, Settings.ConfigVars.OfflineSpoof);
            new NToggle("Camera", toggles.Getmenu(), () => {
                Settings.ConfigVars.CameraView = true;
                try
                {
                    VRC.Player.prop_Player_0.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/Camera").gameObject.SetActive(true);
                    GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/Camera Render").gameObject.SetActive(true);
                }
                catch { }
          
            }, () =>
            {
                Settings.ConfigVars.CameraView = false;

                try
                {
                    VRC.Player.prop_Player_0.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/Camera").gameObject.SetActive(false);
                    GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/Camera Render").gameObject.SetActive(false);
                }
                catch { }

            }, Settings.ConfigVars.CameraView);
            new Apis.Slider(toggles.Getmenu(), val => Settings.ConfigVars.ZCamera = val, Settings.ConfigVars.ZCamera,new Action(()=>  VRC.Player.prop_Player_0.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/Camera").transform.localPosition = new UnityEngine.Vector3(0,  - Settings.ConfigVars.YCamera * 2, Settings.ConfigVars.ZCamera * 5)),false,"Z");
            new Apis.Slider(toggles.Getmenu(), val => Settings.ConfigVars.YCamera = val, Settings.ConfigVars.YCamera, new Action(() => VRC.Player.prop_Player_0.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/Camera").transform.localPosition = new UnityEngine.Vector3(0, - Settings.ConfigVars.YCamera * 2, Settings.ConfigVars.ZCamera * 5)), false, "Y");
            new Apis.Slider(toggles.Getmenu(), val => Settings.ConfigVars.CameraOpacity = val, Settings.ConfigVars.CameraOpacity, ()=> GameObject.Find("/UserInterface").transform.Find("UnscaledUI/HudContent_Old/Hud/Camera Render").gameObject.GetComponent<UnityEngine.UI.RawImage>().color = new Color(1,1,1,ConfigVars.CameraOpacity), false, "Opacity");

        }


    }
}
