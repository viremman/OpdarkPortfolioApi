using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Entities
{
    public class Blog : BaseEntity
    {

        public Blog()
        {
            Comments = new HashSet<Comment>();
        }

        public Guid BioId { get; set; }
        public Bio Bio { get; set; }



        public string Title { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }
        

        public ICollection<Comment> Comments{ get; set; }
    }
}
