using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;
using TimeReportAPI.DTO.TimeRegisterDTO;

namespace TimeReportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeRegisterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TimeRegisterController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var timeRegisterDb = _context.TimeRegisters
                .Include(p => p.Project)
                .Select(_mapper.Map<TimeRegister, GetAllTimeRegisterDTO>)
                .ToList();

            return Ok(timeRegisterDb);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var timeRegisterDb = _context.TimeRegisters.Include(p => p.Project).FirstOrDefault(c => c.TimeRegisterId == id);
            if (timeRegisterDb == null)
            {
                return NotFound();
            }

            var timeRegister = _mapper.Map<GetAllTimeRegisterDTO>(timeRegisterDb);

            return Ok(timeRegister);
        }

        [HttpPost]
        public IActionResult New(CreateTimeRegisterDTO createTimeRegister)
        {
            if (ModelState.IsValid)
            {
                var timeRegister = _mapper.Map<TimeRegister>(createTimeRegister);

                if (timeRegister.Minutes <= 0)
                {
                    return BadRequest("Invalid minutes.");
                }

                if (timeRegister.Hours <= 0)
                {
                    return BadRequest("Invalid hours.");
                }

                timeRegister.Date = DateTime.Now;
               
                var project = _context.Projects.Find(createTimeRegister.ProjectId);

                if (project == null)
                {
                    return NotFound("Project not found.");
                }

                project.TimeRegisters.Add(timeRegister);

                _context.SaveChanges();

                var timeRegisterDto = _mapper.Map<GetOneTimeRegisterDTO>(timeRegister);

                return CreatedAtAction(nameof(GetById), new { id = timeRegister.TimeRegisterId }, timeRegisterDto);
            }

            return BadRequest();

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateTimeRegisterDTO timeRegisterEditDto)
        {
            if (ModelState.IsValid)
            {
                var timeRegisterDb = _context.TimeRegisters.FirstOrDefault(c => c.TimeRegisterId == id);
                if (timeRegisterDb == null)
                {
                    return NotFound();
                }

                _mapper.Map(timeRegisterEditDto, timeRegisterDb);

                _context.SaveChanges();

                return NoContent();
            }

            return BadRequest();
           
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(int id)
        {
            var timeRegisterDb = _context.TimeRegisters.FirstOrDefault(c => c.TimeRegisterId == id);
            if (timeRegisterDb == null)
            {
                return NotFound();
            }

            _context.Remove(timeRegisterDb);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
