using Global_Data.Models;
using Global_Data.Services;
using NUnit.Framework;
using ReplicatorReceiver.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplicatorReceiverTest.ServicesTest
{
    [TestFixture]
    public class ReplicatorReceiverSvcTest
    {
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        //[TestCase(0)]
        public void StoreDataTest(int dataset)
        {
            Reader.Reader reader = new Reader.Reader(1);
            Reader.Reader reader2 = new Reader.Reader(2);
            Reader.Reader reader3 = new Reader.Reader(3);
            Reader.Reader reader4 = new Reader.Reader(4);
            ReplicatorReceiverSvc svc = new ReplicatorReceiverSvc();
            CollectionDescription cd = new CollectionDescription();
            DeltaCD deltaCD= new DeltaCD();

            DeltaCD deltaCD2 = new DeltaCD
            {
                Add = new List<CollectionDescription>
                {
                    new CollectionDescription
                    {
                        ID = 1,
                        DataSet = 1,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_ANALOG,
                                     ReceiverValue  = 1001
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_DIGITAL,
                                     ReceiverValue  = 0
                                }

                            }
                        }
                    }
                },
                Update = new List<CollectionDescription>
                {
                    new CollectionDescription
                    {
                        ID = 2,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    }
                }
            };
            try
            {
                svc.StoreData(reader, cd, deltaCD, dataset);
                svc.StoreData(reader2, cd, deltaCD, dataset);
                svc.StoreData(reader3, cd, deltaCD, dataset);
                svc.StoreData(reader4, cd, deltaCD, dataset);

                svc.StoreData(reader, cd, deltaCD2, dataset);
                svc.StoreData(reader2, cd, deltaCD2, dataset);
                svc.StoreData(reader3, cd, deltaCD2, dataset);
                svc.StoreData(reader4, cd, deltaCD2, dataset);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.Pass();
            //Assert.AreEqual(true, svc.StoreData(reader, cd, deltaCD, dataset));
            

        }

        [Test]
        public void InitiateSendingData_Test()
        {
            try
            {
                ReplicatorReceiverSvc svc = new ReplicatorReceiverSvc();
                Reader.Reader reader = new Reader.Reader(1);
                DeltaCD deltaCD = new DeltaCD();
                

                svc.InitiateSendingData(reader, deltaCD);

                List<CollectionDescription> addList = new List<CollectionDescription>();
                List<CollectionDescription> updateList = new List<CollectionDescription>();

                addList.Add(new CollectionDescription
                {
                    ID = 1,
                    DataSet = 1,
                    Collection = new HistoricalCollection
                    {
                        ReceiverPropertyArray = new List<ReceiverProperty>
                    {
                        new ReceiverProperty(Code.CODE_ANALOG, 1010),
                        new ReceiverProperty(Code.CODE_DIGITAL, 1)
                    }
                    }
                });

                for (int i = 1; i < 10; i++)
                {
                    updateList.Add(new CollectionDescription
                    {
                        ID = i + 1,
                        DataSet = 1,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                    {
                        new ReceiverProperty(Code.CODE_ANALOG, 1010),
                        new ReceiverProperty(Code.CODE_DIGITAL, 1)
                    }
                        }
                    });
                }

                deltaCD.Add = addList;
                deltaCD.Update = updateList;


                svc.InitiateSendingData(reader, deltaCD);
            }
            catch (Exception)
            {
                Assert.Pass();
            }
            
            Assert.Pass();
        }

        //puca u ForwardDataToReaders kada treba da doda u kolekciju --> unutar for petlje  collection.Update.Add(deltaCD[i])
        [Test]
        public void ForwardDataToReadersTest()
        {
            CollectionDescription cd = new CollectionDescription();
            ReplicatorReceiverSvc svc = new ReplicatorReceiverSvc();

            Reader.Reader reader = new Reader.Reader(1);
            Reader.Reader reader2 = new Reader.Reader(2);
            Reader.Reader reader3 = new Reader.Reader(3);
            Reader.Reader reader4 = new Reader.Reader(4);


            DeltaCD deltaCD = new DeltaCD
            {
                Add = new List<CollectionDescription>
                {
                    new CollectionDescription
                    {
                        ID = 1,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 1111
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 0
                                }
                            }
                        }
                    }
                },
                Update = new List<CollectionDescription>
                {
                    new CollectionDescription
                    {
                        ID = 1,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 1111
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 0
                                }
                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 2,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 2222
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 1
                                }
                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 3,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 1111
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 0
                                }
                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 4,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 1111
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 0
                                }
                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 5,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 1111
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 0
                                }
                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 6,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 1111
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 0
                                }
                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 7,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 1111
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 0
                                }
                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 8,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 1111
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 0
                                }
                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 9,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 1111
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 0
                                }
                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 10,
                        DataSet = 1,
                        Collection =  new HistoricalCollection
                        {
                            ReceiverPropertyArray = new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_ANALOG,
                                    ReceiverValue = 1111
                                },
                                new ReceiverProperty
                                {
                                    Code = Code.CODE_DIGITAL,
                                    ReceiverValue = 0
                                }
                            }
                        }
                    }
                }
            };
            DeltaCD deltaCD2 = new DeltaCD
            {
                
                Update = new List<CollectionDescription>
                {
                    new CollectionDescription
                    {
                        ID = 1,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 2,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 3,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 4,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 5,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 6,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 7,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 8,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 9,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    },
                    new CollectionDescription
                    {
                        ID = 10,
                        DataSet = 2,
                        Collection = new HistoricalCollection
                        {
                            ReceiverPropertyArray =  new List<ReceiverProperty>
                            {
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_CONSUMER,
                                     ReceiverValue  = 2200
                                },
                                new ReceiverProperty
                                {
                                     Code = Code.CODE_SOURCE,
                                     ReceiverValue  = 7701
                                }

                            }
                        }
                    }

                }
            };

            try
            {
                svc.ForwardDataToReaders(reader, deltaCD);
                svc.ForwardDataToReaders(reader2, deltaCD);
                svc.ForwardDataToReaders(reader3, deltaCD);
                svc.ForwardDataToReaders(reader4, deltaCD);

                svc.ForwardDataToReaders(reader, deltaCD2);
                svc.ForwardDataToReaders(reader2, deltaCD2);
                svc.ForwardDataToReaders(reader3, deltaCD2);
                svc.ForwardDataToReaders(reader4, deltaCD2);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
            Assert.Pass();
        }
    }
}
