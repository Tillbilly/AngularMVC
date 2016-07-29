using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCApp.RefData;
using MVCApp.Service;

namespace MVCApp.Controllers
{
    public class SfiaRefController : ApiController
    {
        //Leave DI for the time being
        private IReferenceDataImportService _dataService = new ReferenceDataService();

        private List<SFIACategory> refData = null;

        // GET: api/SfiaRef
        public List<SFIACategory> Get()
        {
            if (refData == null)
            {
                refData = _dataService.GetSfia6ReferenceData();
            }
            return refData;
        }

       
    }
}
