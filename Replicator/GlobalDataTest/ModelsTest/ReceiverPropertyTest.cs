using Global_Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDataTest.ModelsTest
{
    [TestFixture]
    public class ReceiverPropertyTest
    {
        [Test]
        //[TestCase()]
        public void ReceiverProperty_EmptyConstructor_ReturnsDefaults()
        {
            var result = new ReceiverProperty();

            Assert.AreEqual(result.Code, Code.CODE_ANALOG);
            Assert.AreEqual(result.ReceiverValue, 0);
        }

        [Test]
        [TestCase(Code.CODE_ANALOG, 0)]
        [TestCase(Code.CODE_SOURCE, -20)]
        [TestCase(Code.CODE_ANALOG, null)]
        [TestCase(null, 0)]
        [TestCase(Code.CODE_DIGITAL, int.MinValue)]
        [TestCase(Code.CODE_DIGITAL, int.MaxValue)]
        public void ReceiverProperty_ConstructorWithParameters_ReturnsGivenValues(Code code, int receiverValue)
        {
            var result = new ReceiverProperty(code, receiverValue);

            Assert.AreEqual(result.Code, code);
            Assert.AreEqual(result.ReceiverValue, receiverValue);
        }
    }
}
