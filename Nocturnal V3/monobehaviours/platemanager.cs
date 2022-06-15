using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.Monobehaviours
{
    internal class Platemanager : MonoBehaviour
    {
        public Platemanager(IntPtr ptr) : base(ptr)
        {

        }
        void OnEnable()
        {
            var user = this.gameObject.GetComponent<VRC.Player>();
            Color color = Color.white;
            string rank = "";
                Settings.wrappers.Ranks.gettrsutrank(user.field_Private_APIUser_0, ref rank, ref color);
            if (user.IsFriend())
                color = new Color(Settings.ConfigVars.friend[0], Settings.ConfigVars.friend[1], Settings.ConfigVars.friend[2]);
            var plategmj = this.gameObject.GetComponent<VRCPlayer>().field_Public_PlayerNameplate_0.field_Public_GameObject_0.gameObject;
            GameObject Plates = new GameObject();
            Plates.name = "Platesmanager";
            Plates.AddComponent<UnityEngine.UI.GridLayoutGroup>();
            Plates.transform.parent = plategmj.transform;
            Plates.transform.localPosition = new Vector3(0,105, 0);
            Plates.transform.localScale = new Vector3(1, 1, 1);
            Plates.transform.rotation = new Quaternion(0, 0, 0, 0);
            Plates.GetComponent<RectTransform>().sizeDelta = new Vector2(100, 150);
            var vert = Plates.GetComponent<UnityEngine.UI.GridLayoutGroup>();
            vert.constraint = UnityEngine.UI.GridLayoutGroup.Constraint.FixedColumnCount;
            vert.constraintCount = 1;
            vert.childAlignment = TextAnchor.LowerCenter;
            vert.cellSize = new Vector2(100, 30);
            var plateholder = new GameObject("Plate Holder");
            plateholder.transform.parent = Plates.transform;
            plateholder.transform.localPosition = Vector3.zero;
            plateholder.transform.localScale = Vector3.one;
            plateholder.transform.localEulerAngles = Vector3.zero;
            plateholder.AddComponent<UnityEngine.UI.LayoutElement>();
            plateholder.gameObject.SetActive(false);
            var prefabplate = GameObject.Instantiate(plategmj.transform.Find("Quick Stats").gameObject, plateholder.transform);
            GameObject.DestroyImmediate(prefabplate.transform.Find("Performance Icon").gameObject);
            GameObject.DestroyImmediate(prefabplate.transform.Find("Performance Text").gameObject);
            GameObject.DestroyImmediate(prefabplate.transform.Find("Friend Anchor Stats").gameObject);
            var icon = prefabplate.transform.Find("Trust Icon");
            icon.name = "Icon";
            icon.gameObject.SetActive(false);
            prefabplate.transform.Find("Trust Text").name = "Text";
            prefabplate.name = "PrefabPlate";
            var platem = plategmj.transform.Find("Main/Background").gameObject.GetComponent<ImageThreeSlice>();
            platem.color = color;
            plategmj.transform.Find("Icon/Background").gameObject.GetComponent<UnityEngine.UI.Image>().color = color;
            if (user != VRC.Player.prop_Player_0)
            this.gameObject.transform.Find("SelectRegion").GetComponent<MeshRenderer>().material.color = color;
        }

    }
    }
