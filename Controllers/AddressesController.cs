using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPICoreMiniProject.Models;

namespace WebAPICoreMiniProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private ILogger<AddressesController> _logger;
        private AddressBookContext _context;

        public AddressesController(ILogger<AddressesController> logger, AddressBookContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<AddressModel>> Get()
        {
            var addresses = _context.Addresses.ToList();
            return addresses;
        }

        [HttpPost]
        public async Task<ActionResult<AddressModel>> Post([FromBody] AddressModel address)
        {
            if (ModelState.IsValid == true)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(Get), new { id = address.Id }, address);
        }
    }
}