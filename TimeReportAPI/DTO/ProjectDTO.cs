using TimeReportAPI.Data;

namespace TimeReportAPI.DTO
{
    public class ProjectDTO
    {
        public Guid Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }

        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
