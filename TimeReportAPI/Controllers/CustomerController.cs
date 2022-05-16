using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;

namespace TimeReportAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //return Ok(_mapper.Map<List<CustomerDTO>>(_context.Customers));

            var customerDto = _context.Customers
                .Select(_mapper.Map<Customer, CustomerDTO>)
                .ToList();

            return Ok(customerDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var customerDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerDb == null)
            {
                return NotFound();
            }

            _mapper.Map<CustomerDTO>(customerDb);

            return Ok(customerDb);
        }

        [HttpPost]
        public IActionResult New(CustomerDTO customer)
        {
            var customerDb = _mapper.Map<Customer>(customer);
 
            var customerDto =_mapper.Map<CustomerDTO>(customerDb);

            _context.Customers.Add(customerDb);
            
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = customerDto.Id }, customerDto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult Update(Guid id, CustomerEditDTO customerEdit)
        {
            var customerDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerDb == null)
            {
                return NotFound();
            }

            _mapper.Map(customerEdit, customerDb);

            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var customerDb = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customerDb == null)
            {
                return NotFound();
            }

            _context.Remove(customerDb);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
