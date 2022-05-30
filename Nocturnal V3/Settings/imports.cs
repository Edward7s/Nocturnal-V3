using System;
using System.Runtime.InteropServices;

namespace Nocturnal.Settings
{
	internal class Imports
	{
		[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
		internal static extern void keybd_event(uint bVk, uint bScan, uint dwFlags, uint dwExtraInfo);


		[DllImport("User32.dll")]
		internal static extern int SetForegroundWindow(IntPtr point);

		[DllImport("kernel32.dll")]
		internal static extern IntPtr GetConsoleWindow();


		[DllImport("user32.dll", EntryPoint = "SetWindowText")]
		public static extern bool SetWindowText(System.IntPtr hwnd, System.String lpString);
		[DllImport("user32.dll", EntryPoint = "FindWindow")]
		public static extern System.IntPtr FindWindow(System.String className, System.String windowName);

		[DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		public static extern int SendMessage(IntPtr hwnd, int message, int wParam, IntPtr lParam);



	}
}
