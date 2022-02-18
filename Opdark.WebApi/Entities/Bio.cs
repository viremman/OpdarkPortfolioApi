using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Entities
{
    public class Bio : BaseEntity
    {
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Description { get; set; }
        public string Hobby { get; set; }





    }
}
