using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebAPICoreMiniProject.Models;

namespace WebAPICoreMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private ILogger<PeopleController> _logger;

        private readonly AddressBookContext _context;

        public PeopleController(ILogger<PeopleController> logger, AddressBookContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonModel>>> Get()
        {
            var people = await _context.People.ToListAsync();
            return people;
        }

        // GET: api/People/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<PersonModel>> Get(int id)
        {
            PersonModel person = await _context.People
                                               .Where(s => s.Id == id)
                                               .Include(s => s.Addresses)
                                               .FirstAsync();

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // POST: api/People
        [HttpPost]
        public async Task<ActionResult<PersonModel>> Post([FromBody] PersonModel person)
        {
            if (ModelState.IsValid == true)
            {
                _context.People.Add(person);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonModel person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var person = await _context.People.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            _context.People.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
