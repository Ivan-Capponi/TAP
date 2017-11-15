using EmailSenderInterfaces;
using System;

namespace EmailSenderImplementation3
{
    public class EmailSenderImplementation3 : IEmailSender
    {
        private readonly string _name;
        private readonly string _lastName;
        public EmailSenderImplementation3(string name, string lastName)
        {
            if (name == null || lastName == null)
                throw new ArgumentNullException();
            _name = name;
            _lastName = lastName;
        }

        public bool SendEmail(string to, string body)
        {
            Console.WriteLine("Implementazione 3: Nome: {2}, Cognome: {3}, Destinatario: {0}, corpo: {1}", to, body, _name, _lastName);
            return true;
        }
    }
}
