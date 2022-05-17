using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO.CustomerDTO
{
    public class CreateCustomerDTO
    {
        [MaxLength(30)]
        public string Name { get; set; }

    }
}
