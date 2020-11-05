using Global_Data.Models;
using NUnit.Framework;
using Reader;
using ReplicatorReceiver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorReceiverTest
{

    [TestFixture]
    public class ReplicatorReceiverTest
    {
        [Test]
        public void ReplicatorReceiver_EmptyConstructor_ReturnsDefaults()
        {
            var result = new ReplicatorReceiver.ReplicatorReceiver();
            
            var dataCD = new CollectionDescription();

            var hcollection = dataCD.Collection;
            bool equal = !hcollection.ReceiverPropertyArray.Except(result.DataCD.Collection.ReceiverPropertyArray).Any();

            
            Assert.IsTrue(result.DataCD.ID == dataCD.ID && result.DataCD.DataSet == dataCD.DataSet && equal);

            foreach (var item in result.DataDeltaCDs.Values)
            {
                Assert.AreEqual(item.Add, new List<CollectionDescription>());
                Assert.AreEqual(item.Update, new List<CollectionDescription>());
            }
        }
        [Test]
        public void ReplicatorReceiverTest_ConstructorWithParameters_ReturnsDefaults()
        {
            var dataCD1 = new CollectionDescription { ID = 0, DataSet = 0, Collection = new HistoricalCollection { } };
            Dictionary<int, Reader.Reader> readers1 = new Dictionary<int, Reader.Reader>();
            Reader.Reader rd1 = new Reader.Reader(1);
            Reader.Reader rd2 = new Reader.Reader(2);
            Reader.Reader rd3 = new Reader.Reader(3);
            Reader.Reader rd4 = new Reader.Reader(4);

            readers1.Add(1, rd1);
            readers1.Add(2, rd2);
            readers1.Add(3, rd3);
            readers1.Add(4, rd4);
            //{
            //    {
            //        1,
            //        new Reader.Reader
            //        {
            //            ID = 1,
            //            ContainsDataset1 = false,
            //            ContainsDataset2 = false,
            //            ContainsDataset3= false,
            //            ContainsDataset4 = false,
            //            ReceivedData = new DeltaCD
            //            {
            //                Add = new  List<CollectionDescription>
            //                {
            //                    new CollectionDescription
            //                    {
            //                        ID = 1,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1110
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 1
            //                                }
            //                            }
            //                        }
            //                    }
            //                }, 
            //                Update = new  List<CollectionDescription>
            //                {
            //                    new CollectionDescription
            //                    {
            //                        ID = 2,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1210
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 0
            //                                }
            //                            }
            //                        }
            //                    },
            //                    new CollectionDescription
            //                    {
            //                        ID = 3,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1310
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 1
            //                                }
            //                            }
            //                        }
            //                    }
            //                },
            //            }
            //        }
            //    },
            //    {
            //        2,
            //        new Reader.Reader
            //        {
            //            ID = 2,
            //            ContainsDataset1 = false,
            //            ContainsDataset2 = false,
            //            ContainsDataset3= false,
            //            ContainsDataset4 = false,
            //            ReceivedData = new DeltaCD
            //            {
            //                Add = new  List<CollectionDescription>
            //                {
            //                    new CollectionDescription
            //                    {
            //                        ID = 1,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1110
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 1
            //                                }
            //                            }
            //                        }
            //                    }
            //                },
            //                Update = new  List<CollectionDescription>
            //                {
            //                    new CollectionDescription
            //                    {
            //                        ID = 2,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1210
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 0
            //                                }
            //                            }
            //                        }
            //                    },
            //                    new CollectionDescription
            //                    {
            //                        ID = 3,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1310
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 1
            //                                }
            //                            }
            //                        }
            //                    }
            //                },
            //            }
            //        }
            //    },
            //    {
            //        3,
            //        new Reader.Reader
            //        {
            //            ID = 1,
            //            ContainsDataset1 = false,
            //            ContainsDataset2 = false,
            //            ContainsDataset3= false,
            //            ContainsDataset4 = false,
            //            ReceivedData = new DeltaCD
            //            {
            //                Add = new  List<CollectionDescription>
            //                {
            //                    new CollectionDescription
            //                    {
            //                        ID = 1,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1110
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 1
            //                                }
            //                            }
            //                        }
            //                    }
            //                },
            //                Update = new  List<CollectionDescription>
            //                {
            //                    new CollectionDescription
            //                    {
            //                        ID = 2,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1210
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 0
            //                                }
            //                            }
            //                        }
            //                    },
            //                    new CollectionDescription
            //                    {
            //                        ID = 3,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1310
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 1
            //                                }
            //                            }
            //                        }
            //                    }
            //                },
            //            }
            //        }
            //    },
            //    {
            //        4,
            //        new Reader.Reader
            //        {
            //            ID = 1,
            //            ContainsDataset1 = false,
            //            ContainsDataset2 = false,
            //            ContainsDataset3= false,
            //            ContainsDataset4 = false,
            //            ReceivedData = new DeltaCD
            //            {
            //                Add = new  List<CollectionDescription>
            //                {
            //                    new CollectionDescription
            //                    {
            //                        ID = 1,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1110
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 1
            //                                }
            //                            }
            //                        }
            //                    }
            //                },
            //                Update = new  List<CollectionDescription>
            //                {
            //                    new CollectionDescription
            //                    {
            //                        ID = 2,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1210
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 0
            //                                }
            //                            }
            //                        }
            //                    },
            //                    new CollectionDescription
            //                    {
            //                        ID = 3,
            //                        DataSet = 1,
            //                        Collection = new HistoricalCollection
            //                        {
            //                            ReceiverPropertyArray = new List<ReceiverProperty>
            //                            {
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_ANALOG,
            //                                    ReceiverValue = 1310
            //                                },
            //                                new ReceiverProperty
            //                                {
            //                                    Code = Code.CODE_DIGITAL,
            //                                    ReceiverValue = 1
            //                                }
            //                            }
            //                        }
            //                    }
            //                },
            //            }
            //        }
            //    }
            //};
            var result1 = new ReplicatorReceiver.ReplicatorReceiver(readers1);

            // Dataset 0
            List<ReceiverProperty> receiverPropertyList = new List<ReceiverProperty>(2);
            receiverPropertyList.Add(new ReceiverProperty(Code.CODE_ANALOG, 1001));
            receiverPropertyList.Add(new ReceiverProperty(Code.CODE_ANALOG, 1002));
            HistoricalCollection historicalCollection = new HistoricalCollection(receiverPropertyList);
            CollectionDescription cd = new CollectionDescription(0, 0, historicalCollection);

            result1.DataCD = cd;

            // Dataset 1
            receiverPropertyList.Clear();
            receiverPropertyList.Add(new ReceiverProperty(Code.CODE_ANALOG, 1001));
            receiverPropertyList.Add(new ReceiverProperty(Code.CODE_DIGITAL, 1));
            historicalCollection = new HistoricalCollection(receiverPropertyList);
            cd = new CollectionDescription(1, 1, historicalCollection);

            result1.DataCD = cd;

            // Dataset 2
            receiverPropertyList.Clear();
            receiverPropertyList.Add(new ReceiverProperty(Code.CODE_CUSTOM, 3000));
            receiverPropertyList.Add(new ReceiverProperty(Code.CODE_LIMITSET, 4001));
            historicalCollection = new HistoricalCollection(receiverPropertyList);
            cd = new CollectionDescription(1, 1, historicalCollection);

            result1.DataCD = cd;

            // Dataset 3
            receiverPropertyList.Clear();
            receiverPropertyList.Add(new ReceiverProperty(Code.CODE_SINGLENODE, 6000));
            receiverPropertyList.Add(new ReceiverProperty(Code.CODE_MULTIPLENODE, 5001));
            historicalCollection = new HistoricalCollection(receiverPropertyList);
            cd = new CollectionDescription(1, 1, historicalCollection);

            result1.DataCD = cd;

            // Dataset 4
            receiverPropertyList.Clear();
            receiverPropertyList.Add(new ReceiverProperty(Code.CODE_CONSUMER, 2001));
            receiverPropertyList.Add(new ReceiverProperty(Code.CODE_SOURCE, 7001));
            historicalCollection = new HistoricalCollection(receiverPropertyList);
            cd = new CollectionDescription(1, 1, historicalCollection);

            result1.DataCD = cd;


            var dataCD = new CollectionDescription { ID = 0, DataSet = 0, Collection = new HistoricalCollection { } };
            Dictionary<int, Reader.Reader> readers = new Dictionary<int, Reader.Reader>();
            var result = new ReplicatorReceiver.ReplicatorReceiver(readers);


            var hcollection = dataCD.Collection;
            bool equal = !hcollection.ReceiverPropertyArray.Except(result.DataCD.Collection.ReceiverPropertyArray).Any();


            Assert.IsTrue(result.DataCD.ID == dataCD.ID && result.DataCD.DataSet == dataCD.DataSet && equal);

            foreach (var item in result.DataDeltaCDs.Values)
            {
                Assert.AreEqual(item.Add, new List<CollectionDescription>());
                Assert.AreEqual(item.Update, new List<CollectionDescription>());
            }
        }
    }
}
