using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;

namespace TimeReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProjectController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var projects = _context.Projects
                .Include(t => t.TimeRegisters)
                .Select(_mapper.Map<Project, ProjectDTO>)
                .ToList();
            
            return Ok(projects);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var projectDb = _context.Projects.Include(t => t.TimeRegisters).FirstOrDefault(c => c.Id == id);
            if (projectDb == null)
            {
                return NotFound();
            }

            _mapper.Map<ProjectDTO>(projectDb);

            return Ok(projectDb);
        }

        [HttpPost]
        public IActionResult New(ProjectDTO project)
        {
            var projectDb = _mapper.Map<Project>(project);

            var projectDto = _mapper.Map<ProjectDTO>(projectDb);

            _context.Projects.Add(projectDb);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = projectDto.Id }, projectDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update(Guid id, ProjectEditDTO projectEditDto)
        {
            var projectDb = _context.Projects.FirstOrDefault(c => c.Id == id);
            if (projectDb == null)
            {
                return NotFound();
            }

            _mapper.Map(projectEditDto, projectDb);

            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var projectDb = _context.Projects.FirstOrDefault(c => c.Id == id);
            if (projectDb == null)
            {
                return NotFound();
            }

            _context.Remove(projectDb);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
