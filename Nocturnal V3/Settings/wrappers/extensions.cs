using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using System.Collections;
using UnityEngine.Networking;
using VRC.Core;
using VRC;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Photon.Pun;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Nocturnal.Settings.wrappers
{
    internal static class extensions
    {
      
        internal static GameObject GeneratePlate(this VRC.Player player, string text, string img = null) => GeneratePlate(player._vrcplayer, text, img);



            internal static GameObject GeneratePlate(this VRCPlayer player, string text, string img = null)
        {
            //
            //field_Public_MonoBehaviourPublicSiCoSiGaCoTeGrCoGaHoUnique_0
            var plateprefab = player.gameObject.GetComponent<VRCPlayer>().field_Public_PlayerNameplate_0.field_Public_GameObject_0.transform.Find("Platesmanager/Plate Holder").gameObject;
            var newplate = GameObject.Instantiate(plateprefab, plateprefab.transform.parent);
            newplate.gameObject.SetActive(true);
            newplate.gameObject.transform.Find("PrefabPlate").gameObject.SetActive(true);

            newplate.transform.Find("PrefabPlate/Text").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;
            newplate.gameObject.name = $"_Plate:{text}";
            if (img == null)
                return newplate;

            var icon = newplate.transform.Find("PrefabPlate/Icon").gameObject;
            Apis.Change_Image.Loadfrombytes(icon, img);
            icon.gameObject.SetActive(true);
            return newplate;
        }
        internal static GameObject Getmenu(this GameObject gameobj) { return gameobj.transform.Find("Masked/Scrollrect(Clone)/Viewport/VerticalLayoutGroup").gameObject; }

        internal static void togglecontroller(bool onoroff)
        {
            VRC.Player.prop_Player_0.gameObject.GetComponent<CharacterController>().enabled = onoroff;
        }

        internal static void togglenetworkserializer(bool value)
        {
            VRC.Player.prop_Player_0.gameObject.GetComponent<VRC.Networking.FlatBufferNetworkSerializer>().enabled = value;
        }
        internal static void logobjfromclass(Type theclass, bool methodorpropriety = true)
        {
            if (methodorpropriety)
            {
                var methods = theclass.GetMethods();
                for (int i = 0;i < methods.Length; i++)
                {
                    string prml = "";
                    var parameters = methods[i].GetParameters();
                    for (int i2 = 0; i2 < parameters.Length; i2++)
                    {
                        try
                        {
                            prml += $"{parameters[i].Name} / {parameters[i].ParameterType} =>";

                        }
                        catch { }
                    }
                    

                        NocturnalC.Log($"Method: [{methods[i].Name}]\n" +
                       $"Return parameter: {methods[i].ReturnParameter.Name} / {methods[i].ReturnParameter.ParameterType}\n" +
                       $"Parameters: {prml}\n" +
                       $"Optional Parameters: {methods[i]}\n" +
                       $"Static: {methods[i].IsStatic}\n" +
                       $"Public: {methods[i].IsPublic}\n" +
                       $"Virtual: {methods[i].IsVirtual}", "Debbugging", ConsoleColor.Yellow
                      );
                }
                return;
            }
            var props = theclass.GetProperties(BindingFlags.Public);
            for (int i = 0; i < props.Length; i++)
            {
                NocturnalC.Log($"Public Proopriety: [{props[i].Name}]\n" +
               $"Optional Parameters: {props[i]}\n", "Debbugging", ConsoleColor.Yellow
              );
            }
            var propspri = theclass.GetProperties(BindingFlags.NonPublic);
            for (int i = 0; i < propspri.Length; i++)
            {
                NocturnalC.Log($"nonpublic Proopriety: [{propspri[i].Name}]\n" +
               $"Optional Parameters: {propspri[i]}\n", "Debbugging", ConsoleColor.Yellow
              );
            }
            var propsst = theclass.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            for (int i = 0; i < propsst.Length; i++)
            {
                NocturnalC.Log($"Public Instance Proopriety: [{propsst[i].Name}]\n" +
               $"Optional Parameters: {propsst[i]}\n", "Debbugging", ConsoleColor.Yellow
              );
            }
            var propsprist = theclass.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            for (int i = 0; i < propsprist.Length; i++)
            {
                NocturnalC.Log($"nonpublic Instance Proopriety: [{propsprist[i].Name}]\n" +
               $"Optional Parameters: {propsprist[i]}\n", "Debbugging", ConsoleColor.Yellow
              );
            }

            var propssts = theclass.GetProperties(BindingFlags.Public | BindingFlags.Static);
            for (int i = 0; i < propssts.Length; i++)
            {
                NocturnalC.Log($"Public Static Proopriety: [{propssts[i].Name}]\n" +
               $"Optional Parameters: {propssts[i]}\n", "Debbugging", ConsoleColor.Yellow
              );
            }
            var propsprists = theclass.GetProperties(BindingFlags.NonPublic | BindingFlags.Static);
            for (int i = 0; i < propsprists.Length; i++)
            {
                NocturnalC.Log($"nonpublic Static Proopriety: [{propsprists[i].Name}]\n" +
               $"Optional Parameters: {propsprists[i]}\n", "Debbugging", ConsoleColor.Yellow
              );
            }


        }

        internal static IEnumerator loadaudio(AudioSource auds,string path)
        {
            var www = UnityWebRequest.Get("File://" + path);
            www.SendWebRequest();

            while (!www.isDone)
                yield return null;
            if (www.isHttpError)
                yield break;
            var audioc = WebRequestWWW.InternalCreateAudioClipUsingDH(www.downloadHandler, www.url, false, false,
                AudioType.MPEG);
            audioc.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            auds.clip = audioc;
        }

        internal static bool IsFriend(this VRC.Player player) => APIUser.CurrentUser.friendIDs.Contains(player.field_Private_APIUser_0.id);

        internal static void setconfigfieldvalue(string field, object value)
        {
            typeof(Settings.ConfigVars).GetField(field, BindingFlags.Public | System.Reflection.BindingFlags.Static).SetValue(null, value);
        }

        internal static VRC.Player[] getallplayers() => PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray();

        internal static VRC.Player GetPNewtworkid(this int id) => getallplayers().Where(player => player._vrcplayer.field_Private_VRCPlayerApi_0.playerId == id).FirstOrDefault();

     internal static VRC.Player getuserbyid(this string userid) =>  PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray().Where(player => player.field_Private_APIUser_0.id == userid).FirstOrDefault();

        internal static void clientmessage(string info)
        {
            Ui.Bundles.clientmessage.transform.Find("animator/main/text").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = info;
            Ui.Bundles.clientmessage.SetActive(false);
            Ui.Bundles.clientmessage.gameObject.SetActive(true);
        }
        internal static IEnumerator clientmessagewaiter(string info)
        {
            while (VRC.SDKBase.Networking.LocalPlayer == null)
                yield return null;

            while (VRC.SDKBase.Networking.LocalPlayer.gameObject == null)
                yield return null;

            Ui.Bundles.clientmessage.transform.Find("animator/main/text").gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = info;
            Ui.Bundles.clientmessage.SetActive(false);
            Ui.Bundles.clientmessage.gameObject.SetActive(true);
            yield return null;
        }

    }


}
