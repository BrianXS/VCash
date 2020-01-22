using System.Collections.Generic;

namespace API.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
    }
}