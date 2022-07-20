using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Settings.wrappers;
using Newtonsoft.Json;
using System.IO;

namespace Nocturnal.server
{
    internal class PartyManager
    {
        private static List<PartyJson.user> s_partyMembers = new List<PartyJson.user>();
        private static List<string> s_partyLeaders = new List<string>();
        private static bool s_isInParty = false;
        private static bool s_isPartyLeader = false;
        private static int s_count = 0;

        internal static TMPro.TextMeshProUGUI s_text { get; set; }
        internal static string s_partyId { get; set; } = "None";

        internal static void OnPartyCreate()
        {
            s_isPartyLeader = true;
            s_isInParty = true;
            setup.sendmessage(JsonConvert.SerializeObject(
                new server.PartyJson.SendLeaderReq()
                {
                    code = "105",
                    Key = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,
                    StringObject = VRC.Player.prop_Player_0.field_Private_APIUser_0.displayName,
                }));
            OnJoin(VRC.Player.prop_Player_0.field_Private_APIUser_0.displayName,VRC.Player.prop_Player_0.field_Private_APIUser_0.id );
            s_partyLeaders.Add(VRC.Player.prop_Player_0.field_Private_APIUser_0.id);
            s_text.gameObject.SetActive(true);
        }

        internal static void OnPartyDelete()
        {
            s_isPartyLeader = false;
            s_isInParty = false;
            s_partyId = "None";
            s_partyMembers.Clear();
            s_partyLeaders.Clear();
            s_text.gameObject.SetActive(false);
            s_text.text = "";
            s_count = 0;
            Settings.XRefedMethods.PopOutWarrningMessage("Party", "You've left the party");
        }

        internal static void SendLeaveParty()
        {
            setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.user()
            {
                code = "110",
                PartyId = s_partyId,
            }));
        }

        internal static void SendDeleteParty()
        {
            setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.SendLeaderReq()
            {
                code = "109",
                Key = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,
            }));
        }

        internal static void OnJoin(string name, string userId)
        {
            s_partyMembers.Add(new PartyJson.user() { Name = name, Id = userId });
            s_count++;
            if (s_count % 5 == 0)
            {
                s_text.text += "\n<color=#ffff00>" + name + "</color>";
                return;
            }
            s_text.text += " <color=white>||</color> <color=#ffff00>" + name + "</color>";
        }
        internal static void OnJoin(PartyJson.user[] users, string[] Leaders)
        {
            for (int i = 0; i < users.Length; i++)
                OnJoin(users[i].Name, users[i].Id);
            s_partyLeaders = Leaders.ToList();       
        }


        internal static void OnLeave(string userId)
        {
            s_count--;
            var user = s_partyMembers.Where(x => x.Id == userId).FirstOrDefault();
            for (int i = 0; i < s_partyLeaders.Count; i++)
                if (s_partyLeaders[i] == userId) s_partyLeaders.Remove(userId);
            s_partyMembers.Remove(user);
            try {s_text.text = s_text.text.Replace(" <color=white>||</color> <color=#ffff00>" + user.Name + "</color>", ""); }catch { }
            try { s_text.text = s_text.text.Replace("\n<color=#ffff00>" + user.Name + "</color>", ""); } catch { }
        }

        internal static void OnRequest(string userName, List<PartyJson.user> members, List<string> leaders,string UserId)
        {
            if (s_isInParty)
            {
                setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.SendUserReq()
                {
                    code = "108",
                    Id = UserId,
                    StringObject = VRC.Player.prop_Player_0.field_Private_APIUser_0.displayName + " Is Already In A party",
                }));
                return;
            }

            Settings.XRefedMethods.PopOutToggle($"Party ({userName})", "You Have been invited to a party by " + userName, () => {
                for (int i = 0; i < members.Count; i++)
                    OnJoin(members[i].Name, members[i].Id);

                for (int i = 0; i < leaders.Count; i++)
                    OnLeaderAdd(leaders[i]);

                s_isInParty = true;
                setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.SendUserReq()
                {
                    code = "109",
                    Id = VRC.Player.prop_Player_0.field_Private_APIUser_0.id,
                    StringObject = VRC.Player.prop_Player_0.field_Private_APIUser_0.displayName,
                }));

            });
        }

        internal static void OnLeaderAdd(string userId)
        {
            if (userId == VRC.Player.prop_Player_0.field_Private_APIUser_0.id)
            {
                s_isPartyLeader = true;
                Settings.XRefedMethods.PopOutWarrningMessage("Party", "You've been promoted to Leader on the lobby");
            }
            s_partyLeaders.Add(userId);
        }

        internal static void OnPlayerKick(string userId)
        {
            OnLeave(userId);

        }

        internal static void OnTeleportRequest(string userId)
        {
            if (!CheckLeader(userId)) return;
            VRC.Player.prop_Player_0.transform.localPosition = extensions.GetUserById(userId).transform.localPosition;
        }
        internal static void OnWorldSwtichRequest(string userId, string worldId)
        {
            if (!CheckLeader(userId)) return;
            if (RoomManager.prop_String_0 == worldId) return;
            VRC.SDKBase.Networking.GoToRoom(worldId);
        }

        internal static void SendTeleportEvent()
        {
            if (!s_isPartyLeader) return;
            setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.SendLeaderReq() { code = "111",
                Key = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,
                PartyId = s_partyId,
            }));

        }
        internal static void SendSwitchWorldRequest()
        {
            if (!s_isPartyLeader) return;
            setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.SendLeaderReq()
            {
                code = "112",
                Key = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,
                StringObject = RoomManager.prop_String_0,
                PartyId = s_partyId,
            }));

        }

        internal static void SendInvite(string userId)
        {
            if (!s_isPartyLeader) return;
            setup.sendmessage(JsonConvert.SerializeObject(
            new PartyJson.SendInite()
            {
                code = "106",
                Id = userId,
                Name = VRC.Player.prop_Player_0.field_Private_APIUser_0.displayName,
                PartyId = s_partyId


            })) ;
        }

        internal static void SendKick(string userId)
        {
            if (!s_isPartyLeader) return;
            setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.SendLeaderReq()
            {
                code = "1142",
                Key = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,
                StringObject = userId
            }));
        }

        private static bool CheckLeader(string userId)
        {
            for (int i = 0; i < s_partyLeaders.Count; i++)
                if (s_partyLeaders[i] == userId) return true;

            return false;
        }

        internal static void GenerateList()
        {
            GameObject obj = GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)").transform.Find("Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickLinks/LeftItemContainer/Text_Title").gameObject;
            s_text = GameObject.Instantiate(obj, GameObject.Find("/UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window").transform).GetComponent<TMPro.TextMeshProUGUI>();
            s_text.alignment = TMPro.TextAlignmentOptions.TopLeft;
            s_text.text = "";
            s_text.transform.localScale = new Vector3(0.85f, 1, 1);
            s_text.transform.localPosition = new Vector3(-512, -750, 0);
            s_text.gameObject.SetActive(false);
            s_text.enableWordWrapping = false;
            s_text.richText = true;
        }

    }
}
