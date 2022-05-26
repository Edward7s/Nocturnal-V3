using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UnhollowerBaseLib;
using MelonLoader;
using System.Collections;
using Nocturnal.exploits;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using Nocturnal.Settings.wrappers;
using VRC.SDKBase;
using UnityEngine;
using VRC.Networking;

namespace Nocturnal.Settings
{
    internal class Hooks
    {
        internal static string typeofworld = "";

        private delegate IntPtr UserJ(IntPtr _instance, IntPtr user, IntPtr _nativeMethodInfoPtr);

        private static UserJ _User;

        private delegate IntPtr UserL(IntPtr _instance, IntPtr user, IntPtr _nativeMethodInfoPtr);

        private static UserL _user;

        private delegate IntPtr jumpimp(IntPtr _instance, float jumpimp, IntPtr _nativeMethodInfoPtr);

        private static jumpimp _jumpimp;

        private delegate IntPtr Speed(IntPtr _instance, float Speed, IntPtr _nativeMethodInfoPtr);

        private static Speed _Speed;


        private delegate IntPtr WorldJoin(IntPtr _instance, IntPtr Apiworld, IntPtr _nativeMethodInfoPtr);

        private static WorldJoin _Worldjoin;


        private delegate IntPtr pickups(IntPtr _instance, bool value, IntPtr _nativeMethodInfoPtr);

        private static pickups _pickups;

        private delegate IntPtr avatarchanged(IntPtr _instance, IntPtr gmj, IntPtr avatardescriptor,bool boleanv, IntPtr _nativeMethodInfoPtr);

        private static avatarchanged _avatarchanged;

        private delegate IntPtr onevent(IntPtr _instance, IntPtr eventData, IntPtr _nativeMethodInfoPtr);

        private static onevent _onevent;

        private delegate IntPtr globaludon(IntPtr _instance, IntPtr eventname,IntPtr player , IntPtr _nativeMethodInfoPtr);

        private static globaludon _globaludon;

        private delegate IntPtr opraiseevent(IntPtr _instance,byte eventcode,IntPtr il2object,IntPtr raiseoption, IntPtr _nativeMethodInfoPtr);

        private static opraiseevent _opraiseevent;

        private delegate IntPtr apiuserpage(IntPtr _instance, IntPtr apiuseri, IntPtr _nativeMethodInfoPtr);

        private static apiuserpage _apiuserpage;


        internal static unsafe TDelegate Hook<TDelegate>(MethodInfo targetMethod, MethodInfo patch) where TDelegate : Delegate
        {
            var method = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(targetMethod).GetValue(null);
            MelonLoader.MelonUtils.NativeHookAttach((IntPtr)(&method), patch!.MethodHandle.GetFunctionPointer());
            return Marshal.GetDelegateForFunctionPointer<TDelegate>(method);

        }

        internal static unsafe TDelegate Hook<TDelegate>(IntPtr pointer, MethodInfo patch) where TDelegate : Delegate
        {
            MelonLoader.MelonUtils.NativeHookAttach((IntPtr)(&pointer), patch!.MethodHandle.GetFunctionPointer());
            return Marshal.GetDelegateForFunctionPointer<TDelegate>(pointer);

        }
        //ForegroundColor

