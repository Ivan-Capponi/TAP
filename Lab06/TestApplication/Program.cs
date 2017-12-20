using System;

namespace TestApplication
{
    class Program
    {
        static void Main()
        {
            BugTrackingSystem.BugTrackingSystem.LoadBugTracking("Server=.\\SQLEXPRESS;Database=TAP3;Integrated Security=True;", "TAP123");
            Console.WriteLine("OK");
            Console.ReadLine();
        }
    }
}
