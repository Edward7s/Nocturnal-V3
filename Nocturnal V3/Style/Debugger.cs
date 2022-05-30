using Nocturnal.Ui;
namespace Nocturnal.Style
{
	internal class Debugger
	{
		private static string lastLines = "";

		public static string DebugMsg(string text)
		{
			if (!Settings.ConfigVars.qmdebug)
				return null;

			while (QMBasic.debugText.text == null)
				return null;


			if (lastLines != string.Empty)
			{
				var today = System.DateTime.Now;
				var stringtime = today.ToString("HH:mm:ss");
				QMBasic.debugText.text = "";
				QMBasic.debugText.text = $"</color>[<color=#ff1f53>{stringtime}</color>] - {text}\n{lastLines}";
				lastLines = QMBasic.debugText.text;
			}
			else
			{
				var today = System.DateTime.Now;
				var stringtime = today.ToString("HH:mm:ss");
				QMBasic.debugText.text = $"</color>[<color=#ff1f53>{stringtime}</color>] - {text}\n";
				lastLines = QMBasic.debugText.text;
			}
			if (lastLines.Split('\n').Length > 15)
			{
				string stringi = "";
				int ab = 0;
				foreach (var line in lastLines.Split('\n'))
				{
					ab += 1;
					if (ab < 17)
						stringi += $"{line}\n";

				}
				lastLines = stringi;
			}
			QMBasic.debugText.text = lastLines;

			return lastLines;
		}
	}
}
