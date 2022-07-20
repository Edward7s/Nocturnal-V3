using Nocturnal.Apis.qm;
using Nocturnal.Settings.wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nocturnal.Ui.qm
{
    internal class Party
    {
        private static string s_userId { get; set; }
        internal static void start()
        {
            var Party = submenu.Create("Party", Main.s_mainpage);
            new Submenubutton(Main.s_menuBase.Getmenu(), "Party", Party);

            new NButton(Party.Getmenu(), "Create Party", () => server.PartyManager.OnPartyCreate());
            new NButton(Party.Getmenu(), "Invite To Party", () => Settings.XRefedMethods.PopOutInput("User Id",x => s_userId = x,()=> server.PartyManager.SendInvite(s_userId)));
            new NButton(Party.Getmenu(), "Disband Party", () => server.PartyManager.SendDeleteParty());
            new NButton(Party.Getmenu(), "Leave Party", () => server.PartyManager.SendLeaveParty());
            new NButton(Party.Getmenu(), "Teleport", () => server.PartyManager.SendTeleportEvent());
            new NButton(Party.Getmenu(), "World Hop", () => server.PartyManager.SendSwitchWorldRequest());

        }
    }
}
