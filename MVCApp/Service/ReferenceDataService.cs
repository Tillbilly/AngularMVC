using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCApp.Properties;
using MVCApp.RefData;

namespace MVCApp.Service
{
    public class ReferenceDataService : IReferenceDataImportService
    {
        public List<SFIACategory> GetSfia6ReferenceData()
        {
            return ImportReferenceDataFromFile(Resources.sfiaskills_6_3_en_1);
        }

        public List<SFIACategory> ImportReferenceDataFromFile(string csvResourceString)
        {
            string[] lines = csvResourceString.Split('\n');
            List<SFIACategory> categoryList = new List<SFIACategory>();
            //Id counters;
            CounterIdHelper idHelper = new CounterIdHelper();
            foreach (var ln in lines)
            {
                List<string> pieces = GetLinePieces(ln);
                if (pieces.Count == 0)
                {
                    continue;
                }
                if (pieces[0] == "Version")
                {
                    continue;
                }
                if (pieces.Count != 8)
                {
                    Console.WriteLine(pieces.Count + " not equal to 8 - check the data - exiting!");
                    Console.WriteLine(ln);
                    break;
                }
                ProcessPieces(pieces, categoryList, idHelper);
            }
            return categoryList;
        }

        public List<string> GetLinePieces(string line)
        {
            //We can't just split on comma, because there are comma's in the description fields
            List<string> pieces = new List<string>();
            Boolean openQuote = false;
            string str = "";
            foreach (char ch in line.ToCharArray())
            {
                if (ch == '\n')
                {
                    pieces.Add(str);
                    str = "";
                    break;
                }
                else if (ch == ',')
                {
                    if (openQuote)
                    {
                        str += ch;
                    }
                    else
                    {
                        pieces.Add(str);
                        str = "";
                    }
                }
                else if (ch == '"') //We need to remove quotes from the description Strings
                {
                    openQuote = !openQuote;
                }
                else
                {
                    str += ch;
                }
            }
            if (str.Length > 0)
            {
                pieces.Add(str);
            }
            return pieces;
        }

        public void ProcessPieces(List<string> pieces, List<SFIACategory> categoryList, CounterIdHelper idHelper)
        {
            string categoryName = pieces[ColNdx.Category];
            SFIACategory sfiaCategory = GetSfiaCategory(categoryName, categoryList, idHelper);
            string subCategoryName = pieces[ColNdx.Subcategory];
            SFIASubCategory sfiaSubCategory = GetSfiaSubCategory(subCategoryName, sfiaCategory, idHelper);
            string skillName = pieces[ColNdx.Skill];
            string skillDescription = pieces[ColNdx.Description];
            string skillCode = pieces[ColNdx.Code];
            SFIASkill sfiaSkill = GetSfiaSkill(skillName, skillDescription, skillCode, sfiaSubCategory, idHelper);
            string level = pieces[ColNdx.Level];
            string levelDescription = pieces[ColNdx.LevelDescription];
            int levelInt = Convert.ToInt32(level);
            SFIASkillLevel skillLevel = new SFIASkillLevel()
            {
                Id = idHelper.GetNextSkillLevelId(),
                Level = levelInt,
                Description = levelDescription
            };
            sfiaSkill.SkillLevels.Add(skillLevel);
        }

        //We will assume that all the data is nicely ordered for the time being . . . . 
        public SFIACategory GetSfiaCategory(String category, List<SFIACategory> categoryList, CounterIdHelper idHelper)
        {
            if (categoryList.Count > 0)
            {
                SFIACategory lastCategory = categoryList[categoryList.Count - 1];
                if (lastCategory.Name == category)
                {
                    return lastCategory;
                }
            }
            SFIACategory sfiaCategory = new SFIACategory()
            {
                Name = category,
                Id = idHelper.GetNextCategoryId()
            };
            categoryList.Add(sfiaCategory);
            return sfiaCategory;
        }

        public SFIASubCategory GetSfiaSubCategory(string subCategoryName, SFIACategory sfiaCategory, CounterIdHelper idHelper)
        {
            if (sfiaCategory.SubCategories.Count > 0)
            {
                SFIASubCategory lastSubCategory = sfiaCategory.SubCategories[sfiaCategory.SubCategories.Count - 1];
                if (subCategoryName == lastSubCategory.Name)
                {
                    return lastSubCategory;
                }
            }
            SFIASubCategory subCategory = new SFIASubCategory()
            {
                Id = idHelper.GetNextSubCategoryId(),
                Name = subCategoryName
            };
            sfiaCategory.SubCategories.Add(subCategory);
            return subCategory;
        }

        public SFIASkill GetSfiaSkill(string skillName, string skillDescription, string skillCode, SFIASubCategory sfiaSubCategory, CounterIdHelper idHelper)
        {
            if (sfiaSubCategory.Skills.Count > 0)
            {
                SFIASkill lastSkill = sfiaSubCategory.Skills[sfiaSubCategory.Skills.Count - 1];
                if (lastSkill.Code == skillCode)
                {
                    return lastSkill;
                }
            }
            SFIASkill skill = new SFIASkill()
            {
                Id = idHelper.GetNextSkillId(),
                Name = skillName,
                Code = skillCode,
                Description = skillDescription
            };
            sfiaSubCategory.Skills.Add(skill);
            return skill;
        }
    }

    public class CounterIdHelper
    {
        public int CategoryId { get; set; } = 0;
        public int SubCategoryId { get; set; } = 0;
        public int SkillId { get; set; } = 0;
        public int SkillLevelId { get; set; } = 0;

        public int GetNextCategoryId()
        {
            return ++CategoryId;
        }

        public int GetNextSubCategoryId()
        {
            return ++SubCategoryId;
        }

        public int GetNextSkillId()
        {
            return ++SkillId;
        }

        public int GetNextSkillLevelId()
        {
            return ++SkillLevelId;
        }
    }

    public static class ColNdx
    {
        public const int Version = 0;
        public const int Category = 1;
        public const int Subcategory = 2;
        public const int Skill = 3;
        public const int Description = 4;
        public const int Code = 5;
        public const int Level = 6;
        public const int LevelDescription = 7;
    }
}