using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opdark.WebApi.Data;
using Opdark.WebApi.DTOs.Blog;
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
    public class BlogController : ControllerBase
    {
        private readonly BlogData _blogData;
        private readonly IMapper _mapper;
        public BlogController(BlogData blogData, IMapper mapper)
        {
            _blogData = blogData;
            _mapper = mapper;
        }
        // GET: api/<BlogController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _blogData.GetBlogsAsync();

            return Ok(result);
        }

        // GET api/<BlogController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _blogData.GetBlogAsync(id);

            return Ok(result);
        }

        // POST api/<BlogController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomingBlogDto incomingBlogDto)
        {
            if (ModelState.IsValid) 
            {

                var blog = _mapper.Map<Blog>(incomingBlogDto);
                blog.Id = Guid.NewGuid();
                var result = await _blogData.CreateBlogAsync(blog);

                return Ok(result);
            }
            return UnprocessableEntity(ModelState);
        }

        // PUT api/<BlogController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] OutgoingBlogDto outgoingBlogDto)
        {
            if (ModelState.IsValid) 
            {
                var blog = _mapper.Map<Blog>(outgoingBlogDto);
                var result = await _blogData.UpdateBlogAsync(blog);
                return Ok(result);

            }
            return UnprocessableEntity(ModelState);
        }

        // DELETE api/<BlogController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletable = await _blogData.GetBlogAsync(id);
            if (deletable != null)
            {
                await _blogData.DeleteBlogAsync(deletable);

                return Ok();
            }

            return NotFound();
        }
    }

  }

