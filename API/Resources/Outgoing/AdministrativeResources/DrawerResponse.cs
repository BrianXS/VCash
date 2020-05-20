using API.Entities;
using API.Enums;

namespace API.Resources.Outgoing.AdministrativeResources
{
    public class DrawerResponse
    {
        public int Id { get; set; }
        public decimal MaxValue { get; set; }
        public int DefaultQuantity { get; set; }
        
        public DrawerType DrawerType { get; set; }
        public DrawerFunction DrawerFunction { get; set; }

        public int DrawerRangeId { get; set; }
        public string DrawerRange { get; set; }

        public int DenominationTypeId { get; set; }
        public string DenominationType { get; set; }
    }
}