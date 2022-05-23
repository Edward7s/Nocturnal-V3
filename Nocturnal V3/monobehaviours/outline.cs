using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Nocturnal.Settings.wrappers;
namespace Nocturnal.monobehaviours
{
    internal class outline : MonoBehaviour
    {
        public outline(IntPtr ptr) : base(ptr)
        {

        }

        //


        void Awake()
        {
            var esp = GameObject.Instantiate(this.gameObject.transform.Find("SelectRegion").gameObject, this.gameObject.transform.Find("SelectRegion").transform).gameObject;
            esp.name = "ESP";
            Component.DestroyImmediate(esp.GetComponent<PlayerSelector>());
            Component.DestroyImmediate(esp.GetComponent<CapsuleCollider>());
            esp.transform.localScale = Vector3.one;
            esp.transform.localPosition = Vector3.zero;
            string empt = "";
            Color outlinecolor = Color.white;
            Settings.wrappers.Ranks.gettrsutrank(this.transform.gameObject.GetComponent<VRC.Player>().field_Private_APIUser_0, ref empt, ref outlinecolor);
            if (this.transform.gameObject.GetComponent<VRC.Player>().IsFriend())
                   outlinecolor = new Color(Settings.ConfigVars.friend[0], Settings.ConfigVars.friend[1], Settings.ConfigVars.friend[2],Settings.ConfigVars.friend[3]);
            var rend = esp.gameObject.GetComponentsInChildren<Renderer>();
            var outm = new Material(Ui.Bundles.outlshader);
            outm.EnableKeyword("_falloff");
            outm.SetFloat("_falloff", Settings.ConfigVars.falloff * 30);
            outm.EnableKeyword("_Color");
            outm.SetColor("_Color", outlinecolor);
            outm.EnableKeyword("width");
            outm.SetFloat("_Width", Settings.ConfigVars.espwidth);
         
            esp.gameObject.GetComponent<MeshRenderer>().materials.FirstOrDefault<Material>().color = new Color(0, 0, 0, 0);
            esp.gameObject.GetComponent<MeshRenderer>().enabled = true;
            for (int i = 0; i < rend.Length; i++)
            {
                var materials = rend[i].sharedMaterials.ToList();
                materials.Add(outm);
                rend[i].materials = materials.ToArray();
            }
            esp.layer = 5;
            esp.gameObject.SetActive(Settings.ConfigVars.esp);
            esp.gameObject.GetComponent<MeshRenderer>().allowOcclusionWhenDynamic = false;

        }

    }
}
