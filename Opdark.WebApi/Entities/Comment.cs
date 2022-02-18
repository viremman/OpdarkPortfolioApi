using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Entities
{
    public class Comment : BaseEntity
    {
        public Guid BlogId { get; set; }
        public string Comments { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }




    }
}
