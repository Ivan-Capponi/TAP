using EmailSenderInterfaces;
using System;

namespace EmailSenderImplementation3
{
    public class EmailSenderImplementation3 : IEmailSender
    {
        private readonly PersonalInfo _sender;

        public EmailSenderImplementation3(PersonalInfo sender)
        {
            _sender = sender ?? throw new ArgumentNullException();
        }

        public bool SendEmail(string to, string body)
        {
            Console.WriteLine("Implementazione 3: Nome: {2}, Cognome: {3}, Destinatario: {0}, corpo: {1}", to, body, _sender.GetName(), _sender.GetLastName());
            return true;
        }
    }

    public class PersonalInfo
    {
        private readonly string _name;
        private readonly string _lastName;

        [MyAttribute.My("Ivan", "Capponi")]
        public PersonalInfo(string name, string lastName)
        {
            _name = name;
            _lastName = lastName;
        }

        public string GetName()
        {
            return _name;
        }

        public string GetLastName()
        {
            return _lastName;
        }
    }
}
