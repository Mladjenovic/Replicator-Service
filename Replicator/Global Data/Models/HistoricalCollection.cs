using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Data.Models
{
    public class HistoricalCollection
    {
        public List<ReceiverProperty> ReceiverPropertyArray { get; set; }

        public HistoricalCollection()
        {
            ReceiverPropertyArray = new List<ReceiverProperty>();
        }

        public HistoricalCollection(List<ReceiverProperty> receiverPropertyArray)
        {
            ReceiverPropertyArray = receiverPropertyArray;
        }

        public override string ToString()
        {
            string temp = string.Empty;
            foreach (ReceiverProperty item in ReceiverPropertyArray)
                temp += item.Code + "_" + item.ReceiverValue + " ";


            return temp;
        }
    }
}
