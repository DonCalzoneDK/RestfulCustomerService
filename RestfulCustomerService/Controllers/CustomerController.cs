using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestfulCustomerService.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestfulCustomerService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private List<Customer> _custList;
        public CustomerController()
        {
            _custList = ListCustomer.customers;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public List<Customer> Get()
        {
            return _custList;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = GetCustomer(id);
            if (customer == null)
            {
                return NotFound(new { message = "Id not found" });
            }
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (!CustomerExists(customer.Id))
            {
                _custList.Add(customer);
                return CreatedAtAction("Get", new { id = customer.Id }, customer);
            }
            else
            {
                return NotFound(new { message = "Id is duplicate" });
            }
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Customer newCustomer)
        {
            if (id != newCustomer.Id)
            {
                return BadRequest();
            }
            var currentCustomer = GetCustomer(id);

            if (currentCustomer != null)
            {
                currentCustomer.Id = newCustomer.Id;
                currentCustomer.FirstName = newCustomer.FirstName;
                currentCustomer.LastName = newCustomer.LastName;
                currentCustomer.Year = newCustomer.Year;
            }
            else
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = GetCustomer(id);

            if (customer != null)
            {
                _custList.Remove(customer);
            }
            else
            {
                return NotFound();
            }
            return Ok(customer);
        }

        public Customer GetCustomer(int id)
        {
            var customer = _custList.FirstOrDefault(e => e.Id == id);
            return customer;
        }
        private bool CustomerExists(long id)
        {
            return _custList.Any(e => e.Id == id);
        }
    }
}