        unsafe internal static void StartHooks()
        {
           
            var hooktimer = System.Diagnostics.Stopwatch.StartNew();

            MethodInfo[] methodsinfo = new MethodInfo[2];

            methodsinfo[0] = typeof(NetworkManager).GetMethod("Method_Public_Void_Player_0");
            methodsinfo[1] = typeof(NetworkManager).GetMethod("Method_Public_Void_Player_1");

            for (int i = 0; i < methodsinfo.Length; i++)
            {
                var xrefedmethod = UnhollowerRuntimeLib.XrefScans.XrefScanner.XrefScan(methodsinfo[i]).ToArray();
                for (int i2 = 0; i2 < xrefedmethod.Length; i2++)
                {

                    if (xrefedmethod[i2].Type != UnhollowerRuntimeLib.XrefScans.XrefType.Global) continue;

                    if (xrefedmethod[i2].ReadAsObject().ToString().Contains("OnPlayerJoin"))
                        _User = Hook<UserJ>(methodsinfo[i], typeof(Hooks).GetMethod(nameof(_userjoined), BindingFlags.Static | BindingFlags.NonPublic));
                    else
                        _user = Hook<UserL>(methodsinfo[i], typeof(Hooks).GetMethod(nameof(_userleft), BindingFlags.Static | BindingFlags.NonPublic));

                }
            }


            MethodInfo[] methods = typeof(VRCPlayer).GetMethods().Where(mt => mt.Name.StartsWith("Method_Private_Void_GameObject_VRC_AvatarDescriptor_Boolean_PDM_")).ToArray();
            for (int i = 0; i < methods.Length; i++)
            {
                var xrefedmethods = UnhollowerRuntimeLib.XrefScans.XrefScanner.XrefScan(methods[i]).ToArray();
                for (int i2 = 0; i2 < xrefedmethods.Length; i2++)
                {

                    if (xrefedmethods[i2].Type != UnhollowerRuntimeLib.XrefScans.XrefType.Global) continue;

                    if (xrefedmethods[i2].ReadAsObject().ToString().Contains("Avatar is Ready"))
                    {
                       _avatarchanged = Hook<avatarchanged>(methods[i], typeof(Hooks).GetMethod(nameof(_OnaviChanged), BindingFlags.Static | BindingFlags.NonPublic));
                    }

                }
            }




            /* MethodInfo consolecolor = typeof(System.Console).GetProperty("ForegroundColor").GetSetMethod();
             var methodd = *(IntPtr*)consolecolor.MethodHandle.GetFunctionPointer();
             _consolecolor = Hook<consolecolor>(methodd, typeof(Hooks).GetMethod(nameof(consolecolorm), BindingFlags.Static | BindingFlags.NonPublic));*/
            // Console.ForegroundColor = ConsoleColor.Green;

            MethodInfo jumpimp = typeof(VRC.SDKBase.VRCPlayerApi).GetMethod(nameof(Networking.LocalPlayer.SetJumpImpulse), BindingFlags.Instance |BindingFlags.Public);
            _jumpimp = Hook<jumpimp>(jumpimp, typeof(Hooks).GetMethod(nameof(_Jumpimp), BindingFlags.Static | BindingFlags.NonPublic));


            MethodInfo onwowlrdjoin = typeof(RoomManager).GetMethod("Method_Public_Static_Boolean_ApiWorld_ApiWorldInstance_String_Int32_0");
            _Worldjoin = Hook<WorldJoin>(onwowlrdjoin, typeof(Hooks).GetMethod(nameof(_WorldJoin), BindingFlags.Static | BindingFlags.NonPublic));


            MethodInfo onevent = typeof(Photon.Realtime.LoadBalancingClient).GetMethod("OnEvent");
            _onevent = Hook<onevent>(onevent, typeof(Hooks).GetMethod(nameof(oneventm), BindingFlags.Static | BindingFlags.NonPublic));

            MethodInfo udonevent = typeof(UdonSync).GetMethod("UdonSyncRunProgramAsRPC");
            _globaludon = Hook<globaludon>(udonevent, typeof(Hooks).GetMethod(nameof(udonsyncedevents), BindingFlags.Static | BindingFlags.NonPublic));

           MethodInfo raiseev = typeof(PhotonNetwork).GetMethod(nameof(PhotonNetwork.Method_Public_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0));
          _opraiseevent = Hook<opraiseevent>(raiseev, typeof(Hooks).GetMethod(nameof(RaiseEvent), BindingFlags.Static | BindingFlags.NonPublic));

            MethodInfo apiuserpage = typeof(VRC.UI.PageUserInfo).GetMethod(nameof(VRC.UI.PageUserInfo.Method_Private_Void_APIUser_0), BindingFlags.Public | BindingFlags.Instance);
            _apiuserpage = Hook<apiuserpage>(apiuserpage, typeof(Hooks).GetMethod(nameof(onpageapiuser), BindingFlags.Static | BindingFlags.NonPublic));

            NocturnalC.log($"Hooks Attached in {hooktimer.Elapsed.ToString("hh\\:mm\\:ss\\.ff")} ", "Hooks", ConsoleColor.Green);
            hooktimer.Stop();


        }


