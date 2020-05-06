using System;

namespace Range
{
    class MainClass
    {
        private static void Main(string[] args)
        {
            string text = System.IO.File.ReadAllText(args[1]);
            var match = new Value().Match(text).Success();

            Console.WriteLine(!match ? "Nu este JSON" : "Este JSON");
        }
    }
}