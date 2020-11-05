using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Data.Models
{
    public class CollectionDescription
    {
        public int ID { get; set; }
        public int DataSet { get; set; }
        public HistoricalCollection Collection { get; set; }

        public CollectionDescription()
        {
            Collection = new HistoricalCollection();
        }

        public CollectionDescription(int iD, int dataSet, HistoricalCollection collection)
        {
            ID = iD;
            DataSet = dataSet;
            Collection = collection;
        }

        public override string ToString()
        {
            string temp = string.Empty;
            temp += $"[DATASET:{DataSet}]:{Collection.ToString()}";

            return temp;
        }
    }
}
