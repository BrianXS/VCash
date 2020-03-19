using System.ComponentModel.DataAnnotations.Schema;
using API.Enums;

namespace API.Entities
{
    public class Drawer
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal MaxValue { get; set; }
        public int DefaultQuantity { get; set; }
        
        public DrawerType DrawerType { get; set; }
        public DrawerFunction DrawerFunction { get; set; }

        public int DrawerRangeId { get; set; }
        public DrawerRange DrawerRange { get; set; }

        public int DenominationTypeId { get; set; }
        public DenominationType DenominationType { get; set; }
    }
}