        private static IntPtr onpageapiuser(IntPtr _instance, IntPtr apiuseri, IntPtr _nativeMethodInfoPtr)
        {
            NocturnalC.log("1");
            var apiuserinfo = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Core.APIUser>(apiuseri);

            try
            {
                var sendid = new Settings.jsonmanager.custommsg()
                {
                    code = "10",

                    msg = apiuserinfo.id,
                };
                server.setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(sendid));

            }
            catch { };

            return _apiuserpage(_instance, apiuseri, _nativeMethodInfoPtr);
        }


            private static IntPtr RaiseEvent(IntPtr _instance,byte code,IntPtr il2obj,IntPtr sendoptions, IntPtr _nativeMethodInfoPtr)
        {

            // NocturnalC.log(code);
            if (Ui.qm.Main.stopev7 && code == 7)
                return IntPtr.Zero;

            /*
            var obj = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<Il2CppSystem.Object>(il2obj);


            if (code == 202)
            {
                 NocturnalC.log("/////////////////////////////////////////////////////////////////////////////////// " + code.ToString());

                    var bytes = photon_extentions.ToByteArray(obj);
                    var bytesl = "";
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytesl += " " + bytes[i].ToString();
                    }
                    NocturnalC.log(bytesl);
                
            }*/
           
      

            return _opraiseevent(_instance,code,il2obj,sendoptions,_nativeMethodInfoPtr);
        }
       
        private static IntPtr udonsyncedevents(IntPtr _instance, IntPtr eventname, IntPtr player, IntPtr _nativeMethodInfoPtr)
        {


            if (Settings.ConfigVars.udonblock)
                return IntPtr.Zero;

            try
            {
                var udoncomp = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Udon.UdonBehaviour>(_instance);
                var castplayer = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Player>(player);
                var caststring = (string)new Il2CppSystem.String(eventname);



                if (ConfigVars.everyonecontinuesfire && caststring == "SyncDryFire")
                    udoncomp.SendCustomNetworkEvent(0, "SyncFire");


                if (ConfigVars.murdergoldweapon && caststring == "NonPatronSkin" && castplayer.field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id)
                    udoncomp.SendCustomNetworkEvent(0, "PatronSkin");

                if (ConfigVars.everyonegoldgun && caststring == "NonPatronSkin")
                    udoncomp.SendCustomNetworkEvent(0, "PatronSkin");




                if (ConfigVars.continuesfire && caststring == "SyncDryFire" && castplayer.field_Private_APIUser_0.id == VRC.Player.prop_Player_0.field_Private_APIUser_0.id)
                {
                    udoncomp.SendCustomNetworkEvent(0, "SyncFire");
                }

                if (ConfigVars.amongusgodmod)
                {
                    if (caststring == "SyncKill" || caststring == "SyncVotedOut")
                        return IntPtr.Zero;
                }

                if (ConfigVars.murdergodmod && caststring == "SyncKill")
                    return IntPtr.Zero;
            }
            catch { }
          

            return _globaludon(_instance, eventname, player, _nativeMethodInfoPtr);
        }
            private static IntPtr _Speedm(IntPtr _instance, float speed, IntPtr _nativeMethodInfoPtr)
        {
      
            if (!ConfigVars.speed)
                return _Speed(_instance, speed, _nativeMethodInfoPtr);
            var methodinfo = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<MethodInfo>(_nativeMethodInfoPtr);
          NocturnalC.log(methodinfo.Name);
            switch (true)
            {
                case true when methodinfo.Name == "SetRunSpeed":
                    break;
            }

            


            return _Speed(_instance, speed, _nativeMethodInfoPtr);

        }


