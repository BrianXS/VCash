using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Entities
{
    public class OfficeFund
    {
        [Key, Column(Order = 0)]
        public int OfficeId { get; set; }
        public Office Office { get; set; }

        [Key, Column(Order = 1)]
        public Office FundId { get; set; }
        public Office Fund { get; set; }
    }
}