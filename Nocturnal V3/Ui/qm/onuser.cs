using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using Nocturnal.Apis;
using System.IO;
using VRC;
using Newtonsoft.Json;

namespace Nocturnal.Ui.qm
{
    internal class Onuser
    {
        internal static void _Onuser()
        {
            var menu = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions").gameObject;
             new NButton(menu, "Whitelist Anticrash", () => {
                var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;

                if (!File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist").Contains(id))
                {
                    File.AppendAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist", $"\n{id}");
                    Settings.Download_Files.userwhitelist = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist");
                }

            });

             new NButton(menu, "Remove Whitelist Anticrash", () => {
                var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;

                if (File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist").Contains(id))
                {
                    var ac = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist");
                    var splited = ac.Split(new string[] { "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                    string becomingback = "";
                    for (int i = 0; i < splited.Length; i++)
                    {
                        var trimduser = splited[i].Trim();
                        if (trimduser != id)
                            becomingback += $"{trimduser}\n";
                    }
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist", becomingback);

                    Settings.Download_Files.userwhitelist = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AntiCrash.whitelist");
                }

            });


             new NButton(menu, "Target User", () => Nocturnal.Settings.wrappers.Target.Targetuser(GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id));
             new NButton(menu, "Teleport", () =>
            {

                var User = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
                           Player.prop_Player_0.transform.position = User.getuserbyid().transform.position;
              
            },false,Settings.Download_Files.imagehandler.teleport);
             new NButton(menu, "Force Clone", () =>
            {
                var aviid = "";
                var User = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
                try
                {
                    var user = User.getuserbyid();

                    if (user.field_Private_APIUser_0.id == User)
                            aviid = user.prop_ApiAvatar_0.id;
  
                    Exploits.Misc.Changetoavi(aviid);
                }
                catch { }


            });
             new NButton(menu, "Copy uid", () => System.Windows.Forms.Clipboard.SetText(GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id));

             new NButton(menu, "Lewd", () => {

                    var id = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id;
                Exploits.Forcelewd.Foreelwed(extensions.getuserbyid(id));
            });

            new NButton(menu, "Favorite Avatar", () => {
                var user = GameObject.Find("/_Application").transform.Find("UIManager/SelectedUserManager").gameObject.GetComponent<VRC.DataModel.UserSelectionManager>().field_Private_APIUser_1.id.getuserbyid();

                if (user.prop_ApiAvatar_0.releaseStatus != "public")
                {
                    Settings.XRefedMethods.PopOutWarrningMessage("U can not favorite a private avatar");
                    return;
                }
                Qm_basic._Content.transform.parent.gameObject.SetActive(true);

                Settings.XRefedMethods.PopOutToggle("Select A Favorite List And Press Ok", "",() => {

                    var text = JsonConvert.DeserializeObject<List<Settings.jsonmanager.Menu>>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json"));
                    for (int i = 0; i < Favorites._MenuList.Count; i++)
                    {
                        _List.Clear();
                        for (int i3 = 0; i3 < text.Count; i3++)
                        {
                            if (text[i3].AviMenu != Favorites._MenuList[i])
                            {
                                _List.Add(text[i3]);
                                continue;
                            } 
                            _Id = user.prop_ApiAvatar_0.id;
                            _Name = user.prop_ApiAvatar_0.name;
                            _Img = user.prop_ApiAvatar_0.imageUrl;
                            _AssetBundle = user.prop_ApiAvatar_0.assetUrl;
                            switch (true)
                            {
                                case true when user.prop_ApiAvatar_0.supportedPlatforms == VRC.Core.ApiModel.SupportedPlatforms.Android:
                                    _Letter = "Q";
                                    break;
                                case true when user.prop_ApiAvatar_0.supportedPlatforms == VRC.Core.ApiModel.SupportedPlatforms.All:
                                    _Letter = "A";
                                    break;
                                case true when user.prop_ApiAvatar_0.supportedPlatforms == VRC.Core.ApiModel.SupportedPlatforms.StandaloneWindows:
                                    _Letter = "P";
                                    break;
                            }
                            new Apis.AvatarFav(Objects._Favorite.transform.parent.transform.Find("NF_" + Favorites._MenuList[i] + "/Button(Clone)/Content").gameObject, _Id, _Name, _Letter, _Img, _AssetBundle);
                            var avatar = new Settings.jsonmanager.AvatarFav()
                            {
                                id = _Id,
                                img = _Img,
                                name = _Name,
                                platform = _Letter,
                                url = _AssetBundle,
                            };

                            if (text[i3].Avatars == null)
                            {
                                text[i3].Avatars = new List<Settings.jsonmanager.AvatarFav>();
                                text[i3].Avatars.Add(avatar);
                                _List.Add(text[i3]);
                                continue;
                            }
                            text[i3].Avatars.Add(avatar);
                            _List.Add(text[i3]);
                        }
                        
                    }
                    if (_List.Count != 0)
                    {
                        var cbt = Qm_basic._Content.GetComponentsInChildren<UnityEngine.UI.Toggle>();
                        for (int i = 0; i < cbt.Length; i++)
                        {
                            if (cbt[i].isOn)
                            cbt[i].isOn = false;
                        }
                        File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json", JsonConvert.SerializeObject(_List));

                    }

                    //Nocturnal.Ui.Favorites._MenuList.Clear();
                },
                ()=> {
                    var cbt = Qm_basic._Content.GetComponentsInChildren<UnityEngine.UI.Toggle>();
                    for (int i = 0; i < cbt.Length; i++)
                    {
                        if (cbt[i].isOn)
                            cbt[i].isOn = false;
                    }
                });


            });


        }
        private static List<Settings.jsonmanager.Menu> _List = new List<Settings.jsonmanager.Menu>();

        private static string _Letter { get; set; }

        private static string _AssetBundle { get; set; }

        private static string _Img { get; set; }

        private static string _Name { get; set; }

        private static string _Id { get; set; }
    }
}
