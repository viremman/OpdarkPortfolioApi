using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opdark.WebApi.Data;
using Opdark.WebApi.DTOs.Comment;
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
    public class CommentController : ControllerBase
    {
        private readonly CommentData _commentData;
        private readonly IMapper _mapper;

        public CommentController(CommentData commentData, IMapper mapper)
        {
            _commentData = commentData;
            _mapper = mapper;

        }
        // GET: api/<CommentController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _commentData.GetCommentsAsync();

            return Ok(result);
        }

        // GET api/<CommentController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _commentData.GetCommentAsync(id);

            return Ok(result);
        }

        // POST api/<CommentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomingCommentDto incomingCommentDto)
        {
            if (ModelState.IsValid)
            {
                var comment = _mapper.Map<Comment>(incomingCommentDto);
                comment.Id = Guid.NewGuid();
                var result = await _commentData.CreateCommentAsync(comment);

                return Ok(result);

            }
            return UnprocessableEntity(ModelState);
        }


        // PUT api/<CommentController>/5
        [HttpPut("{id}")]

        public async Task<IActionResult> Put(Guid id, [FromBody] OutgoingCommentDto outgoingCommentDto)
        {
            if (ModelState.IsValid)
            {
                var comment = _mapper.Map<Comment>(outgoingCommentDto);
                var result = await _commentData.UpdateCommentAsync(comment);

                return Ok(result);

            }
            return UnprocessableEntity(ModelState);
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletable = await _commentData.GetCommentAsync(id);
            if (deletable != null)
            {
                await _commentData.DeleteCommentAsync(deletable);

                return Ok();
            }

            return NotFound();
        }
    }
}
