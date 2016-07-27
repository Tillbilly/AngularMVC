using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SFIAData.RefData;
using SFIADataImport;

namespace MVCProject.ApiControllers
{
    public class SfiaController : ApiController
    {

        private CsvProcessor _CsvProcessor = new CsvProcessor();
        // GET: api/Sfia
        public List<SFIACategory> Get()
        {
            String str = SFIADataImport.Properties.Resources.sfiaskills_6_3_en_1;
            return _CsvProcessor.DeserializeCsvFileString(str);
        }

       



        // GET: api/Sfia/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Sfia
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Sfia/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Sfia/5
        public void Delete(int id)
        {
        }
    }
}
