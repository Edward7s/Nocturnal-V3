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
using Nocturnal.Settings;

namespace Nocturnal.Ui
{
    internal class buttons_b
    {
        internal static GameObject buttonaddtag;
        internal static void Runbuttons()
        {
            var addnewgmj = new GameObject();
            var grid = addnewgmj.AddComponent<GridLayoutGroup>();
            grid.cellSize = new Vector2(135, 100);
            grid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            grid.constraintCount = 9;
            addnewgmj.name = "N_VBTNHOLDER";
            addnewgmj.transform.parent = Objects._userinfpannel.transform.Find("User Panel").transform;
            addnewgmj.transform.localPosition = new Vector3(49.7516f, -281.5556f, 0);
            addnewgmj.transform.localScale = Vector3.one;
            addnewgmj.transform.localEulerAngles = Vector3.zero;
            var userp = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>();

            new BButton("Target User", addnewgmj, () => Nocturnal.Settings.wrappers.Target.Targetuser(GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id));
            new BButton("Teleport", addnewgmj, () =>
            {
                try
                {
                    VRC.Player.prop_Player_0.transform.position = userp.field_Private_APIUser_0.id.getuserbyid().transform.position;
              
                }
                catch { }

            });

            new BButton("Force Clone", addnewgmj, () =>
            {
                var aviid = "";
                try
                {
                    var user = userp.field_Private_APIUser_0.id.getuserbyid();

                    if (user.field_Private_APIUser_0.id == userp.field_Private_APIUser_0.id)
                            aviid = user.prop_ApiAvatar_0.id;
                    
                    Exploits.Misc.Changetoavi(aviid);
                }
                catch{ }
              

            });
            new BButton("Copy uid", addnewgmj, () => System.Windows.Forms.Clipboard.SetText(GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/UserInfo").gameObject.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id));

            new BButton("Copy avi id", addnewgmj, () =>
            {
                try
                {
                    userp.field_Private_APIUser_0.Fetch();
                    NocturnalC.Log(userp.field_Private_APIUser_0.avatarId);
                    System.Windows.Forms.Clipboard.SetText(userp.field_Private_APIUser_0.avatarId);

                }
                catch { }
               
            });

            new BButton("Copy avi img", addnewgmj, () =>
            {
                NocturnalC.Log(userp.field_Private_APIUser_0.currentAvatarImageUrl);
                System.Windows.Forms.Clipboard.SetText(userp.field_Private_APIUser_0.currentAvatarImageUrl);
            });


             new BButton(out buttonaddtag,"Set Tag", addnewgmj, () =>
            {
                string tagtosend = "";



                XRefedMethods.PopOutInput("", value => tagtosend = value, () => {

                    if (tagtosend.Trim().Length > 60)
                    {
                        NocturnalC.Log("Message can not be bigger then 60C");
                        return;
                    }


                    var newtag = new Settings.jsonmanager.custommsg2()
                    {

                        code = "9",

                        msg2 = userp.field_Private_APIUser_0.id,

                        msg = tagtosend.Trim(),

                    };

                    server.setup.sendmessage(Newtonsoft.Json.JsonConvert.SerializeObject(newtag));
                  

                });

           

            });

            buttonaddtag.gameObject.SetActive(false);
            Biguiscrollbar.setscrollbars();
            Bundles.loadrain();







            var worldinfogmj = GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/WorldInfo").transform;
            var worldinfo = worldinfogmj.GetComponent<VRC.UI.PageWorldInfo>();
            var newworlgmj = new GameObject();
            var newgrid = newworlgmj.AddComponent<GridLayoutGroup>();
           // grid.cellSize = new Vector2(200, 100);
            newgrid.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            newgrid.constraintCount = 3;
            newworlgmj.name = "N_VBTNHOLDER";
            newworlgmj.transform.parent = worldinfogmj;
            newworlgmj.transform.localPosition = new Vector3(-475, 320, 0);
            newworlgmj.transform.localScale = Vector3.one;
            newworlgmj.transform.localEulerAngles = Vector3.zero;
            new BButton("Copy Id", newworlgmj, () =>
            {
                NocturnalC.Log(worldinfo.field_Public_ApiWorldInstance_0.id);
                System.Windows.Forms.Clipboard.SetText(worldinfo.field_Public_ApiWorldInstance_0.id);
            });
            new BButton("Creator Id", newworlgmj, () =>
            {
                NocturnalC.Log(worldinfo.field_Public_APIUser_0.id);
                System.Windows.Forms.Clipboard.SetText(worldinfo.field_Public_APIUser_0.id);
            });
            new BButton("Asset Url", newworlgmj, () =>
            {
                NocturnalC.Log(worldinfo.field_Private_ApiWorld_0.assetUrl);
                System.Windows.Forms.Clipboard.SetText(worldinfo.field_Private_ApiWorld_0.assetUrl);
                Application.OpenURL(worldinfo.field_Private_ApiWorld_0.assetUrl);
            });
            new BButton("Copy Img", newworlgmj, () =>
            {
                NocturnalC.Log(worldinfo.field_Private_ApiWorld_0.imageUrl);
                System.Windows.Forms.Clipboard.SetText(worldinfo.field_Private_ApiWorld_0.imageUrl);
            });
            new BButton("Reset HWID", GameObject.Find("/UserInterface").transform.Find("MenuContent/Screens/Authentication/StoreLoginPrompt").gameObject, () =>
            Settings.ConfigVars.SpoofedHWID = Guid.NewGuid().ToString().Replace("-", "3")
           );

        }

    }
}
