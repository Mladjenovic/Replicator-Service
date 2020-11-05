using Global_Data.Models;
using Global_Data.Services;
using ReplicatorReceiver;
using ReplicatorReceiver.Interfaces;
using ReplicatorSender.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReplicatorSender.Services
{
    public class ReplicatorSenderSvc : IReplicatorSender
    {
        private static int dataCDCounter = 0;
        private Thread t;

        public CollectionDescription ConvertToCD(HistoricalCollection historicalCollection)
        {
            HistoricalCollection collection = new HistoricalCollection();
            for (int i = 0; i < 2; i++)
            {
                collection.ReceiverPropertyArray.Add(historicalCollection.ReceiverPropertyArray[i]);
            }
            return new CollectionDescription(++dataCDCounter,
                                    GetDataSet.GetDatasetForCode(collection.ReceiverPropertyArray[0].Code,
                                    collection.ReceiverPropertyArray[1].Code),
                                    collection);
        }

        public void ForwardDataToReceiver(ReplicatorSender sender, ReplicatorReceiver.ReplicatorReceiver replicatorReceiver)
        {
            while (true)
            {
                lock (this)
                {
                    if (sender.Data.ReceiverPropertyArray.Count >= 2)
                    {
                        if (sender.Data.ReceiverPropertyArray[0] != null && sender.Data.ReceiverPropertyArray[1] != null)
                        {
                            var data = sender.Data;
                            replicatorReceiver.DataCD = ConvertToCD(data);
                            Logger.Log(LogComponent.REPLICATOR_SENDER, LogComponent.REPLICATOR_RECEIVER, DateTime.Now, 
                                        sender.Data.ReceiverPropertyArray[0].Code.ToString() + "_" +
                                        sender.Data.ReceiverPropertyArray[0].ReceiverValue + " " +
                                        sender.Data.ReceiverPropertyArray[1].Code.ToString() + "_" +
                                        sender.Data.ReceiverPropertyArray[1].ReceiverValue
                                        );

                            sender.Data.ReceiverPropertyArray.Clear();
                        }
                    }
                }
                
            }
        }

        public void StartForwardingData(ReplicatorSender sender, ReplicatorReceiver.ReplicatorReceiver replicatorReceiver)
        {
            t = new Thread(() => ForwardDataToReceiver(sender,replicatorReceiver));
            t.IsBackground = true;
            t.Start();
            Thread.Sleep(15);
        }

        public void StopForwardingData()
        {
            t.Abort();
        }
    }
}
