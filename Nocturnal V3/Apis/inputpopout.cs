using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis
{
    internal class inputpopout
    {
        internal static string run(string name, Action<string> setOutput, Action action)
        {
            string returned = "";
            VRCUiPopupManager.field_Private_Static_VRCUiPopupManager_0.Method_Public_Void_String_String_InputType_Boolean_String_Action_3_String_List_1_KeyCode_Text_Action_String_Boolean_Action_1_VRCUiPopup_Boolean_PDM_0(name, "", InputField.InputType.Standard, false, "Enter",
                    DelegateSupport.ConvertDelegate<Il2CppSystem.Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>>
                        (new Action<string, Il2CppSystem.Collections.Generic.List<KeyCode>, Text>
                        (delegate (string s, Il2CppSystem.Collections.Generic.List<KeyCode> k, Text t)
                        {
                            setOutput(s);
                            action.Invoke();
                            ;

                        })), null, "", true, null);
            return returned;
        }
    }
}
