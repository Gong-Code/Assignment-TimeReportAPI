using System.ComponentModel.DataAnnotations;
using TimeReportAPI.Data;

namespace TimeReportAPI.DTO
{
    public class UpdateProjectDTO
    {
        [Required(ErrorMessage = "You should provide a project name value")]
        [MaxLength(30)]
        public string ProjectName { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

    }
}
