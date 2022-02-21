using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opdark.WebApi.Data;
using Opdark.WebApi.DTOs.Bio;
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
    public class BioController : ControllerBase
    {
        private readonly BioData _bioData;
        private readonly IMapper _mapper;
        public BioController(BioData bioData, IMapper mapper)
        {
            _bioData = bioData;
            _mapper = mapper;
        }
        // GET: api/<BioController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _bioData.GetBiosAsync();

            return Ok(result);
        }

        // GET api/<BioController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _bioData.GetBioAsync(id);

            return Ok(result);
        }

        // POST api/<BioController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomingBioDto incomingBioDto)
        {
            if (ModelState.IsValid)
            {
                var bio = _mapper.Map<Bio>(incomingBioDto);
                bio.Id = Guid.NewGuid();
                var result = await _bioData.CreateBioAsync(bio);

                return Ok(result);
            }

            return UnprocessableEntity(ModelState);
        }

        // PUT api/<BioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id,[FromBody] OutgoingBioDto outgoingBioDto)
        {
            if (ModelState.IsValid)
            {
                var bio = _mapper.Map<Bio>(outgoingBioDto);
                var result = await _bioData.UpdateBioAsync(bio);
                return Ok(result);

            }
            return UnprocessableEntity(ModelState);
        }

        // DELETE api/<BioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletable = await _bioData.GetBioAsync(id);
            if (deletable != null)
            {
                await _bioData.DeleteBioAsync(deletable);

                return Ok();
            }

            return NotFound();
        }
    }
}
