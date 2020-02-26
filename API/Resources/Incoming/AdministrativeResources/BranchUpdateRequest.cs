namespace API.Resources.Incoming.AdministrativeResources
{
    public class BranchUpdateRequest
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}