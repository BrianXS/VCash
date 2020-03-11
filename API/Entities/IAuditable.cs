namespace API.Entities
{
    public interface IAuditable
    { 
        string UpdatedBy { get; set; }
    }
}