using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;
using TimeReportAPI.DTO.ProjectDTO;

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
                .Include(p => p.Customer)
                .Select(_mapper.Map<Project, GetAllProjectDTO>)
                .ToList();
            
            return Ok(projects);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var projectDb = _context.Projects.Include(c => c.Customer).FirstOrDefault(c => c.ProjectId == id);
            if (projectDb == null)
            {
                return NotFound("Project not found.");
            }

           var project =_mapper.Map<GetAllProjectDTO>(projectDb);

            return Ok(project);
        }

        [HttpPost]
        public IActionResult New(CreateProjectDTO createProject)
        {
            if (ModelState.IsValid)
            {
                var project = _mapper.Map<Project>(createProject);
                var customer = _context.Customers.Find(createProject.CustomerId);

                if (customer == null)
                {
                    return NotFound("Customer not found.");
                }

                customer.Projects.Add(project);

                _context.SaveChanges();

                var projectDto = _mapper.Map<GetOneProjectDTO>(project);

                return CreatedAtAction(nameof(GetById), new { id = project.ProjectId }, projectDto);
            }

            return BadRequest();
           
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateProjectDTO projectEditDto)
        {
            if (ModelState.IsValid)
            {
                var projectDb = _context.Projects.FirstOrDefault(c => c.ProjectId == id);
                if (projectDb == null)
                {
                    return NotFound();
                }

                _mapper.Map(projectEditDto, projectDb);

                _context.SaveChanges();

                return NoContent();
            }

            return BadRequest();
           
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var projectDb = _context.Projects.FirstOrDefault(c => c.ProjectId == id);
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
