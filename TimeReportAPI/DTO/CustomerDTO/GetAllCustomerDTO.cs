using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO
{
    public class GetAllCustomerDTO
    {
        public int CustomerId { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
    }
}