        private static IntPtr oneventm(IntPtr _instance, IntPtr eventData, IntPtr _nativeMethodInfoPtr)
        {

            try
            {
                var data = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<EventData>(eventData);
                // NocturnalC.log(data.Code);
                if (data.Code == 35 || data.Code == 210)
                    return _onevent(_instance, eventData, _nativeMethodInfoPtr);

                if (data.CustomData == null)
                    return _onevent(_instance, eventData, _nativeMethodInfoPtr);

                var bytes = data.CustomData.Cast<UnhollowerBaseLib.Il2CppArrayBase<byte>>().ToArray();



                if (bytes.Length < 10)
                    return IntPtr.Zero;




                // NocturnalC.log($"{Target.targertuser._vrcplayer.field_Private_VRCPlayerApi_0.playerId}   {data.Sender}");

                if (data.Code == 1 && Ui.qm.Target.copyivoice && Target.targertuser != null && Target.targertuser._vrcplayer.field_Private_VRCPlayerApi_0.playerId == data.Sender)
                    data.Sender.OpRaiseEvent(1, new RaiseEventOptions() { field_Public_EventCaching_0 = EventCaching.DoNotCache , field_Public_ReceiverGroup_0 = ReceiverGroup.Others }, sendOptions: default) ;

                if (data.Code == 7 && Ui.qm.Target.copyik && Target.targertuser != null && Target.targertuser._vrcplayer.field_Private_VRCPlayerApi_0.playerId == data.Sender)
                {
                    int Pid = int.Parse(Networking.LocalPlayer.playerId + "00001");
                    byte[] Pidb = BitConverter.GetBytes(Pid);
                    Buffer.BlockCopy(Pidb, 0, bytes, 0, 4);
                    byte[] VectorData = new Byte[12];

                    Buffer.BlockCopy(BitConverter.GetBytes(VRC.Player.prop_Player_0.transform.localPosition.x), 0, VectorData, 0, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(VRC.Player.prop_Player_0.transform.localPosition.y), 0, VectorData, 4, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(VRC.Player.prop_Player_0.transform.localPosition.z), 0, VectorData, 8, 4);
                    Buffer.BlockCopy(VectorData, 0, bytes, 48, 12);
                    bytes.OpRaiseEvent(7,
                        new Photon.Realtime.RaiseEventOptions()
                        {
                            field_Public_ReceiverGroup_0 = Photon.Realtime.ReceiverGroup.Others,
                            field_Public_EventCaching_0 = Photon.Realtime.EventCaching.DoNotCache,
                        },
                   default);
                    

                }

            }
            catch (Exception e)
            {

            }


            return _onevent(_instance, eventData, _nativeMethodInfoPtr);
        }



