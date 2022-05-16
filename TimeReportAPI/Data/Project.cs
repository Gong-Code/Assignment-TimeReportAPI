namespace TimeReportAPI.Data;

public class Project
{
    public Guid Id { get; set; }
    public string ProjectName { get; set; }
    public string Description { get; set; }

    public List<TimeRegister> TimeRegisters { get; set; } = new List<TimeRegister>();
}