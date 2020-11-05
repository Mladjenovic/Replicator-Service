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
    public class LoggerTest
    {
        [Test]
        public void Log_ValidLogMessage()
        {
            try
            {
                LogComponent component1 = LogComponent.WRITER;
                LogComponent component2 = LogComponent.REPLICATOR_SENDER;
                LogComponent component3 = LogComponent.REPLICATOR_RECEIVER;
                LogComponent component4 = LogComponent.READER;
                LogComponent component5 = LogComponent.DATABASE;

                Logger.Log(component1, component2, DateTime.Now, "message1");
                Logger.Log(component2, component3, DateTime.Now, "message2");
                Logger.Log(component3, component4, DateTime.Now, "message3");
                Logger.Log(component4, component5, DateTime.Now, "message4");
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }

        [Test]
        public void Log_ErrorLogMessage()
        {
            try
            {
                LogComponent component1 = LogComponent.WRITER;
                LogComponent component2 = LogComponent.REPLICATOR_SENDER;
                LogComponent component3 = LogComponent.REPLICATOR_RECEIVER;
                LogComponent component4 = LogComponent.READER;
                LogComponent component5 = LogComponent.DATABASE;

                Logger.LogError(component1, DateTime.Now);
                Logger.LogError(component2, DateTime.Now);
                Logger.LogError(component3, DateTime.Now);
                Logger.LogError(component4, DateTime.Now);
                Logger.LogError(component5, DateTime.Now);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
    }
}
