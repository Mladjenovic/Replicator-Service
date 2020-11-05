using Global_Data.Models;
using Global_Data.Services;
using Reader.Interfaces;
using ReplicatorDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.Services
{
    public class ReaderSvc : IReader
    {
        public bool CheckDeadBand(int datasetID, CollectionDescription cd, ReplicatorDbContext _context)
        {
            if (datasetID == 2)
            {
                List<Dataset2> collection = new List<Dataset2>();
                Dataset2 ds2 = new Dataset2();

                foreach (var item in _context.Dataset2.Where(x => true))
                {
                    ds2.ID = item.ID;
                    ds2.Code1 = item.Code1;
                    ds2.Code2 = item.Code2;
                    ds2.Value1 = item.Value1;
                    ds2.Value2 = item.Value2;
                    collection.Add(ds2);
                }
                

                return collection
                        .Where(x =>
                                    (x.Value1 > (cd.Collection.ReceiverPropertyArray[0].ReceiverValue * 0.98) &&
                                    x.Value1 < (cd.Collection.ReceiverPropertyArray[0].ReceiverValue * 1.02))
                                    &&
                                    (x.Value2 > (cd.Collection.ReceiverPropertyArray[1].ReceiverValue * 0.98) &&
                                    x.Value2 < (cd.Collection.ReceiverPropertyArray[1].ReceiverValue * 1.02))
                        ).Count() > 0 ? false : true;
            }
            else if (datasetID == 3)
            {
                List<Dataset3> collection = new List<Dataset3>();
                Dataset3 ds3 = new Dataset3();

                foreach (var item in _context.Dataset3.Where(x => true))
                {
                    ds3.ID = item.ID;
                    ds3.Code1 = item.Code1;
                    ds3.Code2 = item.Code2;
                    ds3.Value1 = item.Value1;
                    ds3.Value2 = item.Value2;
                    collection.Add(ds3);
                }
                return collection
                            .Where(x =>
                                        (x.Value1 > (cd.Collection.ReceiverPropertyArray[0].ReceiverValue * 0.98) &&
                                        x.Value1 < (cd.Collection.ReceiverPropertyArray[0].ReceiverValue * 1.02)) 
                                        &&
                                        (x.Value2 > (cd.Collection.ReceiverPropertyArray[1].ReceiverValue * 0.98) &&
                                        x.Value2 < (cd.Collection.ReceiverPropertyArray[1].ReceiverValue * 1.02))
                            ).Count() > 0 ? false : true;
            }
            else // (if (datasetID == 4)
            {
                List<Dataset4> collection = new List<Dataset4>();
                Dataset4 ds4 = new Dataset4();

                foreach (var item in _context.Dataset4.Where(x => true))
                {
                    ds4.ID = item.ID;
                    ds4.Code1 = item.Code1;
                    ds4.Code2 = item.Code2;
                    ds4.Value1 = item.Value1;
                    ds4.Value2 = item.Value2;
                    collection.Add(ds4);
                }
                return collection
                            .Where(x =>
                                        (x.Value1 > (cd.Collection.ReceiverPropertyArray[0].ReceiverValue * 0.98) &&
                                        x.Value1 < (cd.Collection.ReceiverPropertyArray[0].ReceiverValue * 1.02)) 
                                        &&
                                        (x.Value2 > (cd.Collection.ReceiverPropertyArray[1].ReceiverValue * 0.98) &&
                                        x.Value2 < (cd.Collection.ReceiverPropertyArray[1].ReceiverValue * 1.02))
                            ).Count() > 0 ? false : true;
            }
        }

        public string ReadDataFromDataBase(Code c, int datasetID, ReplicatorDbContext _context, string dateFrom, string dateTo)
        {
            string retVal = string.Empty;
            DateTime date1 = new DateTime();
            DateTime date2 = new DateTime();
            try
            {
                date1 = DateTime.ParseExact(dateFrom, "yyyy-MM-dd HH:mm:ss.fff",
                                       System.Globalization.CultureInfo.InvariantCulture);
                date2 = DateTime.ParseExact(dateTo, "yyyy-MM-dd HH:mm:ss.fff",
                                           System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new ArgumentException("DateTime couldnt parse", "datetime");
            }

            if (datasetID == 1)
            {
                foreach (var item in _context.Dataset1.Where(x => DateTime.Compare(date1, x.TimeStamp) <= 0 && DateTime.Compare(date2, x.TimeStamp) >= 0))
                {
                    if (c == Code.CODE_ANALOG)
                        retVal += "[" + item.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]:" + " CODE_ANALOG " + item.Value1 + "\n";
                    else //if (c == Code.CODE_DIGITAL)
                        retVal += "[" + item.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]:" + " CODE_DIGITAL " + item.Value2 + "\n";
                }
            }
            else if (datasetID == 2)
            {
                foreach (var item in _context.Dataset2.Where(x => DateTime.Compare(date1, x.TimeStamp) <= 0 && DateTime.Compare(date2, x.TimeStamp) >= 0))
                {
                    if (c == Code.CODE_CUSTOM)
                        retVal += "[" + item.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]:" + " CODE_CUSTOM " + item.Value1 + "\n";
                    else //if (c == Code.CODE_LIMITSET)
                        retVal += "[" + item.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]:" + " CODE_LIMITSET " + item.Value2 + "\n";
                }
            }
            else if (datasetID == 3)
            {
                foreach (var item in _context.Dataset3.Where(x => DateTime.Compare(date1, x.TimeStamp) <= 0 && DateTime.Compare(date2, x.TimeStamp) >= 0))
                {
                    if (c == Code.CODE_SINGLENODE)
                        retVal += "[" + item.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]:" + " CODE_SINGLENODE " + item.Value1 + "\n";
                    else //if (c == Code.CODE_MULTIPLENODE)
                        retVal += "[" + item.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]:" + " CODE_MULTIPLENODE " + item.Value2 + "\n";
                }
            }
            else/* if (datasetID == 4)*/
            {
                foreach (var item in _context.Dataset4.Where(x => DateTime.Compare(date1, x.TimeStamp) <= 0 && DateTime.Compare(date2, x.TimeStamp) >= 0))
                {
                    if (c == Code.CODE_CONSUMER)
                        retVal += "[" + item.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]:" + " CODE_CONSUMER " + item.Value1 + "\n";
                    else //if (c == Code.CODE_SOURCE)
                        retVal += "[" + item.TimeStamp.ToString("yyyy-MM-dd HH:mm:ss.fff") + "]:" + " CODE_SOURCE " + item.Value2 + "\n";
                }
            }

            return retVal;
        }

        public void StoreInDataBase(int datasetID, CollectionDescription cd, ReplicatorDbContext _context)
        {
            if (datasetID == 1)
            {
                Dataset1 ds1 = new Dataset1();

                ds1.ID = datasetID;
                ds1.Code1 = cd.Collection.ReceiverPropertyArray[0].Code;
                ds1.Value1 = cd.Collection.ReceiverPropertyArray[0].ReceiverValue;
                ds1.Code2 = cd.Collection.ReceiverPropertyArray[1].Code;
                ds1.Value2 = cd.Collection.ReceiverPropertyArray[1].ReceiverValue;
                ds1.TimeStamp = DateTime.Now;

                _context.Dataset1.Add(ds1);
                Logger.Log(LogComponent.READER, LogComponent.DATABASE, DateTime.Now, cd.ToString());
            }
            else if (datasetID == 2)
            {
                Dataset2 ds2 = new Dataset2();

                ds2.ID = datasetID;
                ds2.Code1 = cd.Collection.ReceiverPropertyArray[0].Code;
                ds2.Value1 = cd.Collection.ReceiverPropertyArray[0].ReceiverValue;
                ds2.Code2 = cd.Collection.ReceiverPropertyArray[1].Code;
                ds2.Value2 = cd.Collection.ReceiverPropertyArray[1].ReceiverValue;
                ds2.TimeStamp = DateTime.Now;

                _context.Dataset2.Add(ds2);
                Logger.Log(LogComponent.READER, LogComponent.DATABASE, DateTime.Now, cd.ToString());
            }
            else if (datasetID == 3)
            {
                Dataset3 ds3 = new Dataset3();

                ds3.ID = datasetID;
                ds3.Code1 = cd.Collection.ReceiverPropertyArray[0].Code;
                ds3.Value1 = cd.Collection.ReceiverPropertyArray[0].ReceiverValue;
                ds3.Code2 = cd.Collection.ReceiverPropertyArray[1].Code;
                ds3.Value2 = cd.Collection.ReceiverPropertyArray[1].ReceiverValue;
                ds3.TimeStamp = DateTime.Now;

                _context.Dataset3.Add(ds3);
                Logger.Log(LogComponent.READER, LogComponent.DATABASE, DateTime.Now, cd.ToString());
            }
            else //if (datasetID == 4)
            {
                Dataset4 ds4 = new Dataset4();

                ds4.ID = datasetID;
                ds4.Code1 = cd.Collection.ReceiverPropertyArray[0].Code;
                ds4.Value1 = cd.Collection.ReceiverPropertyArray[0].ReceiverValue;
                ds4.Code2 = cd.Collection.ReceiverPropertyArray[1].Code;
                ds4.Value2 = cd.Collection.ReceiverPropertyArray[1].ReceiverValue;
                ds4.TimeStamp = DateTime.Now;

                _context.Dataset4.Add(ds4);
                Logger.Log(LogComponent.READER, LogComponent.DATABASE, DateTime.Now, cd.ToString());
            }

            _context.SaveChanges();
        }
    }
}
