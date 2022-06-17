using ExitGames.Client.Photon;
using MelonLoader;
using Nocturnal.Exploits;
using Nocturnal.Settings.wrappers;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using UnhollowerBaseLib;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.Networking;
using VRC.SDKBase;

namespace Nocturnal.Settings
{
    internal class Hooks
    {
        internal static string typeofworld = "";
        internal static int fakelagnumb = 0;
        internal static int fakevcnumb = 0;
        internal static bool fakelag = false;
        internal static bool udonnamespoof = false;
        internal static bool PickupMover = false;

        internal static GameObject _Pickup { get; set; }

        internal static Camera cameraeye; 

        private delegate IntPtr UserJ(IntPtr _instance, IntPtr user, IntPtr _nativeMethodInfoPtr);

        private static UserJ _User;

        private delegate IntPtr UserL(IntPtr _instance, IntPtr user, IntPtr _nativeMethodInfoPtr);

        private static UserL _user;



        private delegate IntPtr WorldJoin(IntPtr _instance, IntPtr Apiworld, IntPtr _nativeMethodInfoPtr);

        private static WorldJoin _Worldjoin;

        private delegate IntPtr avatarchanged(IntPtr _instance, IntPtr gmj, IntPtr avatardescriptor, bool boleanv, IntPtr _nativeMethodInfoPtr);

        private static avatarchanged _avatarchanged;

        private delegate IntPtr onevent(IntPtr _instance, IntPtr eventData, IntPtr _nativeMethodInfoPtr);

        private static onevent _onevent;

        private delegate IntPtr globaludon(IntPtr _instance, IntPtr eventname, IntPtr player, IntPtr _nativeMethodInfoPtr);

        private static globaludon _globaludon;

        private delegate IntPtr opraiseevent(IntPtr _instance, byte eventcode, IntPtr il2object, IntPtr raiseoption, IntPtr _nativeMethodInfoPtr);

        private static opraiseevent _opraiseevent;

        private delegate IntPtr apiuserpage(IntPtr _instance, IntPtr apiuseri, IntPtr _nativeMethodInfoPtr);

        private static apiuserpage _apiuserpage;

        private delegate IntPtr dispalyname(IntPtr _instance, IntPtr name, IntPtr _nativeMethodInfoPtr);

        private static dispalyname _dispalyname;

        private delegate IntPtr hwid(IntPtr _instance, IntPtr _nativeMethodInfoPtr);

        private static hwid _hwid;

        private delegate IntPtr PickupObject(IntPtr _instance, VRC_Trigger.TriggerType rigidbody ,IntPtr _nativeMethodInfoPtr);

        private static PickupObject _PickupObject;


        private static unsafe TDelegate Hook<TDelegate>(MethodInfo targetMethod, MethodInfo patch) where TDelegate : Delegate
        {


            try
            {
                var method = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(targetMethod).GetValue(null);
                MelonLoader.MelonUtils.NativeHookAttach((IntPtr)(&method), patch!.MethodHandle.GetFunctionPointer());
                return Marshal.GetDelegateForFunctionPointer<TDelegate>(method);
            }
            finally
            {
                NocturnalC.Log("Hooked: " + targetMethod.Name,"Hooks",ConsoleColor.Green);
            }
       

        }

        private static unsafe TDelegate DetachHook<TDelegate>(MethodInfo targetMethod, MethodInfo patch) where TDelegate : Delegate
        {


            try
            {
                var method = *(IntPtr*)(IntPtr)UnhollowerUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(targetMethod).GetValue(null);
                MelonLoader.MelonUtils.NativeHookDetach((IntPtr)(&method), patch!.MethodHandle.GetFunctionPointer());
                return Marshal.GetDelegateForFunctionPointer<TDelegate>(method);
            }
            finally
            {
                NocturnalC.Log("UnHooked: " + targetMethod.Name, "Hooks", ConsoleColor.Green);
            }


        }



