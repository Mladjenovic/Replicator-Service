using Global_Data.Models;
using NUnit.Framework;
using Reader;
using ReplicatorDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaderTest
{
    [TestFixture]
    public class ReaderTest
    {
        [Test]
        public void Reader_EmptyConstructor_ReturnsDefaults()
        {
            //Reader.Reader reader0 = new Reader.Reader(1);


            Reader.Reader reader = new Reader.Reader();


            Reader.Services.ReaderSvc service = new Reader.Services.ReaderSvc();
            DeltaCD receivedData = new  DeltaCD();
            ReplicatorDbContext _context =  new ReplicatorDbContext();

            var addList = receivedData.Add;
            var UpdateList = receivedData.Update;

            bool equal = !addList.Except(reader.ReceivedData.Add).Any();
            bool equal2 = !addList.Except(reader.ReceivedData.Update).Any();



            Assert.AreEqual(reader.ID, 0);
            Assert.IsTrue(equal && equal2);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void Reader_ConstructorWithParameters_ReturnsValidValues(int id)
        {
            Reader.Reader reader = new Reader.Reader(id);

            Reader.Services.ReaderSvc service = new Reader.Services.ReaderSvc();
            DeltaCD receivedData = new DeltaCD();
            ReplicatorDbContext _context = new ReplicatorDbContext();

            var addList = receivedData.Add;
            var UpdateList = receivedData.Update;

            bool equal = !addList.Except(reader.ReceivedData.Add).Any();
            bool equal2 = !addList.Except(reader.ReceivedData.Update).Any();



            Assert.AreEqual(reader.ID, id);
            Assert.IsTrue(equal && equal2);
        }
    }
}
