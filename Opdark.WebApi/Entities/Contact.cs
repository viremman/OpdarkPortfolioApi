using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Entities
{
    public class Contact : BaseEntity
    {
        public Guid BioId { get; set; }
        public Bio Bio { get; set; }



        public string Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        
    }
}
