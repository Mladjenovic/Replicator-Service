using Global_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorReceiver.Interfaces
{
    public interface IReplicatorReceiver
    {
        bool CheckDataset(int i);
        void InitiateSendingData(Reader.Reader reader, DeltaCD deltaCD);
        void ForwardDataToReaders(Reader.Reader reader, DeltaCD deltaCD);
        void StoreData(Reader.Reader reader, CollectionDescription cd, DeltaCD dcd, int dataset);
    }
}
