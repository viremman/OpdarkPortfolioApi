using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Entities
{

    public class Bio : BaseEntity
    {

        public Bio()
        {
            Projects = new HashSet<Project>();
            Contacts = new HashSet<Contact>();
            Blogs = new HashSet<Blog>();
            Skills = new HashSet<Skill>();
            Services = new HashSet<Service>();

        }


        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Description { get; set; }
        public string Hobby { get; set; }





        public ICollection<Project> Projects { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Service> Services { get; set; }

    }
}
