using System;
using API.Enums;

namespace API.Entities
{
    public class Employee : IAuditable
    {
        public int Id { get; set; }
        public string Names { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string Code { get; set; }
        public string Picture { get; set; }
        public string Sign { get; set; }
        public Title Title { get; set; }

        public PersonalDocumentType DocumentType { get; set; }
        public string DocumentDetails { get; set; }
        public string Document { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }
        public Rhesus Rhesus { get; set; }

        public DateTime From { get; set; }
        public DateTime Until { get; set; }

        public BusinessUnit Unit { get; set; }
        
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}