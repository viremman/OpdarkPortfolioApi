using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.DTOs.Bio
{
    public class OutgoingBioDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        [Required]
        public string Description { get; set; }
        public string Hobby { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
