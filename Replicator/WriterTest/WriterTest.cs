using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writer;
using Writer.Services;

namespace WriterTest
{
    [TestFixture]
    public class WriterTest
    {
        [Test]
        public void Writer_EmptyConstructor_ReturnsDefaults()
        {
            var result = new Writer.Writer();

            Assert.AreEqual(result.ID, 0);
        }


        //Writer constructor has only one parameter (ID)
        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(null)]
        [TestCase(int.MinValue)]
        [TestCase(int.MaxValue)]
        public void Writer_ConstructorWithParameters_ReturnsGivenValues(int id)
        {
            var result = new Writer.Writer(id);

            Assert.AreEqual(result.ID, id);
        }
    }
}
