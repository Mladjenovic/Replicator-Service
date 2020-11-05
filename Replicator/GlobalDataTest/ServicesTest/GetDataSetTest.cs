using Global_Data.Models;
using Global_Data.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDataTest.ServicesTest
{
    [TestFixture]
    public class GetDataSetTest
    {
        [Test]
        [TestCase(Code.CODE_ANALOG, Code.CODE_DIGITAL)]
        [TestCase(Code.CODE_SINGLENODE, Code.CODE_MULTIPLENODE)]
        [TestCase(Code.CODE_CONSUMER, Code.CODE_SOURCE)]
        [TestCase(Code.CODE_CUSTOM, Code.CODE_LIMITSET)]
        public void GetDataSetTest_GivenValidCodes_ReturnsDataSetForValidGivenCodes(Code code1, Code code2)
        {
            var result = GetDataSet.GetDatasetForCode(code1, code2);

            Assert.IsTrue(result != 0);
        }

        [Test]
        [TestCase(Code.CODE_ANALOG, Code.CODE_ANALOG)]
        [TestCase(Code.CODE_LIMITSET, Code.CODE_DIGITAL)]
        public void GetDataSetTest_GivenInValidCodes_ReturnsDataSetForInValidGivenCodes(Code code1, Code code2)
        {
            var result = GetDataSet.GetDatasetForCode(code1, code2);

            Assert.IsTrue(result == 0);
        }
    }
}
