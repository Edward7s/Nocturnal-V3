using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocturnal.Settings
{
    public static class jsonmanager
    {
        [Serializable]
        public class worldhistory
        {
            public string worldname { get; set; }

            public string worldid { get; set; }
        }
        public class custommsg
        {
            public string msg { get; set; }

            public string code { get; set; }
        }

        public class user
        {
            public string uid { get; set; }

            public string[] tags { get; set; }

        }

        public class custommsgarr
        {
            public custommsg2[] msg { get; set; }

            public string code { get; set; }
        }

        public class custommsg2
        {
            public string msg { get; set; }
            public string msg2 { get; set; }

            public string code { get; set; }
        }
        public class reciveplate
        {
            public string code { get; set; }

            public string userid { get; set; }

            public string[] tagslist { get; set; }
        }

        public class discordrpc
        {
            public string Details { get; set; }

            public string State { get; set; }

            public string LargeImage { get; set; }

            public bool  ison { get; set; }

        }


        public class Menu
        {
            public string AviMenu { get; set; }
            public List<AvatarFav> Avatars { get; set; }
        }
        public class Webscoekt
        {
            public string type { get; set; }
            public string content { get; set; }
        }
        public class KeyBindsManager
        {          
            public Dictionary<string,string[]> KeyBindsButtonDictionary { get; set; }
            public Dictionary<string, string[]> KeyBindsToggleDictionary { get; set; }
        }

        public class SingleTag
        {
            public string uid { get; set; }
            public string tag { get; set; }
        }

        public class UserFromWebsocket
        {
            public string userId { get; set; }
            public VRC.Core.APIUser user { get; set; }
            public string location { get; set; }
            public string travelingToLocation { get; set; }
            public string world { get; set; }
            public string canRequestInvite { get; set; }


        }

        public class AvatarFav
        {
            public string id { get; set; }
            public string name { get; set; }
            public string platform { get; set; }
            public string img { get; set; }
            public string url { get; set; }

        }



        public class PostProccesingJs
        {
            public float Bloom { get; set; }
            public float Exposure { get; set; }
            public float[] Gamma { get; set; }
            public float Saturation { get; set; }
            public float Temperature { get; set; }
            public float Tint { get; set; }
            public bool BloomTogg { get; set; }
            public bool ColorGradinat { get; set; }
            public bool PostProccesing { get; set; }
        }

        public class downloadhandler
        {
            public string nameplates { get; set; }
            public string Nameplateicon { get; set; }
            public string playerlistmask { get; set; }
            public string playerlistborder { get; set; }
            public string quickmenumask { get; set; }
            public string Main { get; set; }
            public string Saveconfig { get; set; }
            public string EnterKey { get; set; }
            public string ui { get; set; }
            public string Toggles { get; set; }
            public string Target { get; set; }
            public string Anitcrash { get; set; }
            public string Colors { get; set; }
            public string clipboard { get; set; }
            public string World { get; set; }
            public string items { get; set; }
            public string worldhistory { get; set; }
            public string mute { get; set; }
            public string defean { get; set; }
            public string next { get; set; }
            public string prev { get; set; }
            public string stopplay { get; set; }
            public string logo { get; set; }
            public string chatmask { get; set; }
            public string chat { get; set; }
            public string Mirror { get; set; }
            public string OptimizedMirror { get; set; }
            public string teleport { get; set; }
            public string tag { get; set; }
            public string Discord { get; set; }
            public string micmenu { get; set; }
            public string PremiumIcon {get; set;}
            public string Backgroundb { get; set;}
            public string PostProccessing { get; set; }
            public string MirrorMover { get; set; }
            public string Button { get; set; }
            public string TabIcon { get; set; }

        }
    }

  
}
