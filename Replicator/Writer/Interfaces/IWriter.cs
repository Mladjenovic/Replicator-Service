using Global_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer.Interfaces
{
    public interface IWriter
    {
        void GenerateRandomValue();
        void SendData(ReplicatorSender.ReplicatorSender replicatorSender);
        void StartSendingData(ReplicatorSender.ReplicatorSender replicatorSender);
        void StopSendingData();
    }
}
