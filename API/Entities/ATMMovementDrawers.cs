using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class ATMMovementDrawers
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal DepositValue { get; set; }
        
        [Column(TypeName = "decimal(18, 2)")]
        public decimal DispatchValue { get; set; }

        public int DrawerId { get; set; }
        public Drawer Drawer { get; set; }

        public int ATMMovementId { get; set; }
        public ATMMovement ATMMovement { get; set; }
    }
}