        private static unsafe TDelegate Hook<TDelegate>(IntPtr pointer, MethodInfo patch) where TDelegate : Delegate
        {
            try
            {
                MelonLoader.MelonUtils.NativeHookAttach((IntPtr)(void*)(&pointer), patch!.MethodHandle.GetFunctionPointer());
                return Marshal.GetDelegateForFunctionPointer<TDelegate>(pointer);
            }
            finally
            {
            }
         

        }
        //ForegroundColor
        private static IntPtr hwidspoofed;
        internal static void StartHooks()
        {

            //"Harmony = No Bithces"
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------");
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

             MethodInfo onwowlrdjoin = typeof(RoomManager).GetMethod(nameof(RoomManager.Method_Public_Static_Boolean_ApiWorld_ApiWorldInstance_String_Int32_0));
            _Worldjoin = Hook<WorldJoin>(onwowlrdjoin, typeof(Hooks).GetMethod(nameof(_WorldJoin), BindingFlags.Static | BindingFlags.NonPublic));

            MethodInfo onevent = typeof(Photon.Realtime.LoadBalancingClient).GetMethod("OnEvent");
            _onevent = Hook<onevent>(onevent, typeof(Hooks).GetMethod(nameof(oneventm), BindingFlags.Static | BindingFlags.NonPublic));

            MethodInfo udonevent = typeof(UdonSync).GetMethod("UdonSyncRunProgramAsRPC");
            _globaludon = Hook<globaludon>(udonevent, typeof(Hooks).GetMethod(nameof(udonsyncedevents), BindingFlags.Static | BindingFlags.NonPublic));

            MethodInfo raiseev = typeof(LoadBalancingClient).GetMethod(nameof(LoadBalancingClient.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0));
            _opraiseevent = Hook<opraiseevent>(raiseev, typeof(Hooks).GetMethod(nameof(RaiseEvent), BindingFlags.Static | BindingFlags.NonPublic));

            MethodInfo apiuserpage = typeof(VRC.UI.PageUserInfo).GetMethod(nameof(VRC.UI.PageUserInfo.Method_Private_Void_APIUser_0), BindingFlags.Public | BindingFlags.Instance);
            _apiuserpage = Hook<apiuserpage>(apiuserpage, typeof(Hooks).GetMethod(nameof(onpageapiuser), BindingFlags.Static | BindingFlags.NonPublic));

            MethodInfo Handgasper = typeof(VRCHandGrasper).GetMethod(nameof(VRCHandGrasper.Method_Private_Void_TriggerType_0));
            _PickupObject = Hook<PickupObject>(Handgasper, typeof(Hooks).GetMethod(nameof(PickupsM), BindingFlags.Static | BindingFlags.NonPublic));

            try
            {
                MethodInfo displaymethod = typeof(APIUser).GetProperty(nameof(APIUser.displayName)).SetMethod;
                _dispalyname = Hook<dispalyname>(displaymethod, typeof(Hooks).GetMethod(nameof(DisplayNameM), BindingFlags.Static | BindingFlags.NonPublic));
            }
            catch (Exception ex) { NocturnalC.Log(ex, "HOOKS ERROR", ConsoleColor.Red); }

            Console.WriteLine();

            if (ConfigVars.HwidSpoof)
            {
                hwidspoofed = ((Il2CppSystem.String)ConfigVars.SpoofedHWID).Pointer;
                NocturnalC.Log("Current Hwid: " + SystemInfo.deviceUniqueIdentifier, "Hooks", ConsoleColor.Red);
                NocturnalC.Log("Spofed Hwid: " + new Il2CppSystem.String(hwidspoofed), "Hooks", ConsoleColor.Green);
                _hwid = Hook<hwid>(IL2CPP.il2cpp_resolve_icall("UnityEngine.SystemInfo::GetDeviceUniqueIdentifier"), typeof(Hooks).GetMethod(nameof(Spoofer), BindingFlags.Static | BindingFlags.NonPublic));
                NocturnalC.Log("If U Want To Change the HWID u have 2 buttons, one in QM and one In Log in Window", "Hooks", ConsoleColor.Green);
            }
            else
                NocturnalC.Log("WARRNING: HWID Spoof Is OFF If u use other mods to spoof I recomand it to keep it off if u don't use other mods i recommand to tur it on", "Hooks", ConsoleColor.Yellow);

            NocturnalC.Log($"Hooks Attached in {hooktimer.Elapsed.ToString("hh\\:mm\\:ss\\.ff")} ", "Hooks", ConsoleColor.Green);
            hooktimer.Stop();
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine();

        }
        private static IntPtr PickupsM(IntPtr _Instance, VRC_Trigger.TriggerType _Rigibody, IntPtr _nativemethodinfo)
        {

            if (!PickupMover)
                return _PickupObject(_Instance, _Rigibody, _nativemethodinfo);

            if (_Rigibody.ToString() == "OnPickup")
            {
                VRCHandGrasper HandGasper = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRCHandGrasper>(_Instance);
                _Pickup = HandGasper.field_Private_Rigidbody_0.gameObject;
                Ui.Inject_monos._ItemMover.SetActive(true);
                Ui.Inject_monos._UpdateManager.SetActive(false);
            }

            return _PickupObject(_Instance, _Rigibody, _nativemethodinfo);
        }
        private static IntPtr Spoofer()
        {
            return hwidspoofed;
        }
        private static void donothing(object str) => str.ToString();

