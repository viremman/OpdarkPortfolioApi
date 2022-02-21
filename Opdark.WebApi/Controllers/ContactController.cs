using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opdark.WebApi.Data;
using Opdark.WebApi.DTOs.Contact;
using Opdark.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Opdark.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactData _contactData;
        private readonly IMapper _mapper;
        public ContactController(ContactData contactData, IMapper mapper)
        {
            _contactData = contactData;
            _mapper = mapper;
        }
        // GET: api/<ContactController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _contactData.GetContactsAsync();

            return Ok(result);
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _contactData.GetContactAsync(id);

            return Ok(result);
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomingContactDto incomingContactDto)
        {
            if (ModelState.IsValid) 
            {
                var contact = _mapper.Map<Contact>(incomingContactDto);
                contact.Id = Guid.NewGuid();
                var result = await _contactData.CreateContactAsync(contact);

                return Ok(result);

            }
            return UnprocessableEntity(ModelState);

        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] OutgoingContactDto outgoingContactDto)
        {
            if (ModelState.IsValid) 
            {
                var contact = _mapper.Map<Contact>(outgoingContactDto);
                var result = await _contactData.UpdateContactAsync(contact);

                return Ok(result);

            }

            return UnprocessableEntity(ModelState);
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletable = await _contactData.GetContactAsync(id);
            if (deletable != null)
            {
                await _contactData.DeleteContactAsync(deletable);

                return Ok();
            }

            return NotFound();
        }
    }
}
