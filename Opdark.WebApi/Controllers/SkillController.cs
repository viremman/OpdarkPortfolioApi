using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opdark.WebApi.Data;
using Opdark.WebApi.DTOs.Skill;
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
    public class SkillController : ControllerBase
    {
        private readonly SkillData _skillData;
        private readonly IMapper _mapper;
        public SkillController(SkillData skillData, IMapper mapper)
        {
            _skillData = skillData;
            _mapper = mapper;
        }
        // GET: api/<SkillController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _skillData.GetSkillsAsync();

            return Ok(result);
        }

        // GET api/<SkillController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _skillData.GetSkillAsync(id);

            return Ok(result);
        }

        // POST api/<SkillController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomingSkillDto incomingSkillDto)
        {
            if(ModelState.IsValid)
            {
                var skill = _mapper.Map<Skill>(incomingSkillDto);
                skill.Id = Guid.NewGuid();
                var result = await _skillData.CreateSkillAsync(skill);

                return Ok(result);

            }
            return UnprocessableEntity(ModelState);
        }

        // PUT api/<SkillController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] OutgoingSkillDto outgoingSkillDto)
        {
            if (ModelState.IsValid) 
            {
                var skill = _mapper.Map<Skill>(outgoingSkillDto);
                var result = await _skillData.UpdateSkillAsync(skill);

                return Ok(result);

            }
            return UnprocessableEntity(ModelState);
        }


        // DELETE api/<SkillController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletable = await _skillData.GetSkillAsync(id);
            if (deletable != null)
            {
                await _skillData.DeleteSkillAsync(deletable);

                return Ok();
            }

            return NotFound();
        }
    }
}
