using Global_Data.Models;
using Reader.Services;
using ReplicatorDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader
{
    public class Reader
    {
        private DeltaCD receivedData;
        public readonly ReplicatorDbContext _context;
        public readonly ReaderSvc service;
        


        public int ID { get; set; } // Dataset
        public bool ContainsDataset1 { get; set; }
        public bool ContainsDataset2 { get; set; }
        public bool ContainsDataset3 { get; set; }
        public bool ContainsDataset4 { get; set; }

        public DeltaCD ReceivedData
        {
            get
            {
                return receivedData;
            }
            set
            {
                if (ID == 1)
                {
                    foreach (CollectionDescription cd in value.Add)
                        service.StoreInDataBase(ID, cd, _context);

                    foreach (CollectionDescription cd in value.Update)
                        service.StoreInDataBase(ID, cd, _context);

                }
                else if (ID == 2 || ID == 3 || ID == 4)
                {
                    foreach (CollectionDescription cd in value.Add)
                        if (service.CheckDeadBand(ID, cd, _context))
                            service.StoreInDataBase(ID, cd, _context);

                    foreach (CollectionDescription cd in value.Update)
                        if (service.CheckDeadBand(ID, cd, _context))
                            service.StoreInDataBase(ID, cd, _context);

                }

                receivedData = value;
            }
        }

        public Reader()
        {
            ID = 0;
            ReceivedData = new DeltaCD();
            _context = new ReplicatorDbContext();
            service = new ReaderSvc();

            if (_context.Dataset1.Any())
                ContainsDataset1 = true;
            if (_context.Dataset2.Any())
                ContainsDataset2 = true;
            if (_context.Dataset3.Any())
                ContainsDataset3 = true;
            if (_context.Dataset4.Any())
                ContainsDataset4 = true;
        }

        public Reader(int id)
        {
            ID = id;
            ReceivedData = new DeltaCD();
            _context = new ReplicatorDbContext();
            service = new ReaderSvc();

            if (_context.Dataset1.Any())
                ContainsDataset1 = true;
            if (_context.Dataset2.Any())
                ContainsDataset2 = true;
            if (_context.Dataset3.Any())
                ContainsDataset3 = true;
            if (_context.Dataset4.Any())
                ContainsDataset4 = true;
        }
    }
}
