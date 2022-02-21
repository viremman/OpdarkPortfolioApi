using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Entities
{
    public class Service : BaseEntity
    {
        public Service()
        {
            Bios = new HashSet<Bio>();
        }

        public string Name { get; set; }
        public string Description { get; set; }


        public ICollection<Bio> Bios { get; set; }
    }
   
}
