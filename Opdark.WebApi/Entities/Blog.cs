using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }


    }
}
