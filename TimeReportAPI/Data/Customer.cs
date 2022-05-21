namespace TimeReportAPI.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}
