using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCApp.RefData;

namespace MVCApp.Service
{
    public interface IReferenceDataImportService
    {
        List<SFIACategory> GetSfia6ReferenceData();

        List<SFIACategory> ImportReferenceDataFromFile(String csvResourceString);
    }
}
