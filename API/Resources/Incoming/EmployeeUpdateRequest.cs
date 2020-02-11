using System;
using System.ComponentModel.DataAnnotations;
using API.Enums;

namespace API.Resources.Incoming
{
    public class EmployeeUpdateRequest
    {
        [Required]
        public string Names { get; set; }
        
        [Required]
        public string FirstLastName { get; set; }
        
        [Required]
        public string SecondLastName { get; set; }
        
        [Required]
        public string Code { get; set; }
        
        [Required]
        public string Picture { get; set; }
        
        [Required]
        public string Sign { get; set; }
        
        [Required]
        public Title Title { get; set; }

        [Required]
        public PersonalDocumentType DocumentType { get; set; }
        
        [Required]
        public string DocumentDetails { get; set; }
        
        [Required]
        public string Document { get; set; }
        
        [Required]
        public EmployeeStatus EmployeeStatus { get; set; }
        
        [Required]
        public Rhesus Rhesus { get; set; }
        
        [Required]
        public DateTime From { get; set; }
        
        [Required]
        public DateTime Until { get; set; }
        
        [Required]
        public BusinessUnit Unit { get; set; }
        
        [Required]
        public int BranchId { get; set; }
    }
}