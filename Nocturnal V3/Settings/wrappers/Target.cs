using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRC;

namespace Nocturnal.Settings.wrappers
{
    internal class Target
    {
        internal static VRC.Player targertuser;
        private static GameObject targetplate;

        internal static void Targetuser(string userid)
        {
            if (targetplate != null)
                GameObject.DestroyImmediate(targetplate);

            var players = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.ToArray().Where(player => player.field_Private_APIUser_0.id == userid).FirstOrDefault();
            targertuser = players;
           targetplate = players._vrcplayer.GeneratePlate("<color=red>Targeted");
        }
    }
}

