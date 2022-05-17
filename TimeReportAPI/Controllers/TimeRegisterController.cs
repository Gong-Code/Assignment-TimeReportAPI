using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
                .Select(_mapper.Map<TimeRegister, GetAllTimeRegisterDTO>)
                .ToList();

            return Ok(timeRegisterDb);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            var timeRegisterDb = _context.TimeRegisters.FirstOrDefault(c => c.TimeRegisterId == id);
            if (timeRegisterDb == null)
            {
                return NotFound();
            }

            _mapper.Map<GetAllTimeRegisterDTO>(timeRegisterDb);

            return Ok(timeRegisterDb);
        }

        [HttpPost]
        public IActionResult New(CreateTimeRegisterDTO createTimeRegister)
        {
            var timeRegister = _mapper.Map<TimeRegister>(createTimeRegister);

     

            _context.TimeRegisters.Add(timeRegister);

            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = timeRegister.TimeRegisterId}, timeRegister);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update(int id, UpdateTimeRegisterDTO timeRegisterEditDto)
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
