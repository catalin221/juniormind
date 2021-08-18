using Flowchart;
using UserJourney;
using System;

namespace DrawMermaid
{
    class Program
    {
        static void Main()
        {
            DrawUserJourney journey = new DrawUserJourney();
            Console.WriteLine("Please input path");
            journey.DrawJourney(Console.ReadLine());
            Console.WriteLine("File created");
        }
    }
}
