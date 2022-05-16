using TimeReportAPI.Data;

namespace TimeReportAPI.DTO
{
    public class ProjectEditDTO
    {
        public string ProjectName { get; set; }
        public string Description { get; set; }

        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
}
