using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.Data;

public class Project
{
    public int ProjectId { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Customer? Customer { get; set; }
    public List<TimeRegister> TimeRegisters { get; set; } = new List<TimeRegister>();
}