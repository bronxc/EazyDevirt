﻿using EazyDevirt.Abstractions;

namespace EazyDevirt.Logging;

public class ConsoleLogger : ILogger
{
    public void Success(object message) => WriteLine(message, ConsoleColor.Cyan, '+');

    public void Warning(object message) => WriteLine(message, ConsoleColor.Yellow, '-');

    public void Error(object message) => WriteLine(message, ConsoleColor.Red, '!');

    public void Info(object message) => WriteLine(message, ConsoleColor.Gray, '*');

    public void InfoStr(object message, object message2) => WriteLineInfo(message, ConsoleColor.Red, message2);
    
    public void ShowInfo(Version version)
    {
        Console.WriteLine();
        Console.WriteLine();
        WriteLineMiddle(@"▄███▄   ██   ▄▄▄▄▄▄ ▀▄    ▄ ", ConsoleColor.DarkMagenta);
        WriteLineMiddle(@"█▀   ▀  █ █ ▀   ▄▄▀   █  █  ", ConsoleColor.DarkMagenta);
        WriteLineMiddle(@"██▄▄    █▄▄█ ▄▀▀   ▄▀  ▀█   ", ConsoleColor.DarkMagenta);
        WriteLineMiddle(@"█▄   ▄▀ █  █ ▀▀▀▀▀▀    █    ", ConsoleColor.DarkMagenta);
        WriteLineMiddle(@"▀███▀      █         ▄▀     ", ConsoleColor.DarkMagenta);
        WriteLineMiddle(@"          █                 ", ConsoleColor.DarkMagenta);
        WriteLineMiddle(@"         ▀                  ", ConsoleColor.DarkMagenta);
        WriteLineMiddle(@"                                            ", ConsoleColor.DarkMagenta);
        WriteMiddle(@"Version - ", ConsoleColor.DarkMagenta);
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(version);
        Console.ResetColor();

        WriteMiddle(@"Developers - ", ConsoleColor.DarkMagenta);
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("puff");
        Console.ResetColor();

        WriteMiddle(@"Github Repo - ", ConsoleColor.DarkMagenta);
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("https://github.com/puff/EazyDevirt");
        Console.ResetColor();
        
        WriteMiddle(@"Thanks to - ", ConsoleColor.DarkMagenta);
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("clifford for helping with Eazfuscator.NET's VM."); 
        
        // 55 = ("TobitoFatitoRE for the amazing HexDevirt project.".length + "Thanks to - ".length) - ("Thanks to - ".length / 2)
        Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 
                                                 + 55 + "}"), "TobitoFatitoRE for the amazing HexDevirt project."));
        
        // 54 = ("Washi1337 for the wonderful AsmResolver library.".length + "Thanks to - ".length) - ("Thanks to - ".length / 2)
        Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2
                                                 + 54 + "}"), "Washi1337 for the wonderful AsmResolver library."));
        Console.ResetColor();
    }

    private void WriteMiddle(object message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(string.Format("{0," + (Console.WindowWidth / 2 + message.ToString()?.Length / 2) + "}",
            message));
        Console.ResetColor();
    }

    private void WriteLineMiddle(object message, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(string.Format("{0," + (Console.WindowWidth / 2 + message.ToString()?.Length / 2) + "}",
            message));
        Console.ResetColor();
    }
    
    private void WriteLine(object message, ConsoleColor color, char character)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("[");
        Console.ForegroundColor = color;
        Console.Write(character);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("] ");
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private void WriteLineInfo(object message, ConsoleColor color, object msg2)
    {
        Console.ForegroundColor = color;
        Console.Write("[");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(msg2);
        Console.ForegroundColor = color;
        Console.Write("] ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}