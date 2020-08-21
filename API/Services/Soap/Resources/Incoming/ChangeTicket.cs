using System.Runtime.Serialization;

namespace API.Services.Soap.Resources.Incoming
{
    [DataContract]
    public class ChangeTicket
    {
        public string TicketSourceNumber { get; set; }
        public string TicketNumberGenerated { get; set; }
        public string AppoinmentDateTime { get; set; }
        public string ProblemDescription { get; set; }
        public string Type { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}