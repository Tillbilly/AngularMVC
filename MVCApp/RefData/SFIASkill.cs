using System.Collections.Generic;

namespace MVCApp.RefData
{
    public class SFIASkill
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SFIASkillLevel> SkillLevels { get; set; } = new List<SFIASkillLevel>();

    }
}
