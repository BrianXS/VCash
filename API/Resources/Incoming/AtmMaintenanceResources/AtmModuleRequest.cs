using API.Entities;
using API.Enums.ATM;

namespace API.Resources.Incoming.AtmMaintenanceResources
{
    public class AtmModuleRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ProductLine ProductLine { get; set; }
        public Brand Platform { get; set; }
    }
}