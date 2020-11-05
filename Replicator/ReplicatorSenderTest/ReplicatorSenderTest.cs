using Global_Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorSenderTest
{
    [TestFixture]
    public class ReplicatorSenderTest
    {
        [Test]
        public void ReplicatorSender_EmptyConstructor_ReturnsDefaults()
        {
            var result = new ReplicatorSender.ReplicatorSender();

            var hcollection = new HistoricalCollection();
            bool equal = !hcollection.ReceiverPropertyArray.Except(result.Data.ReceiverPropertyArray).Any();


            Assert.IsTrue(equal);
        }

        [Test]
        public void ReplicatorSender_ToString_Test()
        {
            var list = new List<ReceiverProperty>
            {
                new ReceiverProperty(Code.CODE_ANALOG, 0),
                new ReceiverProperty(Code.CODE_DIGITAL, 7)
            };

            var result = new ReplicatorSender.ReplicatorSender { Data = new HistoricalCollection(list) };

            Assert.IsTrue(result.ToString() == "Sender data:\nCODE_ANALOG 0\nCODE_DIGITAL 7\n");
        }
    }
}
