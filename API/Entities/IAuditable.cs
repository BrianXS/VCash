using System;

namespace API.Entities
{
    public interface IAuditable
    { 
        string UpdatedBy { get; set; }
        DateTime UpdatedOn { get; set; }
    }
}