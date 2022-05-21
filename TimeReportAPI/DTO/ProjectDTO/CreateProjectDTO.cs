using System.ComponentModel.DataAnnotations;

namespace TimeReportAPI.DTO.ProjectDTO
{
    public class CreateProjectDTO
    {
        [Required(ErrorMessage = "You should provide a project name value.")]
        [MaxLength(30)]
        public string ProjectName { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int CustomerId { get; set; }
    }
}
