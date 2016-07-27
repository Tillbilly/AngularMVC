using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SFIADataImport;

namespace UnitTestProject1
{
    [TestClass]
    public class CsvReadTests
    {
        [TestMethod]
        public void TestReadLinePieces()
        {
            List<string> results = Program.GetLinePieces("6,fred,hello");
            Assert.AreEqual(3, results.Count);

            results = Program.GetLinePieces("6,fred,hello,\"Its amazing, and special\",Toga");
            Assert.AreEqual(5, results.Count);


        }
    }
}
