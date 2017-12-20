using System;

namespace TestApplication
{
    class Program
    {
        static void Main()
        {
            BugTrackingSystem.BugTrackingSystem.LoadBugTracking("Server=.\\SQLEXPRESS;Database=TAP;Integrated Security=True;", "TAP123");
            Console.WriteLine("OK");
            Console.ReadLine();
        }
    }
}
