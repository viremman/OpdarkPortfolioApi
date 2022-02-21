using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opdark.WebApi.Data;
using Opdark.WebApi.DTOs.Project;
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
    public class ProjectController : ControllerBase
   {
        private readonly ProjectData _projectData;
        private readonly IMapper _mapper;
        public ProjectController(ProjectData projectData, IMapper mapper)
        {
            _projectData = projectData;
            _mapper = mapper;
        }
        // GET: api/<ProjectController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
           var result = await _projectData.GetProjectsAsync();

            return Ok(result);
        }

        // GET api/<ProjectController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _projectData.GetProjectAsync(id);

            return Ok(result);
        }

        // POST api/<ProjectController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomingProjectDto incomingProjectDto)
        {
            if (ModelState.IsValid)
            {

                var project = _mapper.Map<Project>(incomingProjectDto);
                project.Id = Guid.NewGuid();
                var result = await _projectData.CreateProjectAsync(project);

                return Ok(result);

            }

            return UnprocessableEntity(ModelState);
        }

        // PUT api/<ProjectController>/5
        [HttpPut("{id}")]
      public async Task<IActionResult> Put(Guid id, [FromBody] OutgoingProjectDto outgoingProjectDto)
        {
            if (ModelState.IsValid)
            {
                var project = _mapper.Map<Project>(outgoingProjectDto);
                var result = await _projectData.UpdateProjectAsync(project);

                return Ok(result);
            }
            return UnprocessableEntity(ModelState);
        }


        // DELETE api/<ProjectController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
       {
           var deletable = await _projectData.GetProjectAsync(id);
           if (deletable != null)
            {
                await _projectData.DeleteProjectAsync(deletable);

                return Ok();
           }

          return NotFound();
        }
    }
}
