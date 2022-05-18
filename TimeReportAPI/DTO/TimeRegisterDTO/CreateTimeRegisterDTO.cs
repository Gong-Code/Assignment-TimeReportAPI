namespace TimeReportAPI.DTO.TimeRegisterDTO
{
    public class CreateTimeRegisterDTO
    {
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public int ProjectId { get; set; }

    }
}