        private static IntPtr DisplayNameM(IntPtr _instance, IntPtr name, IntPtr _nativeMethodInfoPtr)
        {

            if (!udonnamespoof)
                return _dispalyname(_instance, name, _nativeMethodInfoPtr);
            try
            {
                donothing((string)new Il2CppSystem.String(name));
            }
            catch { return _dispalyname(_instance, name, _nativeMethodInfoPtr); }

            var usr = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<APIUser>(_instance);


            if (APIUser.CurrentUser == null)
                return _dispalyname(_instance, name, _nativeMethodInfoPtr);

            if (usr.id != APIUser.CurrentUser.id)
                return _dispalyname(_instance, name, _nativeMethodInfoPtr);


            if (ConfigVars.onlywauthornamespoof)
            {
                try
                {
                    return _dispalyname(_instance, ((Il2CppSystem.String)RoomManager.field_Internal_Static_ApiWorld_0.authorName).Pointer, _nativeMethodInfoPtr);
                }
                catch
                {
                    return _dispalyname(_instance, name, _nativeMethodInfoPtr);
                }
            }
            return _dispalyname(_instance, ((Il2CppSystem.String)ConfigVars.Customanmespoof).Pointer, _nativeMethodInfoPtr);
        }



        private static IntPtr onpageapiuser(IntPtr _instance, IntPtr apiuseri, IntPtr _nativeMethodInfoPtr)
        {
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


        private static IntPtr RaiseEvent(IntPtr _instance, byte code, IntPtr il2obj, IntPtr sendoptions, IntPtr _nativeMethodInfoPtr)
        {
            var isteruned = true;
            if (fakelag)
            {
                if (code == 7)
                {
                    if (fakelagnumb >= 5)
                    {
                        isteruned = true;
                        fakelagnumb = 0;
                    }
                    else
                    {
                        isteruned = false;
                        fakelagnumb += 1;

                    }
                }
                if (code == 1)
                {
                    if (fakevcnumb >= 2)
                    {
                        isteruned = true;
                        fakevcnumb = 0;
                    }
                    else
                    {
                        isteruned = false;
                        fakevcnumb += 1;

                    }
                }

            }
            // NocturnalC.Log(code);
            if (Ui.qm.Main._stopev7 && code == 7)
                return IntPtr.Zero;

            /*
            var obj = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<Il2CppSystem.Object>(il2obj);


            if (code == 202)
            {
                 NocturnalC.Log("/////////////////////////////////////////////////////////////////////////////////// " + code.ToString());

                    var bytes = photon_extentions.ToByteArray(obj);
                    var bytesl = "";
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        bytesl += " " + bytes[i].ToString();
                    }
                    NocturnalC.Log(bytesl);
                
            }*/


            if (isteruned)
                return _opraiseevent(_instance, code, il2obj, sendoptions, _nativeMethodInfoPtr);
            else
                return IntPtr.Zero;
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
 


        private static IntPtr oneventm(IntPtr _instance, IntPtr eventData, IntPtr _nativeMethodInfoPtr)
        {

            try
            {
                var data = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<EventData>(eventData);
                // NocturnalC.Log(data.Code);
                if (data.Code == 35 || data.Code == 210)
                    return _onevent(_instance, eventData, _nativeMethodInfoPtr);

                if (data.CustomData == null)
                    return _onevent(_instance, eventData, _nativeMethodInfoPtr);

                var bytes = data.CustomData.Cast<UnhollowerBaseLib.Il2CppArrayBase<byte>>().ToArray();



                if (bytes.Length < 10)
                    return IntPtr.Zero;




                // NocturnalC.Log($"{Target.targertuser._vrcplayer.field_Private_VRCPlayerApi_0.playerId}   {data.Sender}");

                if (data.Code == 1 && Ui.qm.Target._copyivoice && Target.targertuser != null && Target.targertuser._vrcplayer.field_Private_VRCPlayerApi_0.playerId == data.Sender)
                    data.Sender.OpRaiseEvent(1, new RaiseEventOptions() { field_Public_EventCaching_0 = EventCaching.DoNotCache, field_Public_ReceiverGroup_0 = ReceiverGroup.Others }, sendOptions: default);

                if (data.Code == 7 && Ui.qm.Target._copyik && Target.targertuser != null && Target.targertuser._vrcplayer.field_Private_VRCPlayerApi_0.playerId == data.Sender)
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

                var antic = new Anticrash(avi, user);
                return _avatarchanged(_instance, gmj, avatardescriptor, boleanv, _nativeMethodInfoPtr);
            }
            catch (Exception ex)
            {
                // NocturnalC.Log(ex);
                return _avatarchanged(_instance, gmj, avatardescriptor, boleanv, _nativeMethodInfoPtr);
            }


        }
        private static IntPtr _Pickupss(IntPtr _instance, bool value, IntPtr _nativeMethodInfoPtr)
        {

            return IntPtr.Zero;
        }

        private static IntPtr _WorldJoin(IntPtr _instance, IntPtr Apiworld, IntPtr _nativeMethodInfoPtr)
        {
            MelonCoroutines.Start(waitforworldtoinitialize());
            return _Worldjoin(_instance, Apiworld, _nativeMethodInfoPtr);
        }

        private static string _Userid { get; set; }
        private static APIUser _Apiuser { get; set; }
        private static VRC.Player _VRCPlayer { get; set; }

        private static jsonmanager.user _UserPlates { get; set; }

        private static string Tags { get; set; }
        private static string Tags2 { get; set; }
        private static GameObject AnimatedTag { get; set; }

        private static IntPtr _userjoined(IntPtr _instance, IntPtr user, IntPtr _nativeMethodInfoPtr)
        {

            _VRCPlayer = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Player>(user);
            _Userid = _VRCPlayer.field_Private_APIUser_0.id;
            _Apiuser = _VRCPlayer.field_Private_APIUser_0;
            var senduser = new Settings.jsonmanager.custommsg()
            {
                code = "2",
                msg = _Userid,
            };
            try
            {
                server.setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(senduser));

            }
            catch { }
            if (_Userid != APIUser.CurrentUser.id)
                _VRCPlayer.gameObject.gameObject.AddComponent<Monobehaviours.Outline>();
            string rank = "";
            var color = UnityEngine.Color.white;
            var username = _Apiuser.displayName;
            Settings.wrappers.Ranks.gettrsutrank(_Apiuser, ref rank, ref color);
            Settings.wrappers.Ranks.convertotcolorank(ref rank, ref username);
            if (_Apiuser.IsOnMobile)
            {
                Style.Debbuger.Debugermsg($"[{username}]<color=#47c2ff> Joined On </color><color=#048743>Quest");
                   Apis.Onscreenui.showmsg($"[{username}]<color=#47c2ff> Joined On </color><color=#048743>Quest");
            }
            else
            {
                Style.Debbuger.Debugermsg($"[{username}]<color=#47c2ff> Joined On </color><color=#0d0099>Pc");
                    Apis.Onscreenui.showmsg($"[{username}]<color=#47c2ff> Joined On </color><color=#0d0099>Pc");
            }

            _VRCPlayer.gameObject.AddComponent<Monobehaviours.Platemanager>();
            if (Settings.ConfigVars.joinnotif)
            {
                Ui.Bundles.joinot.transform.Find("animator/main").GetComponent<UnityEngine.UI.Image>().color = Color.green;
                var text = Ui.Bundles.joinot.transform.Find("animator/main/text").GetComponent<TMPro.TextMeshProUGUI>();
                text.color = color;
                text.text = _Apiuser.displayName;
                Ui.Bundles.joinot.SetActive(false);
                Ui.Bundles.joinot.SetActive(true);
            }



            if (ConfigVars.onlyfriendjoin)
            {
                if (_VRCPlayer.IsFriend())
                    Ui.Qm_basic._audiosourcenotification.Play();

            }
            else if (ConfigVars.joinsound)
                Ui.Qm_basic._audiosourcenotification.Play();

            if (ConfigVars.hidequests && _Apiuser.last_platform != "standalonewindows" && !_VRCPlayer.IsFriend())
            {
                _VRCPlayer.gameObject.SetActive(false);
                Style.Debbuger.Debugermsg($"<color=#610000>[{username} Quest Hidden");
            }
            if (_Apiuser.hasModerationPowers || _Apiuser.hasSuperPowers)
            {
                Style.Debbuger.Debugermsg($"<color=#red>MODERATOR IN LOBBY {username}");
                Settings.wrappers.extensions.clientmessage($"<color=#red>MODERATOR IN LOBBY {username}");
            }
            try
            {
                string vr = _VRCPlayer.prop_VRCPlayerApi_0.IsUserInVR() ? "<color=#c1a8ff>VR</color>" : "<color=#ff0000>No VR</color>";
                string platform = _Apiuser.last_platform != "standalonewindows" ? "<color=#7dffaa>Quest</color>" : "<color=#7d88ff>PC</color>";
                string friends = _VRCPlayer.IsFriend() ? "[<color=yellow>Friend</color>] " : "";
                new Apis.qm.TextButton(Ui.Qm_basic._playerlistmenu, $"{friends}[{platform}] [{vr}] [{username}]", _Userid, _VRCPlayer);
            }
            catch { }
            Ui.Qm_basic.playercounter.text = $"<color=#eae3ff>Players In Lobby</color> <color=#774aff>{PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.Count}</color><color=#eae3ff>/</color><color=#774aff>{RoomManager.field_Internal_Static_ApiWorld_0.capacity}";


            try
            {
                var Dictionary = new Dictionary<string, string>();
                Dictionary.Add("x-userid", _Userid);
                Tags = wrappers.extensions.SendGetRequest("https://napi.nocturnal-client.xyz/PremiumTags", Dictionary);
                if (Tags != "None")
                {
                    _UserPlates = Newtonsoft.Json.JsonConvert.DeserializeObject<jsonmanager.user>(Tags);
                    for (int i = 0; i < _UserPlates.tags.Length; i++)
                    {
                        if (_UserPlates.tags[i].StartsWith("#animatedtag#"))
                        {
                            AnimatedTag = _VRCPlayer.GeneratePlate(_UserPlates.tags[i].Replace("#animatedtag#",""), Settings.Download_Files.imagehandler.PremiumIcon);
                            AnimatedTag.AddComponent<Monobehaviours.TagAnimation>()._Text = _UserPlates.tags[i].Replace("#animatedtag#", "");
                            continue;
                        }
                        _VRCPlayer.GeneratePlate(_UserPlates.tags[i], Settings.Download_Files.imagehandler.PremiumIcon);
                    }
                }

                Tags2 = wrappers.extensions.SendGetRequest("https://napi.nocturnal-client.xyz/CustomTags", Dictionary);
                if (Tags2 != "None")
                {
                    _UserPlates = Newtonsoft.Json.JsonConvert.DeserializeObject<jsonmanager.user>(Tags2);
                    for (int i = 0; i < _UserPlates.tags.Length; i++)
                        _VRCPlayer.GeneratePlate(_UserPlates.tags[i]);
                }


            }
            catch(Exception ex){ NocturnalC.Log(ex); }


            return _User(_instance, user, _nativeMethodInfoPtr);
        }

        private static IntPtr _userleft(IntPtr _instance, IntPtr user, IntPtr _nativeMethodInfoPtr)
        {
            VRC.Player vrcplayer = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Player>(user);

            string displayname = vrcplayer.field_Private_APIUser_0.displayName;
            try
            {
                Style.Debbuger.Debugermsg($"<color=#610000>[{displayname}] Left");

                if (Settings.ConfigVars.joinnotif)
                {
                    Ui.Bundles.joinot.transform.Find("animator/main").GetComponent<UnityEngine.UI.Image>().color = Color.red;
                    var text = Ui.Bundles.joinot.transform.Find("animator/main/text").GetComponent<TMPro.TextMeshProUGUI>();
                    text.color = Color.red;
                    text.text = displayname;
                    Ui.Bundles.joinot.SetActive(false);
                    Ui.Bundles.joinot.SetActive(true);
                }

                
                Apis.Onscreenui.showmsg($"<color=#610000>[{displayname}] Left");

            }
            catch(Exception err) { NocturnalC.Log(err); }

            try
            {
                GameObject.DestroyImmediate(Ui.Qm_basic._playerlistmenu.transform.Find("BTN_" + vrcplayer.field_Private_APIUser_0.id).gameObject);

            }
            catch { }

            try
            {
                Ui.Qm_basic.playercounter.text = $"<color=#eae3ff>Players In Lobby</color> <color=#774aff>{PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.Count}</color><color=#eae3ff>/</color><color=#774aff>{RoomManager.field_Internal_Static_ApiWorld_0.capacity}";

            }
            catch
            {
            }

            return _user(_instance, user, _nativeMethodInfoPtr);
        }
        private static IEnumerator waitforworldtoinitialize()
        {
            while (VRC.SDKBase.Networking.LocalPlayer == null)
                yield return new WaitForEndOfFrame();

            Exploits.Pickups.Pickupsobs = UnityEngine.Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray();

            string name = RoomManager.field_Internal_Static_ApiWorld_0.name;

            Nocturnal.Style.Debbuger.Debugermsg($"<color=yellow>Joined on</color>: " + name);
            Udon.udonbeh = GameObject.FindObjectsOfType<VRC.Udon.UdonBehaviour>();

            if (Settings.ConfigVars.itemmaxrange)
                for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                    Exploits.Pickups.Pickupsobs[i].proximity = 9999;


            if (Settings.ConfigVars.allowitemtheft)
                for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                    Exploits.Pickups.Pickupsobs[i].DisallowTheft = false;

            if (Settings.ConfigVars.itemesp)
                Itemesp.addesptoitems(true);


            if (Settings.ConfigVars.ItemThrowBoost)
                for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                    Exploits.Pickups.Pickupsobs[i].ThrowVelocityBoostScale = Settings.ConfigVars.ItemThrowBoostValue;

            Apis.Onscreenui.showmsg($"<color=yellow>Joined on</color>: " + name);

            typeofworld = RoomManager.field_Internal_Static_ApiWorldInstance_0.type.ToString();

         Download_Files.setworldinfo.Invoke(Download_Files.setworldinfo, new object[] { RoomManager.field_Internal_Static_ApiWorld_0.imageUrl, $"[{name}] [{typeofworld}]" });

            cameraeye = GameObject.Find("/_Application").transform.Find("TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Neck/Camera (head)/Camera (eye)").gameObject.GetComponent<Camera>();

            if (Ui.qm.Worldhistory.worldhistorymenu == null)
                {
                    while (Ui.qm.Worldhistory.worldhistorymenu == null)
                    yield return new WaitForSeconds(1f);

                Ui.qm.Worldhistory.updatehistory(name + ":" + RoomManager.field_Internal_Static_ApiWorldInstance_0.name, RoomManager.field_Internal_Static_ApiWorldInstance_0.id); 
                yield break;
                }
            Ui.qm.Worldhistory.updatehistory(name + ":" + RoomManager.field_Internal_Static_ApiWorldInstance_0.name, RoomManager.field_Internal_Static_ApiWorldInstance_0.id);


            yield break;
        }


            

    }



}
