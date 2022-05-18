namespace TimeReportAPI.DTO.TimeRegisterDTO
{
    public class GetOneTimeRegisterDTO
    {
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public int ProjectId { get; set; }
    }
}
