using Global_Data.Models;
using Reader;
using ReplicatorReceiver.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorReceiver
{
    public class ReplicatorReceiver
    {
        #region Fields
        private readonly ReplicatorReceiverSvc service;
        private readonly Dictionary<int, Reader.Reader> readers;
        private Dictionary<int, DeltaCD> dataDeltaCDs;
        private CollectionDescription dataCD;

        #endregion

        #region Properties
        public CollectionDescription DataCD
        {
            get
            {
                return dataCD;
            }
            set
            {
                if (service.CheckDataset(value.DataSet))
                {
                    service.StoreData(readers[value.DataSet], value, DataDeltaCDs[value.DataSet], value.DataSet);
                    service.InitiateSendingData(readers[value.DataSet], DataDeltaCDs[value.DataSet]);
                } 

                dataCD = value;
            }
        }

        public Dictionary<int, DeltaCD> DataDeltaCDs
        {
            get
            {
                return dataDeltaCDs;
            }
            set
            {
                dataDeltaCDs = value;
            }
        }
        #endregion


        public ReplicatorReceiver()
        {
            readers = new Dictionary<int, Reader.Reader>();
            service = new ReplicatorReceiverSvc();
            DataCD = new CollectionDescription();
            DataDeltaCDs = new Dictionary<int, DeltaCD>();
            DataDeltaCDs.Add(1, new DeltaCD());
            DataDeltaCDs.Add(2, new DeltaCD());
            DataDeltaCDs.Add(3, new DeltaCD());
            DataDeltaCDs.Add(4, new DeltaCD());
        }

        public ReplicatorReceiver(Dictionary<int, Reader.Reader> rds)
        {
            readers = rds;
            service = new ReplicatorReceiverSvc();
            DataCD = new CollectionDescription();
            DataDeltaCDs = new Dictionary<int, DeltaCD>();
            DataDeltaCDs.Add(1, new DeltaCD());
            DataDeltaCDs.Add(2, new DeltaCD());
            DataDeltaCDs.Add(3, new DeltaCD());
            DataDeltaCDs.Add(4, new DeltaCD());
        }
    }
}
