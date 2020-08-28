using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AtmMaintenanceResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class TicketConcepts
    {
        public static void SeetTicketConcepts(ITicketConceptRepository ticketConceptRepository)
        {
            if (ticketConceptRepository.Count() == 0)
            {
                var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/TicketConcepts.csv");
                using var csv = new CsvReader(stream, new CultureInfo("en-US", false));
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<TicketConceptRequest>();
                ticketConceptRepository.CreateTicketConceptsRange(records.ToList());
            }
        }
    }
}