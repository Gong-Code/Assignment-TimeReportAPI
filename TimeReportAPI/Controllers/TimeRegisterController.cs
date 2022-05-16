using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;

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
                .Select(_mapper.Map<TimeRegister, TimeRegisterDTO>)
                .ToList();

            return Ok(timeRegisterDb);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var timeRegisterDb = _context.TimeRegisters.FirstOrDefault(c => c.Id == id);
            if (timeRegisterDb == null)
            {
                return NotFound();
            }

            _mapper.Map<TimeRegisterDTO>(timeRegisterDb);

            return Ok(timeRegisterDb);
        }

        [HttpPost]
        public IActionResult New(TimeRegisterDTO timeRegister)
        {
            var timeRegisterDb = _mapper.Map<TimeRegister>(timeRegister);

            var timeRegisterDto = _mapper.Map<TimeRegisterDTO>(timeRegisterDb);

            _context.TimeRegisters.Add(timeRegisterDb);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = timeRegisterDto.Id }, timeRegisterDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update(Guid id, TimeRegisterEditDTO timeRegisterEditDto)
        {
            var timeRegisterDb = _context.TimeRegisters.FirstOrDefault(c => c.Id == id);
            if (timeRegisterDb == null)
            {
                return NotFound();
            }

            _mapper.Map(timeRegisterEditDto, timeRegisterDb);

            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var timeRegisterDb = _context.TimeRegisters.FirstOrDefault(c => c.Id == id);
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
