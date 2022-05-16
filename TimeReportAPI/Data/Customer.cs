namespace TimeReportAPI.Data
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Project> Projects { get; set; }
    }
}
