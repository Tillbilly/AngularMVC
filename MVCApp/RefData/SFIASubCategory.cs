using System.Collections.Generic;

namespace MVCApp.RefData
{
    public class SFIASubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SFIASkill> Skills { get; set; } = new List<SFIASkill>();

    }
}
