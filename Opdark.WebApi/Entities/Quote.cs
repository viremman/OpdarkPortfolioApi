using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Entities
{
    public class Quote : BaseEntity
    {
        public string Content { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }

    }
}
