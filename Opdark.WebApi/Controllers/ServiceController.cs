using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opdark.WebApi.Data;
using Opdark.WebApi.DTOs.Service;
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
    public class ServiceController : ControllerBase
    {
        private readonly ServiceData _serviceData;
        private readonly IMapper _mapper;
        public ServiceController(ServiceData serviceData, IMapper mapper)
        {
            _serviceData = serviceData;
            _mapper = mapper;
        }
        // GET: api/<ServiceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _serviceData.GetServicesAsync();

            return Ok(result);
        }

        // GET api/<ServiceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _serviceData.GetServiceAsync(id);

            return Ok(result);
        }

        // POST api/<ServiceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomingServiceDto incomingServiceDto)
        {
            if (ModelState.IsValid)
            {
                var service = _mapper.Map<Service>(incomingServiceDto);
                service.Id = Guid.NewGuid();
                var result = await _serviceData.CreateServiceAsync(service);
                return Ok(result);

            }
            return UnprocessableEntity(ModelState);
        }

        // PUT api/<ServiceController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] OutgoingServiceDto outgoingServiceDto)
        {
            if (ModelState.IsValid)
            {
                var service = _mapper.Map<Service>(outgoingServiceDto);
                var result = await _serviceData.UpdateServiceAsync(service);

                return Ok(result);

            }
            return UnprocessableEntity(ModelState);
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletable = await _serviceData.GetServiceAsync(id);
            if (deletable != null)
            {
                await _serviceData.DeleteServiceAsync(deletable);

                return Ok();
            }

            return NotFound();
        }
    }
}
