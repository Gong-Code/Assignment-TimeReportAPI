using TimeReportAPI.Data;

namespace TimeReportAPI.DTO
{
    public class GetAllProjectDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }

    }
}
