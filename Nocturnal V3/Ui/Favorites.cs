using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
namespace Nocturnal.Ui
{
    internal class Favorites
    {
        internal static List<string> _MenuList = new List<string>();
        internal static Apis.AvatarFav FavMenu { get; set; }
        internal static List<Settings.jsonmanager.Menu> _Menus = new List<Settings.jsonmanager.Menu>();

        internal static void Run()
        {
             Ui.Objects._Favorite = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Avatar/Vertical Scroll View/Viewport/Content/Personal Avatar List").gameObject;
             Ui.Objects._ViewPortAvi = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Avatar/Vertical Scroll View/Viewport").GetComponent<RectTransform>();
            /*   var menu = new Apis.AvatarFav("Test");
               new Apis.AvatarFav(menu._Content, "avtr_d3e0a410-3093-4e98-b310-122b1dae5636", "Test", "A", "https://i.pinimg.com/564x/09/7d/93/097d9390e669050955f8a734e9e7c4bb.jpg", "https://api.vrchat.cloud/api/1/file/file_a7e82caf-b6bd-4aee-9f18-05144b07c583/8/file");*/


            //Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json"

            if (File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json") == string.Empty)
            {
                var avatarsfav = new List<Settings.jsonmanager.Menu>();
                avatarsfav.Add(new Settings.jsonmanager.Menu() { AviMenu = "Nocturnal's Default Favorites" });
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json", JsonConvert.SerializeObject(avatarsfav));
            }
            var text = JsonConvert.DeserializeObject<List<Settings.jsonmanager.Menu>>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json"));


            foreach (var menu5 in text)
            {
                new Apis.bigui.Toggle(Ui.Qm_basic._Content.transform, menu5.AviMenu, () => _MenuList.Add(menu5.AviMenu), () => _MenuList.Remove(menu5.AviMenu), Vector3.zero);
                FavMenu = new Apis.AvatarFav(menu5.AviMenu);
                if (menu5.Avatars == null) continue;
                for (int i2 = 0; i2 < menu5.Avatars.Count; i2++)
                    new Apis.AvatarFav(FavMenu._Content, menu5.Avatars[i2].id, menu5.Avatars[i2].name, menu5.Avatars[i2].platform, menu5.Avatars[i2].img,
                        menu5.Avatars[i2].url);
            }

            Ui.Qm_basic._Content.transform.parent.gameObject.SetActive(false);
            GameObject path = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Avatar").gameObject;
            GameObject menu = null;
            new Apis.bigui.BButton(out menu, "Create Category", path, () =>
              {
                  string Name = "";
                  Settings.XRefedMethods.PopOutInput("Category Name", c => Name = c, () =>
                    {
                        string text2 = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json");
                        var deserialized = JsonConvert.DeserializeObject<List<Settings.jsonmanager.Menu>>(text2);

                        for (int i = 0; i < deserialized.Count; i++)
                        {
                            if (deserialized[i].AviMenu == Name)
                            {
                                Settings.XRefedMethods.PopOutWarrningMessage("There is already a menu set with this name");
                                return;
                            }
                                
                        }
                        File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json",text2.Remove(text2.Length - 1) + "," + JsonConvert.SerializeObject(new Settings.jsonmanager.Menu() { AviMenu = Name }) + "]");
                        new Apis.AvatarFav(Name);
                        new Apis.bigui.Toggle(Ui.Qm_basic._Content.transform, Name, () => _MenuList.Add(Name), () => _MenuList.Remove(Name), Vector3.zero);

                    });

              });
            GameObject menu2 = null;
            new Apis.bigui.BButton(out menu2, "Remove Menu", path, () =>
            {
                string Name = "";
                Settings.XRefedMethods.PopOutInput("Category Name", c => Name = c, () =>
                {
                    if (Name == "Nocturnal's Default Favorites") return;
                    string text2 = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json");
                    var deserialized = JsonConvert.DeserializeObject<List<Settings.jsonmanager.Menu>>(text2);
                    if (deserialized.Where(v => v.AviMenu == Name).FirstOrDefault() == null) return;
                    var NewList = new List<Settings.jsonmanager.Menu>();
                    for (int i = 0; i < deserialized.Count; i++)
                    {
                        if (deserialized[i].AviMenu == Name) continue;
                        NewList.Add(deserialized[i]);
                    }
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json",
                       JsonConvert.SerializeObject(NewList));
                    GameObject.DestroyImmediate(Ui.Objects._Favorite.transform.parent.transform.Find("NF_" + Name).gameObject);
                    GameObject.DestroyImmediate(Ui.Qm_basic._Content.transform.Find(Name).gameObject);
                    _MenuList.Remove(Name);
                });

            });
            GameObject menu3 = null;
            new Apis.bigui.BButton(out menu3, "Remove Avatar", path, () =>
            {
              GameObject.DestroyImmediate(Ui.Objects._Favorite.transform.parent.transform.Find(Apis.AvatarFav._MenuAndAvi.ElementAt(0).Value + "/Button(Clone)/Content/" + Apis.AvatarFav._MenuAndAvi.ElementAt(0).Key).gameObject);
            var text = JsonConvert.DeserializeObject<List<Settings.jsonmanager.Menu>>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json"));
                _Menus.Clear();
                for (int i = 0; i < text.Count; i++)
                {
                    if (text[i].AviMenu != Apis.AvatarFav._MenuAndAvi.ElementAt(0).Value.Replace("NF_", ""))
                    {
                        _Menus.Add(text[i]); continue;
                    }
                    if (text[i].Avatars.Count == 1)
                    {
                        text[i].Avatars = null;
                        _Menus.Add(text[i]); 
                        continue;
                    }
                    for (int j = 0; j < text[i].Avatars.Count; j++)
                    {
                        if (text[i].Avatars[j].id != Apis.AvatarFav._MenuAndAvi.ElementAt(0).Key) continue;
                        text[i].Avatars.Remove(text[i].Avatars[j]);
                    }
                    _Menus.Add(text[i]);
                }
                if (_Menus.Count != 0)
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\AvatarFav.json", JsonConvert.SerializeObject(_Menus));
            });

            menu3.transform.localPosition = new Vector3(-850f, -388, 0);
            menu2.transform.localPosition = new Vector3(-850f, -315, 0);
            menu.transform.localPosition = new Vector3(-850f, -460, 0);


            

        }

    }
}
