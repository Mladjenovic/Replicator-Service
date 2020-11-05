using Global_Data.Models;
using Global_Data.Services;
using ReplicatorReceiver.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorReceiver.Services
{
    public class ReplicatorReceiverSvc : IReplicatorReceiver
    {
        public bool CheckDataset(int i)
        {
            if (i != 0)
                return true;
            else
                return false;
        }

        public void StoreData(Reader.Reader reader, CollectionDescription cd, DeltaCD dcd, int dataset)
        {
            if (dataset == 1)
            {
                if (!reader.ContainsDataset1)
                {
                    dcd.Add.Add(cd);
                    reader.ContainsDataset1 = true;
                }
                else
                    dcd.Update.Add(cd);
            }
            else if (dataset == 2)
            {
                if (!reader.ContainsDataset2)
                {
                    dcd.Add.Add(cd);
                    reader.ContainsDataset2 = true;
                }
                else
                    dcd.Update.Add(cd);
            }
            else if (dataset == 3)
            {
                if (!reader.ContainsDataset3)
                {
                    dcd.Add.Add(cd);
                    reader.ContainsDataset3 = true;
                }
                else
                    dcd.Update.Add(cd);
            }
            else //if (dataset == 4)
            {
                if (!reader.ContainsDataset4)
                {
                    dcd.Add.Add(cd);
                    reader.ContainsDataset4 = true;
                }
                else
                    dcd.Update.Add(cd);
            }
        }

        public void ForwardDataToReaders(Reader.Reader reader, DeltaCD deltaCD)
        {
            var collection = new DeltaCD();
            string temp = string.Empty;

            if (deltaCD.Add.Count > 0)
            {
                collection.Add.Add(deltaCD.Add[0]);
                for (int i = 0; i < 9; i++)
                {
                    collection.Update.Add(deltaCD.Update[i]);
                }
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    collection.Update.Add(deltaCD.Update[i]);
                }
            }
            temp = collection.ToString();
            Logger.Log(LogComponent.REPLICATOR_RECEIVER, LogComponent.READER, DateTime.Now, temp);

            reader.ReceivedData = collection;
        }

        public void InitiateSendingData(Reader.Reader reader, DeltaCD deltaCD)
        {
            if ((deltaCD.Add.Count + deltaCD.Update.Count) >= 10)
            {
                ForwardDataToReaders(reader, deltaCD);
            }
        }
    }
}
