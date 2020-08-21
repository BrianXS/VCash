using System.ServiceModel;
using System.Xml;
using API.Services.Soap.Resources.Incoming;

namespace API.Services.Soap.Services.Interfaces
{
    [ServiceContract]
    public interface ITicketDemoService
    {
        [OperationContract]
        string Test(string s);

        [OperationContract]
        void XmlMethod(XmlElement xmlElement);

        [OperationContract]
        CreateTicket TestTicketDemo(CreateTicket createTicket);
    }
}