        private static IntPtr _OnaviChanged(IntPtr _instance, IntPtr gmj, IntPtr avatardescriptor, bool boleanv, IntPtr _nativeMethodInfoPtr)
        {


            try
            {
                var avi = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRCAvatarManager>(avatardescriptor).transform.parent.gameObject;
                var user = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRCPlayer>(_instance);
                avi.SetActive(false);



                if (!Settings.ConfigVars.selfanti && user == VRC.Player.prop_Player_0._vrcplayer)
                {
                    avi.SetActive(true);
                    return _avatarchanged(_instance, gmj, avatardescriptor, boleanv, _nativeMethodInfoPtr);
                }
                if (Settings.Download_Files.userwhitelist.Contains(user._player.field_Private_APIUser_0.id))
                {
                    avi.SetActive(true);
                    return _avatarchanged(_instance, gmj, avatardescriptor, boleanv, _nativeMethodInfoPtr);


                }

                if (ConfigVars.meshp)
                    if (!anticrash.meshp(user, avi)) return _avatarchanged(_instance, gmj, avatardescriptor, boleanv, _nativeMethodInfoPtr);



                if (ConfigVars.verticiesp)
                    if (!anticrash.verticies(user, avi)) return _avatarchanged(_instance, gmj, avatardescriptor, boleanv, _nativeMethodInfoPtr);


                if (ConfigVars.ShaderP)
                    anticrash.Shaderp(avi);

                if (ConfigVars.linerenderp)
                    anticrash.linerender(user, avi);

                if (ConfigVars.particlep)
                    anticrash.particlesp(user, avi);

                if (ConfigVars.lightsp)
                    anticrash.lights(user, avi);

                if (ConfigVars.audiosourcep)
                    anticrash.audiosourcep(avi);
                avi.SetActive(true);


                return _avatarchanged(_instance, gmj, avatardescriptor, boleanv, _nativeMethodInfoPtr);

            }
            catch (Exception ex)
            {
               // NocturnalC.log(ex);
                return _avatarchanged(_instance, gmj, avatardescriptor, boleanv, _nativeMethodInfoPtr);
            }


        }
        private static IntPtr _Pickupss(IntPtr _instance, bool value, IntPtr _nativeMethodInfoPtr)
        {

            return IntPtr.Zero;
        }

        private static IntPtr _WorldJoin(IntPtr _instance, IntPtr Apiworld, IntPtr _nativeMethodInfoPtr)
        {
            var apiworld = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Core.ApiWorld>(Apiworld);
          
            

            MelonCoroutines.Start(waitforworldtoinitialize());

            return _Worldjoin(_instance, Apiworld, _nativeMethodInfoPtr);
        }

        private static IntPtr _userjoined(IntPtr _instance, IntPtr user, IntPtr _nativeMethodInfoPtr)
        {

              VRC.Player vrcplayer = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Player>(user);
            var senduser = new Settings.jsonmanager.custommsg()
            {
                code = "2",
                msg = vrcplayer.field_Private_APIUser_0.id,
            };
            try
            {
                server.setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(senduser));

            }
            catch { }
            if (vrcplayer.field_Private_APIUser_0.id != VRC.Core.APIUser.CurrentUser.id)
                vrcplayer.gameObject.gameObject.AddComponent<monobehaviours.outline>();
            string rank = "";
            var color = UnityEngine.Color.white;
            var username = vrcplayer.field_Private_APIUser_0.displayName;
            Settings.wrappers.Ranks.gettrsutrank(vrcplayer.field_Private_APIUser_0, ref rank, ref color);
            Settings.wrappers.Ranks.convertotcolorank(ref rank, ref username);
            if (vrcplayer.field_Private_APIUser_0.IsOnMobile)
            {

                Style.Debbuger.debugermsg($"[{username}]<color=#47c2ff> Joined On </color><color=#048743>Quest");
                Apis.onscreenui.showmsg($"[{username}]<color=#47c2ff> Joined On </color><color=#048743>Quest");

            }
            else
            {
                Style.Debbuger.debugermsg($"[{username}]<color=#47c2ff> Joined On </color><color=#0d0099>Pc");

                Apis.onscreenui.showmsg($"[{username}]<color=#47c2ff> Joined On </color><color=#0d0099>Pc");

            }




            vrcplayer.gameObject.AddComponent<monobehaviours.platemanager>();


            Ui.Bundles.joinot.transform.Find("animator/main").GetComponent<UnityEngine.UI.Image>().color = Color.green;
            var text = Ui.Bundles.joinot.transform.Find("animator/main/text").GetComponent<TMPro.TextMeshProUGUI>();
            text.color = color;
            text.text = vrcplayer.field_Private_APIUser_0.displayName;
       
