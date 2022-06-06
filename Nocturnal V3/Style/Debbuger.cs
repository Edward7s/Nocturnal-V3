
using Nocturnal.Ui;
namespace Nocturnal.Style
{
    internal class Debbuger
    {
        private static string _lastlines = "";

        public static string Debugermsg(string text)
        {
            if (!Settings.ConfigVars.qmdebug)
                return null;

            while (Qm_basic._debugtext.text == null)
                return null;


            if (_lastlines != string.Empty)
            {
                var today = System.DateTime.Now;
                var stringtime = today.ToString("HH:mm:ss");
                Qm_basic._debugtext.text = "";
                Qm_basic._debugtext.text = $"</color>[<color=#ff1f53>{stringtime}</color>] - {text}\n{_lastlines}";
                _lastlines = Qm_basic._debugtext.text;
            }
            else
            {
                var today = System.DateTime.Now;
                var stringtime = today.ToString("HH:mm:ss");
                Qm_basic._debugtext.text = $"</color>[<color=#ff1f53>{stringtime}</color>] - {text}\n";
                _lastlines = Qm_basic._debugtext.text;
            }
            if (_lastlines.Split('\n').Length > 15)
            {
                string stringi = "";
                int ab = 0;
                foreach (var line in _lastlines.Split('\n'))
                {
                    ab += 1;
                    if (ab < 17)
                        stringi += $"{line}\n";
           
                }
                _lastlines = stringi;
            }
            Qm_basic._debugtext.text = _lastlines;





            return _lastlines;
        }
    }
}
