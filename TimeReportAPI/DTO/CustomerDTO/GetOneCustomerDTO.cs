using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO.CustomerDTO
{
    public class GetOneCustomerDTO
    {
        [Required]
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        
    }
}
