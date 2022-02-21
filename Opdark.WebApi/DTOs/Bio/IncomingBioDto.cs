using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.DTOs.Bio
{
    public class IncomingBioDto
    {
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
    }
}
