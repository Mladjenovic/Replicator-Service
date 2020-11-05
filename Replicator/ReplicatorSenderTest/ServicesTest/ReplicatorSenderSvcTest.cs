using Global_Data.Models;
using NUnit.Framework;
using ReplicatorReceiver;
using ReplicatorSender;
using ReplicatorSender.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReplicatorSenderTest.ServicesTest
{
    [TestFixture]
    public class ReplicatorSenderSvcTest
    {
        [Test]
        public void StartForwardingData_Test()
        {
            try
            {
                ReplicatorSender.ReplicatorSender sender = new ReplicatorSender.ReplicatorSender();
                ReplicatorReceiver.ReplicatorReceiver replicatorReceiver = new ReplicatorReceiver.ReplicatorReceiver();


                sender.service.StartForwardingData(sender, replicatorReceiver);
                Thread.Sleep(500);
                sender.service.StopForwardingData();

                // Data.Count = 1
                sender.Data = new HistoricalCollection(
                    new List<ReceiverProperty>
                    {
                        new ReceiverProperty(Code.CODE_ANALOG, 1001)
                    }
                                                      );


                sender.service.StartForwardingData(sender, replicatorReceiver);
                Thread.Sleep(500);
                sender.service.StopForwardingData();

                // Data.Count = 2
                sender.Data = new HistoricalCollection(
                    new List<ReceiverProperty>
                    {
                        new ReceiverProperty(Code.CODE_ANALOG, 1001),
                        new ReceiverProperty(Code.CODE_ANALOG, 1002)
                    }
                                                      );

                sender.service.StartForwardingData(sender, replicatorReceiver);
                Thread.Sleep(500);
                sender.service.StopForwardingData();

                //// sender.Data.ReceiverPropertyArray[0] = null
                //sender.Data.ReceiverPropertyArray[0] = null;
                //sender.service.StartForwardingData(sender, replicatorReceiver);
                //sender.Data = new HistoricalCollection(
                //    new List<ReceiverProperty>
                //    {
                //        new ReceiverProperty(Code.CODE_ANALOG, 1001),
                //        new ReceiverProperty(Code.CODE_ANALOG, 1002)
                //    }
                //                                      );

                //Thread.Sleep(500);
                //sender.service.StopForwardingData();

                //sender.Data.ReceiverPropertyArray[1] = null;
                //sender.service.StartForwardingData(sender, replicatorReceiver);
                //sender.Data = new HistoricalCollection(
                //    new List<ReceiverProperty>
                //    {
                //        new ReceiverProperty(Code.CODE_ANALOG, 1001),
                //        new ReceiverProperty(Code.CODE_ANALOG, 1002)
                //    }
                //                                      );


                //sender.service.StartForwardingData(sender, replicatorReceiver);

                //Thread.Sleep(500);
                //sender.service.StopForwardingData();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.Pass();


            //// Data.Count = 2,  dataset 1
            //sender.Data = new HistoricalCollection(
            //    new List<ReceiverProperty>
            //    {
            //        new ReceiverProperty(Code.CODE_ANALOG, 1001),
            //        new ReceiverProperty(Code.CODE_DIGITAL, 0)
            //    }
            //                                      );

            //sender.service.ForwardDataToReceiver(sender, replicatorReceiver);

            //// Data.Count = 2, dataset 2
            //sender.Data = new HistoricalCollection(
            //    new List<ReceiverProperty>
            //    {
            //        new ReceiverProperty(Code.CODE_CUSTOM, 3300),
            //        new ReceiverProperty(Code.CODE_LIMITSET, 4400)
            //    }


            //                                      );

            //sender.service.ForwardDataToReceiver(sender, replicatorReceiver);

            //// Data.Count = 2, dataset 3
            //sender.Data = new HistoricalCollection(
            //    new List<ReceiverProperty>
            //    {
            //        new ReceiverProperty(Code.CODE_SINGLENODE, 6232),
            //        new ReceiverProperty(Code.CODE_MULTIPLENODE, 5323)
            //    }
            //                                      );

            //sender.service.ForwardDataToReceiver(sender, replicatorReceiver);

            //// Data.Count = 2, dataset 4
            //sender.Data = new HistoricalCollection(
            //    new List<ReceiverProperty>
            //    {
            //        new ReceiverProperty(Code.CODE_CONSUMER, 7999),
            //        new ReceiverProperty(Code.CODE_SOURCE, 2000)
            //    }
            //                                      );
        }
    }
}
