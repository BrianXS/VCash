using System;
using System.Xml;
using API.Services.Soap.Resources.Incoming;
using API.Services.Soap.Services.Interfaces;

namespace API.Services.Soap.Services.Implementation
{
    public class TicketDemoService : ITicketDemoService
    {
        public string Test(string s)
        {
            Console.WriteLine("It works");
            return s;
        }

        public void XmlMethod(XmlElement xmlElement)
        {
            Console.WriteLine(xmlElement.ToString());
        }

        public CreateTicket TestTicketDemo(CreateTicket createTicket)
        {
            return createTicket;
        }
    }
}