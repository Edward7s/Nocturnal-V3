using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Nocturnal.Ui;
namespace Nocturnal.Style
{
    internal class Debbuger
    {
        private static string lastlines = "";

        public static string debugermsg(string text)
        {
            if (!Settings.ConfigVars.qmdebug)
                return null;

            while (Qm_basic.debugtext.text == null)
                return null;


            if (lastlines != string.Empty)
            {
                var today = System.DateTime.Now;
                var stringtime = today.ToString("HH:mm:ss");
                Qm_basic.debugtext.text = "";
                Qm_basic.debugtext.text = $"</color>[<color=#ff1f53>{stringtime}</color>] - {text}\n{lastlines}";
                lastlines = Qm_basic.debugtext.text;
            }
            else
            {
                var today = System.DateTime.Now;
                var stringtime = today.ToString("HH:mm:ss");
                Qm_basic.debugtext.text = $"</color>[<color=#ff1f53>{stringtime}</color>] - {text}\n";
                lastlines = Qm_basic.debugtext.text;
            }
            if (lastlines.Split('\n').Length > 15)
            {
                string stringi = "";
                int ab = 0;
                foreach (var line in lastlines.Split('\n'))
                {
                    ab += 1;
                    if (ab < 17)
                        stringi += $"{line}\n";
           
                }
                lastlines = stringi;
            }
            Qm_basic.debugtext.text = lastlines;





            return lastlines;
        }
    }
}
