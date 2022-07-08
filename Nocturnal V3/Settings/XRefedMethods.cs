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
        private static MethodInfo s_numbKeyboard { get; set; }
        private static MethodInfo s_toggle { get; set; }
        private static MethodInfo s_warning { get; set; }
        private static MethodInfo s_inputPopout { get; set; }

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
                                s_warning = methods[i];
                                break;
                            case true when xrefedmethods[i2].ReadAsObject().ToString() == "UserInterface/MenuContent/Popups/InputKeypadPopup":
                                s_numbKeyboard = methods[i];
                                break;
                            case true when xrefedmethods[i2].ReadAsObject().ToString() == "UserInterface/MenuContent/Popups/StandardPopupV2":
                                s_toggle = methods[i];
                                break;
                            case true when xrefedmethods[i2].ReadAsObject().ToString() == "UserInterface/MenuContent/Popups/InputPopup":
                                s_inputPopout = methods[i];
                                break;
                        }
                    }


                }
            }
            catch { }
        }





        internal static void PopOutWarrningMessage(string _message, string description = "", float _Time = 10)
        {
            CheckQuickMenu();
            s_warning.Invoke(VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, new object[] { _message, description, _Time });
        }

        internal static void PopOutToggle(string _title, string _desciption, Action _ok = null, Action _cancel = null)
        {
            CheckQuickMenu();
            s_toggle.Invoke(VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, new object[] {_title, _desciption, "Cancel"
                  ,(Il2CppSystem.Action)new Action(()=> {_cancel.Invoke();
                  VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Private_Void_0();
                  }), "Accept",(Il2CppSystem.Action)new Action(()=> {_ok.Invoke(); VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Private_Void_0(); }),null});
        }
        internal static void PopOutNumbersKeyboard(string _title, Action<int> _intOut, Action _action)
        {
            CheckQuickMenu();
            s_numbKeyboard.Invoke(VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, new object[] {_title, "", InputField.InputType.Standard, true, "Enter", DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>>
                              (new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>
                              (delegate (string s, Il2CppSystem.Collections.Generic.List<KeyCode> k, Text t)
                              {
                                  _intOut(int.Parse(s));
                                  _action.Invoke();
                              })), null,"Enter A text",true,null,false,0});
        }

        internal static void PopOutInput(string _title, Action<string> _stringOut, Action _action)
        {
            CheckQuickMenu();
            s_inputPopout.Invoke(VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0, new object[] {_title, "", InputField.InputType.Standard, false, "Enter",
                            DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>>
                                (new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>
                                (delegate (string s, Il2CppSystem.Collections.Generic.List<KeyCode> k, Text t)
                                {
                                    _stringOut(s);
                                    _action.Invoke();
                               })),null,"Enter text....",true,null,false,0 });
        }

    }

}

