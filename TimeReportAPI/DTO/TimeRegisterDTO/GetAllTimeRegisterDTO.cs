namespace TimeReportAPI.DTO
{
    public class GetAllTimeRegisterDTO
    {
        public int TimeRegisterId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
    }
}