            Ui.Bundles.joinot.SetActive(false);
            Ui.Bundles.joinot.SetActive(true);
    

            if (Settings.ConfigVars.onlyfriendjoin)
            {
                if (vrcplayer.IsFriend())
                    Ui.Qm_basic.audiosourcenotification.Play();

            }
            else if (Settings.ConfigVars.joinsound)
                Ui.Qm_basic.audiosourcenotification.Play();

            if (ConfigVars.hidequests && vrcplayer.prop_APIUser_0.last_platform != "standalonewindows" && !vrcplayer.IsFriend())
            {
                vrcplayer.gameObject.SetActive(false);
                Style.Debbuger.debugermsg($"<color=#610000>[{username} Quest Hidden");

            }
            return _User(_instance, user, _nativeMethodInfoPtr);
        }

        private static IntPtr _userleft(IntPtr _instance, IntPtr user, IntPtr _nativeMethodInfoPtr)
        {
            VRC.Player vrcplayer = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Player>(user);
            Style.Debbuger.debugermsg($"<color=#610000>[{vrcplayer.field_Private_APIUser_0.displayName}] Left");
            Ui.Bundles.joinot.transform.Find("animator/main").GetComponent<UnityEngine.UI.Image>().color = Color.red;
            var text = Ui.Bundles.joinot.transform.Find("animator/main/text").GetComponent<TMPro.TextMeshProUGUI>();
            text.color = Color.red;
            text.text = vrcplayer.field_Private_APIUser_0.displayName;

            Ui.Bundles.joinot.SetActive(false);
            Ui.Bundles.joinot.SetActive(true);
            Apis.onscreenui.showmsg($"<color=#610000>[{vrcplayer.field_Private_APIUser_0.displayName}] Left");

            return _user(_instance, user, _nativeMethodInfoPtr);
        }
        private static IntPtr _Jumpimp(IntPtr _instance, float jumpimp, IntPtr _nativeMethodInfoPtr) =>  _jumpimp(_instance, Settings.ConfigVars.jumpimpulse, _nativeMethodInfoPtr);
        private static IEnumerator waitforworldtoinitialize()
        {
            while (VRC.SDKBase.Networking.LocalPlayer == null)
                yield return null;

            Nocturnal.Style.Debbuger.debugermsg($"<color=yellow>Joined on</color>: [{RoomManager.field_Internal_Static_ApiWorld_0.name}");
            Ui.qm.worldhistory.updatehistory(RoomManager.field_Internal_Static_ApiWorld_0.name + ":" + RoomManager.field_Internal_Static_ApiWorldInstance_0.name, RoomManager.field_Internal_Static_ApiWorldInstance_0.id);
            exploits.pickups.pickupsobs = UnityEngine.Resources.FindObjectsOfTypeAll<VRC.SDKBase.VRC_Pickup>().ToArray();

            if (Settings.ConfigVars.itemmaxrange)
                for (int i = 0; i < exploits.pickups.pickupsobs.Length; i++)
                    exploits.pickups.pickupsobs[i].proximity = 9999;


            if (Settings.ConfigVars.allowitemtheft)
                for (int i = 0; i < exploits.pickups.pickupsobs.Length; i++)
                    exploits.pickups.pickupsobs[i].DisallowTheft = false;

            if (Settings.ConfigVars.itemesp)
                itemesp.addesptoitems(true);

            Apis.onscreenui.showmsg($"<color=yellow>Joined on</color>: [{RoomManager.field_Internal_Static_ApiWorld_0.name}");


            typeofworld = RoomManager.field_Internal_Static_ApiWorldInstance_0.type.ToString();


            Download_Files.setworldinfo.Invoke(Download_Files.setworldinfo, new object[] {RoomManager.field_Internal_Static_ApiWorld_0.imageUrl, $"[{RoomManager.field_Internal_Static_ApiWorld_0.name}] [{typeofworld}]" });
        }

        
    }



}
