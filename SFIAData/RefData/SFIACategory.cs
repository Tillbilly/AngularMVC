using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFIAData.RefData
{
    public class SFIACategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<SFIASubCategory> SubCategories { get; set; } = new List<SFIASubCategory>();

    }
}
