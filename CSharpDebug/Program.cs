using System;

namespace CSharpDebug;

internal static class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("CSharpDebug environment restored. Ready to run.");
        if (args.Length == 0)
        {
            return;
        }

        Console.WriteLine("Arguments:");
        foreach (var arg in args)
        {
            Console.WriteLine($" - {arg}");
        }
    }
}
