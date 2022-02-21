using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.DTOs.Quote
{
    public class OutgoingQuoteDto
    {
        public Guid BioId { get; set; }

        [Required]
        public string Content { get; set; }
        [Required]
        public string Author { get; set; }
        public string Type { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
