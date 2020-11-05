using Global_Data.Models;
using ReplicatorSender.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorSender
{
    public class ReplicatorSender
    {
        #region Fields
        public readonly ReplicatorSenderSvc service;
        #endregion

        #region Properties
        public HistoricalCollection Data { get; set; }

        #endregion

        public ReplicatorSender()
        {
            service = new ReplicatorSenderSvc();
            Data = new HistoricalCollection();
        }

        public override string ToString()
        {
            string temp = "Sender data:\n";

            foreach (var item in Data.ReceiverPropertyArray)
            {
                temp += item.Code.ToString() + " " + item.ReceiverValue + "\n";
            }

            return temp;
        }
    }
}
