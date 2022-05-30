﻿using System;

namespace Nocturnal
{


	class NocturnalConsole
	{

		private string art = " ";
		internal static string Log(object message, string types = "Blank", ConsoleColor color = ConsoleColor.White, bool msg = true)
		{
			if (!msg) return null;
			var time = System.DateTime.Now;
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.Write($"[{time.ToString("HH:mm:ss")}]");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write($":");
			Console.ForegroundColor = ConsoleColor.Red;
			string cbc = types == "Blank" ? "" : $"[{types}] ";
			Console.Write($"[ N V 3 ] {cbc}");
			Console.ForegroundColor = color;
			Console.Write(message.ToString());
			Console.WriteLine();
			return message.ToString();

		}
	}
}
