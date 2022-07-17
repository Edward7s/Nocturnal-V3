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
        private static List<string> s_partyMembers = new List<string>();
        private static List<string> s_partyLeaders = new List<string>();
        private static bool s_isInParty = false;
        private static bool s_isPartyLeader = false;

        internal static void OnPartyCreate()
        {
            s_isPartyLeader = true;
            s_isInParty = true;
        }

        internal static void OnPartyDelete()
        {
            s_isPartyLeader = false;
            s_isInParty = false;
        }

        internal static void OnJoin(string name, string userId)
        {
            s_partyMembers.Add(userId);
        }

         internal static void OnLeave(string userId)
        {
            if (userId == VRC.Player.prop_Player_0.field_Private_APIUser_0.id)
            {
                s_isPartyLeader = false;
                s_isInParty = false;
                s_partyLeaders.Clear();
                s_partyMembers.Clear();
                return;
            }
            s_partyMembers.Remove(userId);
            for (int i = 0; i < s_partyLeaders.Count; i++)
                if (s_partyLeaders[i] == userId) s_partyLeaders.Remove(userId);
        }

        internal static void OnRequest(string userName, List<PartyJson.user> members, List<string> leaders,string UserId)
        {
            if (s_isInParty)
            {
                setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.SendUserReq()
                {
                    Code = "108",
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
                    Code = "109",
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
            VRC.SDKBase.Networking.GoToRoom(worldId);
        }

        internal static void SendTeleportEvent()
        {
            if (!s_isPartyLeader) return;
            setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.SendLeaderReq() {Code = "110",
            Key = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg
            }));

        }
        internal static void SendSwitchWorldRequest()
        {
            if (!s_isPartyLeader) return;
            setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.SendLeaderReq()
            {
                Code = "111",
                Key = JsonConvert.DeserializeObject<Settings.jsonmanager.custommsg2>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\Nocturnal V3\\Config\\LogInfo.erp")).msg,
                StringObject = VRC.Player.prop_Player_0.field_Private_APIUser_0.worldId
            }));

        }

        internal static void SendKick(string userId)
        {
            if (!s_isPartyLeader) return;
            setup.sendmessage(JsonConvert.SerializeObject(new PartyJson.SendLeaderReq()
            {
                Code = "112",
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

    }
}
