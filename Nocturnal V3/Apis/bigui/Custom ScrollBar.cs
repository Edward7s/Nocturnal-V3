using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
namespace Nocturnal.Apis.bigui
{
    internal class Custom_ScrollBar
    {
        internal static Scrollbar Scroll(GameObject path, float x, float y, float sizeX, float sizeY)
        {
            var scrollbar = GameObject.Instantiate(Ui.Objects._Scrollbargmj, path.transform).gameObject;
            scrollbar.transform.localScale = new Vector3(sizeX, sizeY, 1);
            scrollbar.transform.rotation = new Quaternion(0, 0, 0, 0);
            scrollbar.transform.localPosition = new Vector3(x * 10, y * 10, 1);
            return scrollbar.GetComponent<Scrollbar>();
        }
    }
}
