using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.DTOs.Quote
{
    public class IncomingQuoteDto
    {
        public Guid BioId { get; set; }

        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        public string Type { get; set; }
    }
}
