using Global_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorSender.Interfaces
{
    public interface IReplicatorSender
    {
        void ForwardDataToReceiver(ReplicatorSender sender, ReplicatorReceiver.ReplicatorReceiver replicatorReceiver);

        void StartForwardingData(ReplicatorSender sender, ReplicatorReceiver.ReplicatorReceiver replicatorReceiver);

        void StopForwardingData();

        CollectionDescription ConvertToCD(HistoricalCollection collection);
    }
}
