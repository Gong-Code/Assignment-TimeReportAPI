using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO
{
    public class UpdateCustomerDTO
    {     
        [MaxLength(30)]
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
