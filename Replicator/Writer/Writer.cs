using Global_Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writer.Services;

namespace Writer
{
    public class Writer
    {
        public readonly WriterSvc service;
        public int ID { get; set; }

        public Writer()
        {
            ID = 0;
            service = new WriterSvc();
        }

        public Writer(int iD)
        {
            service = new WriterSvc();
            ID = iD;
        }
    }
}
