using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.DTOs.Skill
{
    public class IncomingSkillDto
    {
        public Guid BioId { get; set; }

        [Required]
        public string Firstname { get; set; }
        [Required]
        public int ProficiencyPercentage { get; set; }
        [Required]
        public string Description { get; set; }
        public int NumberOfProjectUsedIn { get; set; }
    }
}
