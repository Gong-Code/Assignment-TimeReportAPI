using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO
{
    public class UpdateCustomerDTO
    {     
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
