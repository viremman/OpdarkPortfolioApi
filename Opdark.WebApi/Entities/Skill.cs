using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Entities
{
    public class Skill : BaseEntity
    {
        public Skill()
        {
            Bios = new HashSet<Bio>();
        }
        public string Firstname { get; set; }
        public int ProficiencyPercentage { get; set; }
        public string Description { get; set; }
        public int NumberOfProjectUsedIn { get; set; }



        public ICollection<Bio> Bios { get; set; }
    }
}
