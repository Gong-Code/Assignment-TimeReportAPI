using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeReportAPI.Data;
using TimeReportAPI.DTO;
using TimeReportAPI.DTO.CustomerDTO;

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
            var customerDto = _context.Customers
                .Select(_mapper.Map<Customer, GetAllCustomerDTO>)
                .ToList();

            return Ok(customerDto);
        }

        [HttpGet]
        [Route("{customerId}")]
        public IActionResult GetById(int customerId)
        {
            var customer = _context.Customers.Include(p => p.Projects).FirstOrDefault(c => c.CustomerId == customerId);
            if (customer == null)
            {
                return NotFound();
            }

            var result = _mapper.Map<GetOneCustomerDTO>(customer);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult New(CreateCustomerDTO createCustomer)
        {
            var customer = _mapper.Map<Customer>(createCustomer);
            
            _context.Customers.Add(customer);
            
            _context.SaveChanges();

            var customerDto = _mapper.Map<GetOneCustomerDTO>(customer);

            return CreatedAtAction(nameof(GetById), new { customer.CustomerId }, customerDto);
        }

        [HttpPut]
        [Route("{customerId}")]
        public IActionResult Update(int customerId, UpdateCustomerDTO updateCustomerDTO)
        {
            var customerDb = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
            if (customerDb == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCustomerDTO, customerDb);

            _context.SaveChanges();

            return NoContent();

        }

        [HttpDelete]
        [Route("{customerId}")]
        public IActionResult Delete(int customerId)
        {
            var customerDb = _context.Customers.FirstOrDefault(c => c.CustomerId == customerId);
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
