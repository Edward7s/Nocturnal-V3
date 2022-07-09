using ExitGames.Client.Photon;
using MelonLoader;
using Nocturnal.Exploits;
using Nocturnal.Settings.wrappers;
using Photon.Realtime;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnhollowerBaseLib;
using UnityEngine;
using VRC;
using VRC.Core;
using VRC.Networking;
using VRC.SDKBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using VRC.UI;
namespace Nocturnal.Settings
{
    internal class Hooks
    {
        internal static string _TypeOfWorld = "";
        internal static int fakelagnumb = 0;
        internal static int fakevcnumb = 0;
        internal static bool fakelag = false;
        internal static bool udonnamespoof = false;
        internal static bool PickupMover = false;
        internal static int _PlayersInLobby { get; set; }
        internal static bool _IsInVr { get; set; }

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

        private delegate IntPtr PickupObject(IntPtr _instance, VRC_Trigger.TriggerType rigidbody, IntPtr _nativeMethodInfoPtr);

        private static PickupObject _PickupObject;

        private delegate IntPtr PortalSpawner(IntPtr _instance, IntPtr world, IntPtr id, int idk, IntPtr Player, IntPtr _nativeMethodInfoPtr);

        private static PortalSpawner _PortalSpawner;

        private delegate IntPtr WebsockerReciver(IntPtr _instance, IntPtr Object, IntPtr Message);

        private static WebsockerReciver _WebsockerReciver;
        [Obsolete]
        private static Harmony.HarmonyInstance Instance = new Harmony.HarmonyInstance(new Guid().ToString());

        [Obsolete]
        private static unsafe void Patch(MethodInfo TargetMethod, MethodInfo Deteour, bool IsPrefix = false)
        {
            if (IsPrefix)
                Instance.Patch(TargetMethod, Deteour.ToNewHarmonyMethod());
            else
                Instance.Patch(TargetMethod, null, Deteour.ToNewHarmonyMethod());
        }


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
                NocturnalC.Log("Hooked: " + targetMethod.Name, "Hooks", ConsoleColor.Green);
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

        private static void GetReq(string __0, ApiContainer __1)
        {
        }
        [Obsolete]

