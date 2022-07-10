using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Nocturnal.Settings
{
    [Serializable]

    internal class Config
    {
        public string? QmDebbugerImg { get; set; }
        public string? BiguiImg { get; set; }
        public string? PlayerListImg { get; set; }
        public string? QmImg { get; set; }
        public float? QMopacity { get; set; }

        public float? BigImgOpacity { get; set; }


        public float? clientvolume { get; set; }
        public bool? esp { get; set; }
        public float? Flyspeed { get; set; }
        public float? jumpimpulse { get; set; }
        public float? espwidth { get; set; }
        public float? debuggeropacity { get; set; }
        public bool? qmdebug { get; set; }
        public bool? thunderbigui { get; set; }
        public float? falloff { get; set; }
        public bool? itemmaxrange { get; set; }
        public bool? itempickup { get; set; }
        public bool? qmmusic { get; set; }
        public int? maxverticies { get; set; }
        public int? maxaudiosources { get; set; }
        public int? maxmaterials { get; set; }
        public int? maxmeshes { get; set; }
        public int? maxparticles { get; set; }
        public int? particlesystem { get; set; }
        public bool? verticiesp { get; set; }
        public bool? meshp { get; set; }
        public bool? ShaderP { get; set; }
        public bool? audiosourcep { get; set; }
        public bool? particlep { get; set; }
        public bool? linerenderp { get; set; }
        public bool? lightsp { get; set; }
        public bool? selfanti { get; set; }
        public bool? logshaderstoconsole { get; set; }

        public float[]? visitor { get; set; }
        public float[]? newuser { get; set; }
        public float[]? user { get; set; }
        public float[]? known { get; set; }
        public float[]? trusted { get; set; }
        public float[]? superpowers { get; set; }
        public float[]? Moderator { get; set; }
        public float[]? friend { get; set; }
        public bool? playerlist { get; set; }
        public bool? rightsideplayerlist { get; set; }
         public float? playelerlistopacity { get ; set; }

        public float[]? ButtonColor { get; set; }
        public float[]? HuDColor { get; set; }
        public float[]? textcolor { get; set; }

        public bool? forcejump { get; set; }

        public bool? infinitejump { get; set; }
        public bool? speed { get; set; }

        public float? speedvalue { get; set; }

        public bool? Thidperson { get; set; }
        public bool? bhop { get; set; }
        public bool? joinsound { get; set; }
        public bool? onlyfriendjoin { get; set; }

        public bool? hidequests { get; set; }
        public bool? itemesp { get; set; }
        public bool? allowitemtheft { get; set; }
        public bool? murdergoldweapon { get; set; }
        public bool? murdergodmod { get; set; }
        public bool? everyonegoldgun { get; set; }
        public bool? amongusgodmod { get; set; }
        public bool? continuesfire { get; set; }
        public bool? everyonecontinuesfire { get; set; }
        public bool? qminfopannel { get; set; }
        public string? chatimage { get; set; }
        public bool? rainbackground { get; set; }
        public bool? discordrichpresence { get; set; }
        public bool? udonblock { get; set; }
        public bool? hudUi { get; set; }
        public bool? toggleonscreenlogger { get; set; }
        public string? Customanmespoof { get; set; }
        public bool? onlywauthornamespoof { get; set; }
        public bool? joinnotif { get; set; }
        public bool? HwidSpoof { get; set; }
        public string? SpoofedHWID { get; set; }
        public bool? ItemThrowBoost { get; set; }
        public float? ItemThrowBoostValue { get; set; }
        public bool? SelfTrail { get; set; }
        public bool? EveryoneTrail { get; set; }
        public bool? HudUi { get; set; }
        public bool? OnlyFriendsPortals { get; set; }
        public bool? NoPortals { get; set; }
        public bool? EspSizeOverDistance { get; set; }
        public bool? DoubleSpaceFly { get; set; }
        public bool? RocketJump { get; set; }
        public bool? NamePlatesInfo { get; set; }
        public bool? OfflineSpoof { get; set; }

    }
    internal class ConfigVars
    {
     
        internal static void saveconfig(string path)
        {
            var conf = new Config();
            var props = conf.GetType().GetProperties();
            var getc = typeof(ConfigVars).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            for (int i = 0; i < props.Length; i++)
            {
                var fieldobject = getc.Where(obj => obj.Name == props[i].Name).FirstOrDefault();
                if (fieldobject == null) continue;
                props[i].SetValue(conf, fieldobject.GetValue(getc));
            }
            File.WriteAllText(path, $"{Newtonsoft.Json.JsonConvert.SerializeObject(conf)}"); 
        }
        internal static void applyconfig(string path, Config config)
        {
            var props = config.GetType().GetProperties();
            var getc = typeof(ConfigVars);
            var fields = getc.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            for (int i = 0; i < fields.Length; i++)
            {
                var propobj = props.Where(obj => obj.Name == fields[i].Name).FirstOrDefault();
                if (propobj == null) continue;
                fields[i].SetValue(getc, propobj.GetValue(config));
            }
            saveconfig(path);
        }
        public static string QmDebbugerImg = "https://cutewallpaper.org/21/black-aesthetic-anime/Image-about-girl-in-black-aesthetic-by-Quantis.png";
        public static string BiguiImg = "https://nocturnal-client.xyz/BigUi.png";
        public static string PlayerListImg = "https://i.pinimg.com/564x/4e/70/5a/4e705a534d03153e9800b2ba676bf1ee.jpg";
        public static string QmImg = "https://i.pinimg.com/564x/54/24/3b/54243bfa9ea67ed8be8ee4dc4e015e6e.jpg";
        public static float QMopacity = 0.8f;
        public static float playelerlistopacity = 0.8f;
        public static float clientvolume = 0.4f;
        public static float BigImgOpacity = 0.7f;
        public static bool esp = true;
        public static float Flyspeed = 0.6f;
        public static float jumpimpulse = 3f;
        public static float espwidth = 0.35f;
        public static float debuggeropacity = 0.7f;
        public static bool qmdebug = true;
        public static bool thunderbigui = false;
        public static float falloff = 0.1f;
        public static bool itemmaxrange = true;
        public static bool itempickup= true;
        public static bool qmmusic = true;
        public static bool avataroutline = true;
        public static int maxaudiosources = 15;
        public static int maxmaterials = 60;
        public static int maxmeshes = 100;
        public static int maxverticies = 200000;
        public static int maxparticles = 30000;
        public static int particlesystem = 30;
        public static bool verticiesp = true;
        public static bool meshp = true;
        public static bool ShaderP = true;
        public static bool audiosourcep = true;
        public static bool particlep = true;
        public static bool linerenderp = true;
        public static bool lightsp = true;
        public static bool selfanti = false;
        public static bool logshaderstoconsole = true;
        public static float[] visitor = new float[] {1, 1, 1,1};
        public static float[] newuser = new float[] { 1, 0.7f, 1,1 };
        public static float[] user = new float[] { 0, 1, 0 ,1 };
        public static float[] known = new float[] { 0.8f, 0.2f, 0 ,1};
        public static float[] trusted = new float[] { 0.6f, 0, 0.95f,1 };
        public static float[] superpowers = new float[] { 0.6f, 0, 0,1 };
        public static float[] Moderator = new float[] { 1, 0, 0 ,1};
        public static float[] friend = new float[] { 1, 1, 0 ,1};
        public static bool playerlist = true;
        public static bool rightsideplayerlist = true;
        public static float[] ButtonColor = new float[] { 0, 0, 0, 1 };
        public static float[] HuDColor = new float[] { 0.2f, 0, 0.5f, 0.9f };
        public static float[]  textcolor = new float[] { 1f, 0.1f, 0.2f, 1f };
        public static bool forcejump = false;
        public static bool infinitejump = true;
        public static float speedvalue = 10;
        public static bool speed = false;
        public static bool Thidperson = true;
        public static bool bhop = false;
        public static bool joinsound = true;
        public static bool onlyfriendjoin = false;
        public static bool hidequests = false;
        public static bool itemesp = false;
        public static bool allowitemtheft = true;
        public static bool murdergoldweapon = false;
        public static bool murdergodmod = false;
        public static bool everyonegoldgun = false;
        public static bool amongusgodmod = false;
        public static bool continuesfire = false;
        public static bool everyonecontinuesfire = false;
        public static bool qminfopannel = true;
        public static string chatimage = "https://nocturnal-client.xyz/Resources/img.jpg";
        public static bool rainbackground = true;
        public static bool discordrichpresence = true;
        public static bool udonblock = false;
        public static bool hudUi = true;
        public static bool toggleonscreenlogger = true;
        public static string Customanmespoof = "Edward7";
        public static bool onlywauthornamespoof = true;
        public static bool joinnotif = true;
        public static bool HwidSpoof = false;
        public static string SpoofedHWID = Guid.NewGuid().ToString().Replace("-", "3");
        public static bool ItemThrowBoost = false;
        public static float ItemThrowBoostValue = 7f;
        public static bool SelfTrail = false;
        public static bool EveryoneTrail = false; 
        public static bool HudUi = true;
        public static bool OnlyFriendsPortals = true;
        public static bool NoPortals = false;
        public static bool EspSizeOverDistance = true;
        public static bool DoubleSpaceFly = false;
        public static bool RocketJump = false;
        public static bool NamePlatesInfo = true;
        public static bool OfflineSpoof = false;
    }
}
