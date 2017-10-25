using System;
using EmailSenderInterfaces;
namespace EmailSenderImplementation1
{
    public class EmailSenderImplementation1 : IEmailSender
    {
        public bool SendEmail(string to, string body)
        {
            Console.WriteLine("Implementazione 1: Destinatario: {0}, corpo: {1}", to, body);
            return true;
        }
    }
}
