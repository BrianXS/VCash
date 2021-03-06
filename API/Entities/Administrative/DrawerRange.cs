using System.Collections.Generic;
using API.Enums;

namespace API.Entities.Administrative
{
    public class DrawerRange
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public Currency Currency { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<Drawer> Drawers { get; set; }
    }
}