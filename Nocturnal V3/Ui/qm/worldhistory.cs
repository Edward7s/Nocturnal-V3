using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nocturnal;
using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using UnityEngine;
using VRC.SDKBase;

namespace Nocturnal.Ui.qm
{
    internal class Worldhistory
    {
        internal static GameObject worldhistorymenu { get; set; }
        internal static List<Settings.jsonmanager.worldhistory> _WorldHistory { get; set; }
        internal static UnityEngine.UI.Button[] _Buttons { get; set; }
        internal static void createrhistory()
        {
            worldhistorymenu = submenu.Create("World History", Main._mainpage);
            new Submenubutton(Main._mainpage.Getmenu(), "World History", worldhistorymenu, Settings.Download_Files.imagehandler.worldhistory, true, 2, 2);

        }
        internal static void updatehistory(string worldname, string wolrdid)
        {

            _WorldHistory = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Settings.jsonmanager.worldhistory>>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\WorldHistory.json"));
            if (_WorldHistory.Any())
                _WorldHistory.RemoveAt(_WorldHistory.Count - 1);

            var newworldh = new Settings.jsonmanager.worldhistory()
            {
                worldid = wolrdid,

                worldname = worldname,
            };

            _WorldHistory.Insert(0, newworldh);

            var serialized = Newtonsoft.Json.JsonConvert.SerializeObject(_WorldHistory);
            File.WriteAllText((Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\WorldHistory.json"), serialized);

            _Buttons = worldhistorymenu.Getmenu().GetComponentsInChildren<UnityEngine.UI.Button>(true).Where(gmj => gmj.gameObject != worldhistorymenu.Getmenu().gameObject).ToArray();
            for (int i = 0; i < _Buttons.Length; i++)
            {
                try
                {
                    GameObject.DestroyImmediate(_Buttons[i].gameObject);
                }
                catch { }
            }
            _WorldHistory = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Settings.jsonmanager.worldhistory>>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\WorldHistory.json"));
           foreach (var world in _WorldHistory)
            {
                new NButton(worldhistorymenu.Getmenu(), world.worldname, () =>
                {
                    try
                    {
                        if (!Networking.GoToRoom(world.worldid))
                        {
                            string[] array = world.worldid.Split(':');
                            new PortalInternal().Method_Private_Void_String_String_PDM_0(array[0], array[1]);
                        }
                    }
                    catch (Exception e) { NocturnalC.Log(e); }

                }, true);
            }
         }
        }
    }
