using System;

namespace API.Entities.Administrative
{
    public class BusinessType : IAuditable
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}