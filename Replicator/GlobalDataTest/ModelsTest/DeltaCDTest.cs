using Global_Data.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDataTest.ModelsTest
{
    [TestFixture]
    public class DeltaCDTest
    {
        private static readonly object[] _source =
        {
            
            new object[]
            {
                new List<CollectionDescription> { },
                new List<CollectionDescription> { }
            },
            new object[]
            {
                new List<CollectionDescription>
                {
                    new CollectionDescription(
                        int.MinValue,
                        int.MaxValue,
                        new HistoricalCollection(
                            new List<ReceiverProperty>
                            {
                                new ReceiverProperty(Code.CODE_ANALOG, int.MinValue),
                                new ReceiverProperty(Code.CODE_ANALOG, int.MaxValue),
                                new ReceiverProperty(Code.CODE_DIGITAL, 0),
                                new ReceiverProperty(Code.CODE_CUSTOM, 1),
                            }                   
                                                )
                                             )
                },
                new List<CollectionDescription>
                {
                    new CollectionDescription(
                        int.MaxValue,
                        int.MinValue,
                        new HistoricalCollection(
                            new List<ReceiverProperty>
                            {
                                new ReceiverProperty(Code.CODE_ANALOG, int.MinValue),
                                new ReceiverProperty(Code.CODE_ANALOG, int.MaxValue),
                                new ReceiverProperty(Code.CODE_DIGITAL, 0),
                                new ReceiverProperty(Code.CODE_CUSTOM, 1),
                            }
                                                )
                                             ),
                    new CollectionDescription(
                        int.MinValue,
                        int.MinValue,
                        new HistoricalCollection(
                            new List<ReceiverProperty>
                            {
                                new ReceiverProperty(Code.CODE_ANALOG, int.MinValue),
                                new ReceiverProperty(Code.CODE_ANALOG, int.MaxValue),
                                new ReceiverProperty(Code.CODE_DIGITAL, 0),
                                new ReceiverProperty(Code.CODE_CUSTOM, 1),
                            }
                                                )
                                             ),
                    new CollectionDescription(
                        int.MaxValue,
                        int.MaxValue,
                        new HistoricalCollection(
                            new List<ReceiverProperty>
                            {
                                new ReceiverProperty(Code.CODE_ANALOG, int.MinValue),
                                new ReceiverProperty(Code.CODE_ANALOG, int.MaxValue),
                                new ReceiverProperty(Code.CODE_DIGITAL, 0),
                                new ReceiverProperty(Code.CODE_CUSTOM, 1),
                            }
                                                )
                                             )
                }
            }
        };


        [Test]
        public void DeltaCD_EmptyConstructor_ReturnsDefaults()
        {
            var result = new DeltaCD();

            Assert.AreEqual(result.Add, new List<CollectionDescription>());
            Assert.AreEqual(result.Update, new List<CollectionDescription>());
        }

        [Test]
        [TestCaseSource("_source")]
        public void DeltaCD_ConstructorWithParameters_ReturnsGivenValues(List<CollectionDescription> add, List<CollectionDescription> update)
        {
            var result = new DeltaCD(add, update);

            Assert.AreEqual(result.Add, add);
            Assert.AreEqual(result.Update, update);
        }

        [Test]
        public void DeltaCD_ToString_Test()
        {
            var add = new List<CollectionDescription>
            {
                new CollectionDescription(1, 2, new HistoricalCollection())
            };
            var update = new List<CollectionDescription>
            {
                new CollectionDescription(1, 2, new HistoricalCollection()),
                new CollectionDescription(3, 4, new HistoricalCollection()),
                new CollectionDescription(5, 6, new HistoricalCollection()),
            };

            var result = new DeltaCD(add, update);

            Assert.IsTrue(result.ToString() == "\n\t[DATASET:2]:\n\t[DATASET:2]:\n\t[DATASET:4]:\n\t[DATASET:6]:");
        }
    }
}
