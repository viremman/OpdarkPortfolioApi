using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Opdark.WebApi.Data;
using Opdark.WebApi.DTOs.Quote;
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
    public class QuoteController : ControllerBase
    {
        private readonly QuoteData _quoteData;
        private readonly IMapper _mapper;
        public QuoteController(QuoteData quoteData, IMapper mapper)
        {
            _quoteData = quoteData;
            _mapper = mapper;
        }
        // GET: api/<QuoteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _quoteData.GetQuotesAsync();

            return Ok(result);
        }

        // GET api/<QuoteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _quoteData.GetQuoteAsync(id);

            return Ok(result);
        }

        // POST api/<QuoteController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IncomingQuoteDto incomingQuoteDto)
        {
            if (ModelState.IsValid)
            {
                var quote = _mapper.Map<Quote>(incomingQuoteDto);
                quote.Id = Guid.NewGuid();
                var result = await _quoteData.CreateQuoteAsync(quote);
                return Ok(result);

            }
            return UnprocessableEntity(ModelState);
        }

        // PUT api/<QuoteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] OutgoingQuoteDto outgoingQuoteDto)
        {
            if (ModelState.IsValid)
            {
                var quote = _mapper.Map<Quote>(outgoingQuoteDto);
                var result = await _quoteData.UpdateQuoteAsync(quote);

                return Ok(result);

            }
            return UnprocessableEntity(ModelState);
        }

        // DELETE api/<QuoteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deletable = await _quoteData.GetQuoteAsync(id);
            if (deletable != null)
            {
                await _quoteData.DeleteQuoteAsync(deletable);

                return Ok();
            }

            return NotFound();
        }
    }
}
