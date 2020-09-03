using System.Globalization;
using System.IO;
using System.Linq;
using API.Repositories.Interfaces;
using API.Resources.Incoming.AtmMaintenanceResources;
using CsvHelper;

namespace API.Services.Seeds.Logic
{
    public static class TicketStatuses
    {
        public static void SeedTicketStatuses(ITicketStatusRepository ticketStatusRepository)
        {
            if (!ticketStatusRepository.GetAllTicketStatuses().Any())
            {
                using var stream = new StreamReader(Constants.General.ProjectPath + "VCash/API/Services/Seeds/Data/TicketStatuses.csv");
                using var csv = new CsvReader(stream, CultureInfo.InvariantCulture);
            
                csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();
                var records = csv.GetRecords<TicketStatusRequest>();
                ticketStatusRepository.CreateTicketStatusesRange(records.ToList());
            }
        }
    }
}