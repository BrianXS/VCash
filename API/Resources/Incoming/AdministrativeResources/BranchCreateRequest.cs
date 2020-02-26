namespace API.Resources.Incoming.AdministrativeResources
{
    public class BranchCreateRequest
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}