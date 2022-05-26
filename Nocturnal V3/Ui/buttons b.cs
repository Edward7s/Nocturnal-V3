using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Nocturnal.Apis.bigui;
using VRC;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.Ui
{
    internal class buttons_b
    {
        internal static GameObject buttonaddtag;
        internal static void runbuttons()
        {
            var addnewgmj = new GameObject();
            var grid = addnewgmj.AddComponent<GridLayoutGroup>();
            grid.cellSize = new Vector2(200, 100);
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = 6;
            addnewgmj.name = "N_VBTNHOLDER";
            addnewgmj.transform.parent = objects.userinfpannel.transform.Find("User Panel").transform;
            addnewgmj.transform.localPosition = new Vector3(49.7516f, -284.6267f, 0);
            addnewgmj.transform.localScale = Vector3.one;
            BButton.NormalButton("Target User", addnewgmj, () => Nocturnal.Settings.wrappers.Target.Targetuser(GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id));
            BButton.NormalButton("Teleport", addnewgmj, () =>
            {

                var User = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id;
                try
                {
                    VRC.Player.prop_Player_0.transform.position = User.getuserbyid().transform.position;
              
                }
                catch { }

            });
            BButton.NormalButton("Force Clone", addnewgmj, () =>
            {
                var aviid = "";
                var User = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id;
                try
                {
                    var user = User.getuserbyid();

                    if (user.field_Private_APIUser_0.id == User)
                            aviid = user.prop_ApiAvatar_0.id;
                    
                    exploits.misc.changetoavi(aviid);
                }
                catch{ }
              

            });
            BButton.NormalButton("Copy uid", addnewgmj, () => System.Windows.Forms.Clipboard.SetText(GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id));

            buttonaddtag = BButton.NormalButton("Set Tag", addnewgmj, () =>
            {
                string tagtosend = "";



                Apis.inputpopout.run("", value => tagtosend = value, () => {

                    if (tagtosend.Trim().Length > 60)
                    {
                        NocturnalC.log("Message can not be bigger then 60C");
                        return;
                    }


                    var newtag = new Settings.jsonmanager.custommsg2()
                    {

                        code = "9",

                        msg2 = buttonaddtag.transform.parent.parent.parent.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id,

                        msg = tagtosend.Trim(),

                    };

                    server.setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(newtag));
                  

                });

           

            });

            buttonaddtag.gameObject.SetActive(false);
            biguiscrollbar.setscrollbars();
            Bundles.loadrain();

        }
    }
}
