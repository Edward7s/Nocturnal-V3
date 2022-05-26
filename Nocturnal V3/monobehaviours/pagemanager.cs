using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Nocturnal.monobehaviours
{
    internal class pagemanager : MonoBehaviour
    {
        public pagemanager(IntPtr ptr) : base(ptr)
        {

        }

       
        public void OnEnable()
        {
              // NocturnalC.log($"Opend: {this.gameObject.name}");
            switch (true)
            {
                case true when this.name == "Social":
                    Ui.objects.onlinefriendstext.text = $"Online Friends        [{Ui.objects.friendlistmanager.field_Private_List_1_IUser_1.Count} / {Ui.objects.friendlistmanager.field_Private_List_1_IUser_0.Count}]";
                  Ui.objects.friendreqeusts.text = $"Friend Requests        [{Ui.objects.notmanager.field_Private_List_1_InterfacePublicAbstractStOb1StTeVaSt1Te2Unique_1.Count}]";
                  //  Ui.objects.group1.text = Ui.objects.friendlistmanager.prop_String_0 + $"  [{Ui.objects.friendlistmanager.field_Private_List_1_IUser_3.Count} / 64]";
                  //  Ui.objects.group2.text = Ui.objects.friendlistmanager.prop_String_1 + $"  [{Ui.objects.friendlistmanager.field_Private_List_1_IUser_4.Count} / 64]";
                  //  Ui.objects.group3.text = Ui.objects.friendlistmanager.prop_String_2 + $"  [{Ui.objects.friendlistmanager.field_Private_List_1_IUser_5.Count} / 64]";
                    Ui.objects.offlinefriends.text = $"Offline Friends (Expand to Show)        [{Ui.objects.friendlistmanager.prop_List_1_IUser_2.Count}]";
                    break;
                case true when this.name == "UserInfo":
                 
                    break;
                case true when this.name == "WorldInfo":
                    break;

                case true when this.name == "Menu_SelectedUser_Local":
                    break;
                case true when this.name == "Canvas_QuickMenu(Clone)":
                    Ui.Qm_basic.firsttext.text = string.Format("{0:hh:mm:ss tt}", DateTime.Now);
                    Ui.Qm_basic.Thirdtext.text = $"Friends: {Ui.objects.friendlistmanager.field_Private_List_1_IUser_1.Count}/{Ui.objects.friendlistmanager.field_Private_List_1_IUser_0.Count}";
                    var getm = new Settings.jsonmanager.custommsg()
                    {
                        code = "87",

                        msg = "Getonlineclients",
                    };
                    server.setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(getm));
                    break;

                    //   

            }
        }

        //void 

    }
}
