using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.DTOs.Project
{
    public class IncomingProjectDto
    {
        public Guid BioId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ProjectRole { get; set; }
        [Required]
        public string ProjectUrl { get; set; }
        public string ConfidentialityLevel { get; set; }
        public string Duration { get; set; }
        public string Image { get; set; }
    }
}
