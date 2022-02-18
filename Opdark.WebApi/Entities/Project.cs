using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Entities
{
    public class Project : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ProjectRole { get; set; }
        public string ProjectUrl { get; set; }
        public string ConfidentialityLevel { get; set; }
        public string Duration { get; set; }
        public string Image { get; set; }







    }
}
