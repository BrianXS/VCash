using System.Collections.Generic;
using API.Entities;
using API.Enums;

namespace API.Resources.Outgoing.AdministrativeResources
{
    public class DrawerRangeResponse
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Currency Currency { get; set; }

        public int CustomerId { get; set; }
        public string Customer { get; set; }
    }
}