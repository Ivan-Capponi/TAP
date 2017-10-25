using System;
using EmailSenderInterfaces;

namespace EmailSenderImplementation2
{
    public class EmailSenderImplementation2 : IEmailSender
    {
        public bool SendEmail(string to, string body)
        {
            Console.WriteLine("Implementazione 2: Destinatario: {0}, corpo: {1}", to, body);
            return true;
        }
    }
}
