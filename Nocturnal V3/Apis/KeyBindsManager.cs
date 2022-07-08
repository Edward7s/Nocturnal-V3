using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
namespace Nocturnal.Apis
{

    public class ButtonType
    {
        public Action Action { get; set; }

        public KeyCode[] KeyCodes { get; set; }
    }

    public class ToggleType
    {
        public Action ActionOn { get; set; }
        public Action ActionOff { get; set; }
        public KeyCode[] KeyCodes { get; set; }
        public bool Bool { get; set; }
    }

 

    internal class KeyBindsManager
    {
        //In Proggress
     
        private Enum _Enum { get; set; }
        internal static Dictionary<string, ButtonType> _InstanceButtons { get; set; } = new Dictionary<string, ButtonType>();
        internal static Dictionary<string, ToggleType> _InstanceToggles { get; set; } = new Dictionary<string, ToggleType>();

        internal static Dictionary<string, string[]> _InstanceStrings { get; set; } = new Dictionary<string, string[]>();

        internal static void ChangeKeys<TKey, TValue>(IDictionary<TKey, TValue> dic,
                                      TKey fromKey, TKey toKey)
        {
            TValue value = dic[fromKey];
            dic.Remove(fromKey);
            dic[toKey] = value;
        }

        private KeyCode GetKey(string KeyCodeName)
        {
            Enum.TryParse(KeyCodeName, out KeyCode KeyCode);
            return KeyCode;
        }
        private string GetStringKey(KeyCode KeyCode)
        {
            _Enum = KeyCode;
            return _Enum.ToString();
        }
        public KeyBindsManager(string Path)
        {
            Settings.Download_Files.s_keybindsPath = Path;
          
            if (!File.Exists(Path))
            {
                var var1 = new Dictionary<string, string[]>();
                var1.Add("_Button_Delete P", new string[] { "J" });
                var var2 = new Dictionary<string, string[]>();
                var2.Add("Toggle_Fly", new string[] { "F", "LeftControl" });
                var Json = new Settings.jsonmanager.KeyBindsManager()
                {
                    KeyBindsButtonDictionary = var1,
                    KeyBindsToggleDictionary = var2
                };
                File.WriteAllText(Path, JsonConvert.SerializeObject(Json));
            }
            var keyBindsJson = JsonConvert.DeserializeObject<Settings.jsonmanager.KeyBindsManager>(File.ReadAllText(Path));
            KeyCode[] Keycoesarr = null;
            for (int i = 0; i < keyBindsJson.KeyBindsButtonDictionary.Count; i++)
            {
                keyBindsJson.KeyBindsButtonDictionary.ElementAt(0);


                _InstanceButtons.Add(keyBindsJson.KeyBindsButtonDictionary.ElementAt(0).Key, new ButtonType() { Action = null, KeyCodes = Keycoesarr });
            }


        }

        internal static void ManageKeybinds()
        {
           
        }

    }
}
