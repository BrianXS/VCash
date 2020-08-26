using API.Enums.ATM;

namespace API.Entities.AtmMaintenance
{
    public class AtmModule
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public ProductLine ProductLine { get; set; }
        public Brand Platform { get; set; }
    }
}