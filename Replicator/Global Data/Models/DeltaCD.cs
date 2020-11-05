using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Data.Models
{
    public class DeltaCD
    {
        public List<CollectionDescription> Add { get; set; }
        public List<CollectionDescription> Update { get; set; }

        public DeltaCD()
        {
            Add = new List<CollectionDescription>();
            Update = new List<CollectionDescription>();
        }

        public DeltaCD(List<CollectionDescription> add, List<CollectionDescription> update)
        {
            Add = add;
            Update = update;
        }

        public override string ToString()
        {
            string temp = string.Empty;

            foreach (CollectionDescription item in Add)
                temp += "\n\t" + item.ToString();

            foreach (CollectionDescription item in Update)
                temp += "\n\t" + item.ToString();

            return temp;
        }
    }
}
