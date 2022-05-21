namespace TimeReportAPI.DTO.ProjectDTO
{
    public class GetOneProjectDTO
    {
        public int ProjectId { get; set; }
        public int CustomerId { get; set; }
        public string ProjectName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
