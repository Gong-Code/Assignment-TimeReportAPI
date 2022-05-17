using System.ComponentModel.DataAnnotations;
using TimeReportAPI.DTO.ProjectDTO;

namespace TimeReportAPI.DTO.CustomerDTO
{
    public class GetOneCustomerDTO
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public List<GetOneProjectDTO> Projects { get; set; } = new List<GetOneProjectDTO>();

    }
}
