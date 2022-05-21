using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO.CustomerDTO
{
    public class CreateCustomerDTO
    {
        [MaxLength(20)]
        [Required(ErrorMessage = "You should provide a name value.")]
        public string Name { get; set; } = string.Empty;

    }
}
