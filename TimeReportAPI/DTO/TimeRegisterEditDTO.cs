namespace TimeReportAPI.DTO
{
    public class TimeRegisterEditDTO
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
    }
}