        internal static void StartHooks()
        {

            //Harmony Patches cause to lazy to put all parameters

            // Patch(typeof(VRC.Core.API).GetMethod(nameof(VRC.Core.API.SendGetRequest)), typeof(Hooks).GetMethod(nameof(GetReq),BindingFlags.NonPublic | BindingFlags.Static ));


            // Settings.wrappers.extensions.GetAllStrings(typeof(Transmtn.WebsocketPipeline));
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

            MethodInfo _PortalSpawnerm = typeof(PortalInternal).GetMethod(nameof(PortalInternal.ConfigurePortal));
            _PortalSpawner = Hook<PortalSpawner>(_PortalSpawnerm, typeof(Hooks).GetMethod(nameof(PortalSpawnerh), BindingFlags.Static | BindingFlags.NonPublic));

            MethodInfo methodsinfo2 = typeof(Transmtn.WebsocketPipeline).GetMethods().Where(m => m.GetParameters().Count() == 2 && m.GetParameters()[0].ParameterType.ToString() == "Il2CppSystem.Object" && m.GetParameters()[1].ParameterType.ToString() == "WebSocketSharp.MessageEventArgs").FirstOrDefault();
            _WebsockerReciver = Hook<WebsockerReciver>(methodsinfo2, typeof(Hooks).GetMethod(nameof(WebSocket), BindingFlags.Static | BindingFlags.NonPublic));

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

        //Thx To Killer for helping me to fix the Websocket hook
        private static string _WorldType { get; set; }
        private static string _WorldNameN { get; set; }
        private static JObject JObject { get; set; }
        private static string _LastId { get; set; }
        private static GameObject _FriendlistM { get; set; }
        private static Transform _TextF { get; set; }
        private static UnityEngine.UI.Text _TextComp { get; set; }
        private static GameObject _TransText { get; set; }

        private static Settings.jsonmanager.Webscoekt _WsMsg { get; set; }
        private static void WebSocket(IntPtr _Instance, IntPtr objects, IntPtr Message)
        {
            _WebsockerReciver(_Instance, objects, Message);

            if (Message == IntPtr.Zero || Message == null) return;
            try
            {
                unsafe
                {
                    nint _Offset = (nint)Message + 0x10;
                    _WsMsg = JsonConvert.DeserializeObject<Settings.jsonmanager.Webscoekt>((string)new Il2CppSystem.String(*(IntPtr*)_Offset));
                    //   NocturnalC.Log(_WsMsg.type);
                    JObject = JObject.FromObject(JObject.Parse(_WsMsg.content));
                    //  NocturnalC.Log(_WsMsg.content);
                    switch (_WsMsg.type)
                    {
                        case "friend-location":
                            if (_LastId == (string)JObject["userId"]) return;
                            JObject = JObject.FromObject(JObject.Parse(_WsMsg.content));
                            _LastId = (string)JObject["userId"];
                            _WorldType = (string)JObject["location"];
                            if (_WorldType == "private")
                                _WorldNameN = "<color=#9c0000>Private Room</color>";
                            else
                                _WorldNameN = "<color=#9f00d9>" + JObject["world"]["name"] + "</color>";
                            Apis.Onscreenui.showmsg($"</color>[<color=#f9ff54>{JObject["user"]["displayName"]}</color>] => " + _WorldNameN);
                            MelonCoroutines.Start(Change());
                            /*    _FriendlistM = Ui.Objects._ContentOnlineFriends.GetComponentsInChildren<VRCUiContentButton>().Where(x => x.field_Public_String_0 == (string)JObject["userId"]).FirstOrDefault().transform.Find("Background/TitleText").gameObject;
                                _TextF = _FriendlistM.transform.parent.transform.Find("Nwrld");
                                if (_TextF == null)
                                {
                                    _TextF = _FriendlistM.transform.Find("Nwrld");

                                    _TextF = GameObject.Instantiate(_FriendlistM, _FriendlistM.transform.parent.transform).transform;
                                    _TextF.transform.localPosition = new Vector3(-42, -47, 0);
                                    _TextF.name = "Nwrld";
                                    _TextComp = _TextF.GetComponent<UnityEngine.UI.Text>();
                                    _TextComp.supportRichText = true;
                                    _TextComp.horizontalOverflow = HorizontalWrapMode.Overflow;
                                    _TextComp.text = _WorldNameN;
                                    _TextComp.fontSize = 19;
                                    _FriendlistM.transform.localPosition = new Vector3(-16, -73, 0);
                                    return;
                                }
                                _TextF.GetComponent<UnityEngine.UI.Text>().text = _WorldNameN; */
                            break;
                        case "friend-offline":
                            Apis.Onscreenui.showmsg($"</color>[<color=#f9ff54>{FriendsListManager.field_Private_Static_FriendsListManager_0.field_Private_List_1_IUser_0.ToArray().Where(k => k.prop_String_0 == (string)JObject["userId"]).FirstOrDefault().prop_String_1}</color>]<color=#f9ff54> => </color><color=#9c0000>Offline");
                            break;
                        case "friend-online":
                            Apis.Onscreenui.showmsg($"</color>[<color=#f9ff54>{JObject["user"]["displayName"]}</color>] => <color=#58e87f>Online");

                            break;
                        case "notification":
                            Apis.Onscreenui.showmsg($"</color>[<color=#f9ff54>{JObject["senderUsername"]}</color>] => <color=#d96038>" + JObject["type"]);
                            break;
                    }

                }//
            }
            catch { }

        }

        private static IEnumerator Change()
        {
            yield return new WaitForSeconds(1f);
            _LastId = "";
            yield break;
        }

        private static VRC.Player _PLayerP { get; set; }
        private static PortalInternal _Portal { get; set; }
        private static void PortalSpawnerh(IntPtr _instance, IntPtr world, IntPtr id, int idk, IntPtr player, IntPtr _nativeMethodInfoPtr)
        {
            _PortalSpawner(_instance, world, id, idk, player, _nativeMethodInfoPtr);
            if (player == IntPtr.Zero) return;

            _PLayerP = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Player>(player);
            if (_PLayerP == VRC.Player.prop_Player_0) return;
            if (ConfigVars.NoPortals)
            {
                try
                {
                    _Portal = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<PortalInternal>(_instance);
                    GameObject.DestroyImmediate(_Portal.gameObject);
                    Apis.Onscreenui.showmsg($"<color=red>Destroyed Portal");
                }
                catch { }
                return;
            }
            if (ConfigVars.OnlyFriendsPortals && !_PLayerP.IsFriend())
            {
                try
                {
                    _Portal = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<PortalInternal>(_instance);
                    GameObject.DestroyImmediate(_Portal.gameObject);
                    Apis.Onscreenui.showmsg($"<color=red>Destroyed Portal");

                }
                catch { }
                return;
            }
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
            /* if (code == 7)
             {
                 try
                 {
                     NocturnalC.Log("///////////////////////////////////////////////////////////////////////////////////");

                     var obj = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<Il2CppSystem.Object>(il2obj);
                     var bytes = photon_extentions.ToByteArray(obj);
                     var bytesl = "";
                     for (int i = 0; i < bytes.Length; i++)
                     {
                         bytesl += " " + bytes[i].ToString();
                     }
                     NocturnalC.Log(bytesl);

                     NocturnalC.Log($"[{VRC.Player.prop_Player_0.transform.position.x} / {VRC.Player.prop_Player_0.transform.position.y} {VRC.Player.prop_Player_0.transform.position.z}  ///  {VRC.Player.prop_Player_0.transform.localEulerAngles.x} / {VRC.Player.prop_Player_0.transform.localEulerAngles.y} {VRC.Player.prop_Player_0.transform.localEulerAngles.z}]");
                 }
                 catch { }

             }*/

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
            if (Ui.qm.Main.s_stopev7 && code == 7)
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








                byte[] bytes = data.CustomData.Cast<UnhollowerBaseLib.Il2CppArrayBase<byte>>().ToArray();

                if (data.CustomData == null)
                    return _onevent(_instance, eventData, _nativeMethodInfoPtr);

                if (bytes.Length < 10)
                    return IntPtr.Zero;


                // NocturnalC.Log($"{Target.targertuser._vrcplayer.field_Private_VRCPlayerApi_0.playerId}   {data.Sender}");
                if (data.Code == 1 && Ui.qm.Target._copyivoice && Target.targertuser != null && Target.targertuser._vrcplayer.field_Private_VRCPlayerApi_0.playerId == data.Sender)
                    data.Sender.OpRaiseEvent(1, new RaiseEventOptions() { field_Public_EventCaching_0 = EventCaching.DoNotCache, field_Public_ReceiverGroup_0 = ReceiverGroup.Others }, sendOptions: default);

                if (data.Code == 7 && Ui.qm.Target._copyik && Target.targertuser != null && Target.targertuser.field_Private_VRCPlayerApi_0.playerId == data.Sender)
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
                _AvatarManager = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRCAvatarManager>(avatardescriptor).transform.parent.gameObject;
                _VRCPLAYER = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRCPlayer>(_instance);
                _AvatarManager.SetActive(false);
                if (!Settings.ConfigVars.selfanti && _VRCPLAYER == VRC.Player.prop_Player_0._vrcplayer)
                {
                    _AvatarManager.SetActive(true);
                    return _avatarchanged(_instance, gmj, avatardescriptor, boleanv, _nativeMethodInfoPtr);
                }
                if (Settings.Download_Files.userwhitelist.Contains(_VRCPLAYER._player.field_Private_APIUser_0.id))
                {
                    _AvatarManager.SetActive(true);
                    return _avatarchanged(_instance, gmj, avatardescriptor, boleanv, _nativeMethodInfoPtr);
                }

                var antic = new Anticrash(_AvatarManager, _VRCPLAYER);
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

        private static Monobehaviours.PlatesUpdator _platesUpdator { get; set; }
        private static GameObject CameraManager { get; set; }
        private static void _userjoined(IntPtr _instance, IntPtr user, IntPtr _nativeMethodInfoPtr)
        {
            _User(_instance, user, _nativeMethodInfoPtr);
            var vrcplayer = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Player>(user);
            _Userid = vrcplayer.field_Private_APIUser_0.id;
            _Apiuser = vrcplayer.field_Private_APIUser_0;
            _SendUser = new Settings.jsonmanager.custommsg()
            {
                code = "2",
                msg = _Userid,
            };
            server.setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(_SendUser));

            if (_Userid != APIUser.CurrentUser.id)
            {
                vrcplayer.gameObject.gameObject.AddComponent<Monobehaviours.Outline>();
                if (ConfigVars.EveryoneTrail)
                    extensions._AddTrailRender(vrcplayer.gameObject);

                CameraManager = new GameObject("UserPovCamera");
                CameraManager.transform.parent = vrcplayer.gameObject.transform.Find("AnimationController/HeadAndHandIK/HeadEffector");
                CameraManager.transform.localPosition = Vector3.zero;
                CameraManager.transform.localScale = Vector3.one;
                CameraManager.transform.localEulerAngles = Vector3.zero;
                CameraManager.AddComponent<UnityEngine.Camera>().farClipPlane = 80;
                CameraManager.SetActive(false);
            }
            _UserName = _Apiuser.displayName;
            Settings.wrappers.Ranks.gettrsutrank(_Apiuser, ref _Rank, ref _Color);
            Settings.wrappers.Ranks.convertotcolorank(ref _Rank, ref _UserName);
            if (_Apiuser.IsOnMobile)
            {
                Style.Debbuger.Debugermsg($"[{_UserName}]<color=#47c2ff> Joined On </color><color=#048743>Quest");
                Apis.Onscreenui.showmsg($"[{_UserName}]<color=#47c2ff> Joined On </color><color=#048743>Quest");
            }
            else
            {
                Style.Debbuger.Debugermsg($"[{_UserName}]<color=#47c2ff> Joined On </color><color=#0d0099>Pc");
                Apis.Onscreenui.showmsg($"[{_UserName}]<color=#47c2ff> Joined On </color><color=#0d0099>Pc");
            }
         
            vrcplayer.gameObject.AddComponent<Monobehaviours.Platemanager>();
            if (Settings.ConfigVars.joinnotif)
            {
                Ui.Bundles.joinot.transform.Find("animator/main").GetComponent<UnityEngine.UI.Image>().color = Color.green;
                TMPro.TextMeshProUGUI text = Ui.Bundles.joinot.transform.Find("animator/main/text").GetComponent<TMPro.TextMeshProUGUI>();
                text.color = _Color;
                text.text = _Apiuser.displayName;
                Ui.Bundles.joinot.SetActive(false);
                Ui.Bundles.joinot.SetActive(true);
            }

            if (ConfigVars.onlyfriendjoin && vrcplayer.IsFriend())
                Ui.Qm_basic._audiosourcenotification.Play();

            else if (ConfigVars.joinsound)
                Ui.Qm_basic._audiosourcenotification.Play();

            if (ConfigVars.hidequests && _Apiuser.last_platform != "standalonewindows" && !vrcplayer.IsFriend())
            {
                vrcplayer.gameObject.SetActive(false);
                Style.Debbuger.Debugermsg($"<color=#610000>[{_UserName} Quest Hidden");
            }
            if (_Apiuser.hasModerationPowers || _Apiuser.hasSuperPowers)
                Settings.XRefedMethods.PopOutWarrningMessage("MODERATOR IN LOBBY [" + _UserName + "]");


            Ui.Qm_basic.playercounter.text = $"<color=#eae3ff>Players In Lobby</color> <color=#774aff>{_PlayersInLobby}</color><color=#eae3ff>/</color><color=#774aff>{_RoomCapacity}";

            if (Settings.ConfigVars.NamePlatesInfo)
            {
                _platesUpdator = vrcplayer.GeneratePlate("Loading").AddComponent<Monobehaviours.PlatesUpdator>();
                _platesUpdator.Player = vrcplayer;
                _platesUpdator._rank = _Rank;
            }
          
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("x-userid", _Userid);
            Task.Run(() => GetPremiumTags(dictionary, vrcplayer));
            Task.Run(() => GetCustomTags(dictionary, vrcplayer));
            _PlayersInLobby = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.Count;
            _VR = vrcplayer.prop_VRCPlayerApi_0.IsUserInVR() ? "<color=#c1a8ff>VR</color>" : "<color=#ff0000>No VR</color>";
            _Platform = _Apiuser.last_platform != "standalonewindows" ? "<color=#7dffaa>Quest</color>" : "<color=#7d88ff>PC</color>";
            _Friends = vrcplayer.IsFriend() ? "[<color=yellow>Friend</color>] " : "";
            new Apis.qm.TextButton(Ui.Qm_basic._playerlistmenu, $"{_Friends}[{_Platform}] [{_VR}] [{_UserName}]", _Userid, vrcplayer);
        }


        private static Task GetPremiumTags(Dictionary<string, string> Headers, VRC.Player _Player)
        {
            var _Req = (HttpWebRequest)WebRequest.Create("https://napi.nocturnal-client.xyz/PremiumTags");
            for (int i = 0; i < Headers.Count; i++)
            {
                var Curent = Headers.ElementAt(i);
                _Req.Headers.Add(Curent.Key, Curent.Value);
            }
            _Req.AutomaticDecompression = DecompressionMethods.GZip;
            using (var res = (HttpWebResponse)_Req.GetResponse())
            using (var stream = res.GetResponseStream())
            using (var Reader = new StreamReader(stream))
            {
                var ReaderValue = Reader.ReadToEnd();
                string g = Guid.NewGuid().ToString();
                Main2._queueDictionary.Add(g,(new Action(() =>
                {
                    Main2._queueDictionary.Remove(g);
                    if (_Player == null)
                        return;
                    if (ReaderValue == "None")
                        return;
                    var _UserPlate = Newtonsoft.Json.JsonConvert.DeserializeObject<jsonmanager.user>(ReaderValue);
                    //      NocturnalC.Log("1" + ReaderValue + "  //    " + _Player.field_Private_APIUser_0.displayName);

                    for (int i = 0; i < _UserPlate.tags.Length; i++)
                    {
                        if (_UserPlate.tags[i].StartsWith("#animatedtag#"))
                        {
                            var AnimatedTag = _Player.GeneratePlate(_UserPlate.tags[i].Replace("#animatedtag#", String.Empty), Settings.Download_Files.imagehandler.PremiumIcon);
                            AnimatedTag.AddComponent<Monobehaviours.TagAnimation>()._Text = _UserPlate.tags[i].Replace("#animatedtag#", "");
                            continue;
                        }
                        _Player.GeneratePlate(_UserPlate.tags[i], Settings.Download_Files.imagehandler.PremiumIcon);
                    }
                })));
                return null;

            }
        }

        private static Task GetCustomTags(Dictionary<string, string> Headers, VRC.Player _Player)
        {
            var _Req = (HttpWebRequest)WebRequest.Create("https://napi.nocturnal-client.xyz/CustomTags");
            for (int i = 0; i < Headers.Count; i++)
            {
                var Curent = Headers.ElementAt(i);
                _Req.Headers.Add(Curent.Key, Curent.Value);
            }
            _Req.AutomaticDecompression = DecompressionMethods.GZip;
            using (var res = (HttpWebResponse)_Req.GetResponse())
            using (var stream = res.GetResponseStream())
            using (var Reader = new StreamReader(stream))
            {
                var stringref = Reader.ReadToEnd();
                string g = Guid.NewGuid().ToString();
                Main2._queueDictionary.Add(g, (new Action(() =>
                {
                    Main2._queueDictionary.Remove(g);

                    if (_Player == null)
                        return;
                    if (stringref == "None")
                        return;

                    //      NocturnalC.Log("2" + stringref + "  //    " + _Player.field_Private_APIUser_0.displayName);

                    var GetPlates = Newtonsoft.Json.JsonConvert.DeserializeObject<jsonmanager.user>(stringref);
                    for (int i = 0; i < GetPlates.tags.Length; i++)
                        _Player.GeneratePlate(GetPlates.tags[i]);
                })));
                return null;
            }
        }





        private static IntPtr _userleft(IntPtr _instance, IntPtr user, IntPtr _nativeMethodInfoPtr)
        {
            _VRCPlayer = UnhollowerSupport.Il2CppObjectPtrToIl2CppObject<VRC.Player>(user);
            try
            {
                GameObject.Destroy(Ui.Qm_basic._playerlistmenu.transform.Find("BTN_" + _VRCPlayer.field_Private_APIUser_0.id).gameObject);
            }
            catch { }
            if (VRC.Player.prop_Player_0 == null) return _user(_instance, user, _nativeMethodInfoPtr);

            _PlayersInLobby = PlayerManager.prop_PlayerManager_0.field_Private_List_1_Player_0.Count;
            Ui.Qm_basic.playercounter.text = $"<color=#eae3ff>Players In Lobby</color> <color=#774aff>{_PlayersInLobby}</color><color=#eae3ff>/</color><color=#774aff>{_RoomCapacity}";

            _UserNameProp = _VRCPlayer.field_Private_APIUser_0.displayName;
            try
            {
                Style.Debbuger.Debugermsg($"<color=#610000>[{_UserNameProp}] Left");

                if (ConfigVars.joinnotif)
                {
                    Ui.Bundles.joinot.transform.Find("animator/main").GetComponent<UnityEngine.UI.Image>().color = Color.red;
                    _NotText = Ui.Bundles.joinot.transform.Find("animator/main/text").GetComponent<TMPro.TextMeshProUGUI>();
                    _NotText.color = Color.red;
                    _NotText.text = _UserNameProp;
                    Ui.Bundles.joinot.SetActive(false);
                    Ui.Bundles.joinot.SetActive(true);
                }
                Apis.Onscreenui.showmsg($"<color=#610000>[{_UserNameProp}] Left");
            }
            catch (Exception err) { NocturnalC.Log(err); }

            return _user(_instance, user, _nativeMethodInfoPtr);
        }



        private static IEnumerator waitforworldtoinitialize()
        {
            while (VRC.SDKBase.Networking.LocalPlayer == null)
                yield return new WaitForEndOfFrame();


            _RoomCapacity = RoomManager.field_Internal_Static_ApiWorld_0.capacity.ToString();

            Exploits.Pickups.Pickupsobs = UnityEngine.Resources.FindObjectsOfTypeAll<VRC_Pickup>().ToArray();

            _WorldName = RoomManager.field_Internal_Static_ApiWorld_0.name;

            Nocturnal.Style.Debbuger.Debugermsg($"<color=yellow>Joined on</color>: " + _WorldName);
            Udon.udonbeh = GameObject.FindObjectsOfType<VRC.Udon.UdonBehaviour>();

            if (Settings.ConfigVars.itemmaxrange)
                for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                    Exploits.Pickups.Pickupsobs[i].proximity = 9999;


            if (Settings.ConfigVars.allowitemtheft)
                for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                    Exploits.Pickups.Pickupsobs[i].DisallowTheft = false;

            if (Settings.ConfigVars.itemesp)
                new Itemesp(true);

            if (Settings.ConfigVars.ItemThrowBoost)
                for (int i = 0; i < Exploits.Pickups.Pickupsobs.Length; i++)
                    Exploits.Pickups.Pickupsobs[i].ThrowVelocityBoostScale = Settings.ConfigVars.ItemThrowBoostValue;
            Apis.Onscreenui.showmsg($"<color=yellow>Joined on</color>: " + _WorldName);

            switch (RoomManager.field_Internal_Static_ApiWorldInstance_0.type.ToString())
            {
                case "Public":
                    _TypeOfWorld = "Public";
                    break;
                case "FriendsOfGuests":
                    _TypeOfWorld = "Friends+";
                    break;
                case "FriendsOnly":
                    _TypeOfWorld = "Friends";
                    break;
                case "InviteOnly":
                    _TypeOfWorld = "Invite";
                    break;
                case "InvitePlust":
                    _TypeOfWorld = "Invite+";
                    break;
            }
          //  Download_Files.setworldinfo.Invoke(Download_Files.setworldinfo, new object[] { RoomManager.field_Internal_Static_ApiWorld_0.imageUrl, $"[{_WorldName}] [{_TypeOfWorld}]" });
            cameraeye = GameObject.Find("Camera (eye)").gameObject.GetComponent<Camera>();

            if (Settings.ConfigVars.SelfTrail)
                Settings.wrappers.extensions._AddTrailRender(VRC.Player.prop_Player_0.gameObject);

            if (!Settings.ConfigVars.hudUi)
                _IsInVr = true;
            else
                _IsInVr = VRC.Player.prop_Player_0.field_Private_VRCPlayerApi_0.IsUserInVR();



            if (Ui.qm.Worldhistory.worldhistorymenu == null)
            {
                while (Ui.qm.Worldhistory.worldhistorymenu == null)
                    yield return new WaitForSeconds(1f);
                Ui.qm.Worldhistory.updatehistory(_WorldName + ":" + RoomManager.field_Internal_Static_ApiWorldInstance_0.name, RoomManager.field_Internal_Static_ApiWorldInstance_0.id);
                yield break;
            }
            Ui.qm.Worldhistory.updatehistory(_WorldName + ":" + RoomManager.field_Internal_Static_ApiWorldInstance_0.name, RoomManager.field_Internal_Static_ApiWorldInstance_0.id);

            yield break;
        }
        private static Dictionary<string, string> _Dictionary { get; set; }
        private static GameObject _AvatarManager { get; set; }
        private static VRCPlayer _VRCPLAYER { get; set; }
        internal static string _RoomCapacity { get; set; }
        private static string _WorldName { get; set; }
        private static TMPro.TextMeshProUGUI _NotText { get; set; }
        private static string _UserNameProp { get; set; }
        private static string _Userid { get; set; }
        private static APIUser _Apiuser { get; set; }
        private static VRC.Player _VRCPlayer { get; set; }
        private static string Tags;
        private static string Tags2;
        private static GameObject AnimatedTag { get; set; }
        private static Settings.jsonmanager.custommsg _SendUser { get; set; }
        private static string _UserName;
        private static string _Rank;
        private static Color _Color;
        private static string _VR { get; set; }
        private static string _Platform { get; set; }
        private static string _Friends { get; set; }
    }



}
