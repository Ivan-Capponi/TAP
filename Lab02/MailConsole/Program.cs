using System;
using EmailSenderInterfaces;
using TinyDependencyInjectionContainer;

namespace MailConsole
{
    class Program
    {
        public static void Main()
        {
            var resolver = new InterfaceResolver("TDIC_Configuration.txt");
            var sender = resolver.Instantiate<IEmailSender>();
            sender.SendEmail("pippo", "pluto");
            Console.ReadLine();
        }
    }
}
