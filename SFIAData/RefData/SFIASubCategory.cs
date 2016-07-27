using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFIAData.RefData
{
    public class SFIASubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SFIASkill> Skills { get; set; } = new List<SFIASkill>();

    }
}
