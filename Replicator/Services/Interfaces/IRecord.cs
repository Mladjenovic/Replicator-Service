using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRecord
    {
        CollectionDescription ReadFromFile(int dataset);

        void WriteToFile(int dataset, CollectionDescription cd);

        void WriteToHistory(DescriptionList desclist);

        void WriteToHistory(ECodes code, double value);

        HistoricalCollection GetChangesForCode(ECodes code);
    }
}
