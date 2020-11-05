using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Data.Models
{
    public class ReceiverProperty
    {
        public Code Code { get; set; }
        public int ReceiverValue{ get; set; }

        public ReceiverProperty()
        {

        }

        public ReceiverProperty(Code code, int receiverValue)
        {
            Code = code;
            ReceiverValue = receiverValue;
        }
    }
}
