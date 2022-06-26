using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnhollowerRuntimeLib;
using Nocturnal.Ui;
namespace Nocturnal.Settings
{
    internal class XRefedMethods
    {
        private static MethodInfo _NumbKeyboard { get; set; }
        private static MethodInfo _Toggle { get; set; }
        private static MethodInfo _Warning { get; set; }
        private static MethodInfo _InputPopout { get; set; }

        private static void CheckQuickMenu()
        {
            if (Objects._QuickMenuCanvas.activeSelf)
                Objects._QuickMenuCanvas.SetActive(false);
        }


        internal static void SetMethods()
        {
            MethodInfo[] methods = typeof(VRCUiPopupManager).GetMethods();
            try
            {
                for (int i = 0; i < methods.Length; i++)
                {
                    var xrefedmethods = UnhollowerRuntimeLib.XrefScans.XrefScanner.XrefScan(methods[i]).ToArray();
                    for (int i2 = 0; i2 < xrefedmethods.Length; i2++)
                    {
                        if (xrefedmethods[i2].Type != UnhollowerRuntimeLib.XrefScans.XrefType.Global) continue;
                        switch (true)
                        {
                            case true when xrefedmethods[i2].ReadAsObject().ToString() == "UserInterface/MenuContent/Popups/AlertPopup":
                                _Warning = methods[i];
                                break;
                            case true when xrefedmethods[i2].ReadAsObject().ToString() == "UserInterface/MenuContent/Popups/InputKeypadPopup":
                                _NumbKeyboard = methods[i];
                                break;
                            case true when xrefedmethods[i2].ReadAsObject().ToString() == "UserInterface/MenuContent/Popups/StandardPopupV2":
                                _Toggle = methods[i];
                                break;
                            case true when xrefedmethods[i2].ReadAsObject().ToString() == "UserInterface/MenuContent/Popups/InputPopup":
                                _InputPopout = methods[i];
                                break;
                        }
                    }


                }
            }
            catch { }
        }





        internal static void PopOutWarrningMessage(string _Message, float _Time = 10)
        {
            CheckQuickMenu();
            _Warning.Invoke(VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, new object[] { _Message, "Ok", _Time });
        }

        internal static void PopOutToggle(string _Title, string _Desciption, Action _Ok = null, Action _Cancel = null)
        {
            CheckQuickMenu();
            _Toggle.Invoke(VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, new object[] {_Title, _Desciption, "Cancel"
                  , _Cancel, "Accept", _Ok});
        }
        internal static void PopOutNumbersKeyboard(string _Title, Action<int> _IntOut, Action _Action)
        {
            CheckQuickMenu();
            _NumbKeyboard.Invoke(VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, new object[] {_Title, "", InputField.InputType.Standard, true, "Enter", DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>>
                              (new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>
                              (delegate (string s, Il2CppSystem.Collections.Generic.List<KeyCode> k, Text t)
                              {
                                  _IntOut(int.Parse(s));
                                  _Action.Invoke();
                              })), null,"Enter A text",true,null,false,0});
        }

        internal static void PopOutInput(string _Title, Action<string> _StringOut, Action _Action)
        {
            CheckQuickMenu();
            _InputPopout.Invoke(VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, new object[] {_Title, "", InputField.InputType.Standard, false, "Enter",
                            DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>>
                                (new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>
                                (delegate (string s, Il2CppSystem.Collections.Generic.List<KeyCode> k, Text t)
                                {
                                    _StringOut(s);
                                    _Action.Invoke();
                               })),null,"Enter text....",true,null,false,0 });
        }

    }

}

