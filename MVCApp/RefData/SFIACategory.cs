using System.Collections.Generic;

namespace MVCApp.RefData
{
    public class SFIACategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SFIASubCategory> SubCategories { get; set; } = new List<SFIASubCategory>();

    }
}
