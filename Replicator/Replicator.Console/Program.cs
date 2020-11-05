using Global_Data.Models;
using Reader;
using ReplicatorDatabase;
using ReplicatorReceiver;
using ReplicatorSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Writer;

namespace Replicator.Console
{
    class Program
    {
        private static int writerCounter = 0;

        static void Main(string[] args)
        {
            // Writers
            Dictionary<int, Writer.Writer> writers = new Dictionary<int, Writer.Writer>();

            // Readers
            Dictionary<int, Reader.Reader> readers = new Dictionary<int, Reader.Reader>();

            Reader.Reader rd1 = new Reader.Reader(1);
            Reader.Reader rd2 = new Reader.Reader(2);
            Reader.Reader rd3 = new Reader.Reader(3);
            Reader.Reader rd4 = new Reader.Reader(4);

            readers.Add(1, rd1);
            readers.Add(2, rd2);
            readers.Add(3, rd3);
            readers.Add(4, rd4);

            // Sender
            ReplicatorSender.ReplicatorSender s = new ReplicatorSender.ReplicatorSender();

            // Receiver
            ReplicatorReceiver.ReplicatorReceiver r = new ReplicatorReceiver.ReplicatorReceiver(readers);

            s.service.StartForwardingData(s, r);
            

            while (true)
            {
                System.Console.WriteLine("-------------------------------");
                System.Console.WriteLine("0 - Exit");
                System.Console.WriteLine("1 - Turn off writer");
                System.Console.WriteLine("2 - Show writers");
                System.Console.WriteLine("3 - Start new writer");
                System.Console.WriteLine("4 - Start 100 writers");
                System.Console.WriteLine("5 - Read data form database: ");
                System.Console.WriteLine("-------------------------------");

                string c = System.Console.ReadLine();

                System.Console.WriteLine();

                if (c == "0")
                {
                    foreach (var item in writers.Keys)
                    {
                        writers[item].service.StopSendingData();
                    }
                    break;
                }
                else if (c == "1")
                {
                    System.Console.WriteLine("Writer No: ");
                    int number;
                    try
                    {
                        number = int.Parse(System.Console.ReadLine());
                        writers[number].service.StopSendingData();
                        writers.Remove(number);

                        System.Console.WriteLine($"Writer {number} has been turned off.\n");

                    }
                    catch (Exception)
                    {
                        System.Console.WriteLine("Writer with that ID doesn't exist!");
                    }

                }
                else if (c == "2")
                {
                    System.Console.WriteLine("Writer list:");
                    foreach (var item in writers.Values)
                    {
                        System.Console.WriteLine($"\tWriter {item.ID}");
                    }
                }
                else if (c == "3")
                {
                    writerCounter++;
                    writers.Add(writerCounter, new Writer.Writer(writerCounter));
                    writers[writerCounter].service.StartSendingData(s);
                }
                else if (c == "4")
                {
                    for (int i = 0; i < 100; i++)
                    {
                        writerCounter++;
                        writers.Add(writerCounter, new Writer.Writer(writerCounter));
                        writers[writerCounter].service.StartSendingData(s);
                    }
                }
                else if (c == "5")
                {
                    System.Console.WriteLine("Choose code: \n");
                    System.Console.WriteLine("1) CODE_ANALOG: ");
                    System.Console.WriteLine("2) CODE_DIGITAL: ");
                    System.Console.WriteLine("3) CODE_CUSTOM: ");
                    System.Console.WriteLine("4) CODE_LIMITSET: ");
                    System.Console.WriteLine("5) CODE_SINGLENODE: ");
                    System.Console.WriteLine("6) CODE_MULTIPLENODE: ");
                    System.Console.WriteLine("7) CODE_CONSUMER: ");
                    System.Console.WriteLine("8) CODE_SOURCE: ");

                    int code_option = 0;

                    try
                    {
                        code_option = int.Parse(System.Console.ReadLine());
                        if (code_option < 1 && code_option > 8)
                        {
                            System.Console.WriteLine("Wrong input!");
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        System.Console.WriteLine("Wrong input!");
                        break;
                    }

                    

                    System.Console.WriteLine("From: ");
                    string dateFrom = System.Console.ReadLine();
                    System.Console.WriteLine("To: ");
                    string dateTo = System.Console.ReadLine();

                    switch (code_option)
                    {
                        case 1:
                            System.Console.WriteLine(rd1.service.ReadDataFromDataBase(Code.CODE_ANALOG, 1, rd1._context, dateFrom, dateTo));
                            break;
                        case 2:
                            System.Console.WriteLine(rd1.service.ReadDataFromDataBase(Code.CODE_DIGITAL, 1, rd1._context, dateFrom, dateTo));
                            break;
                        case 3:
                            System.Console.WriteLine(rd1.service.ReadDataFromDataBase(Code.CODE_CUSTOM, 2, rd2._context, dateFrom, dateTo));
                            break;
                        case 4:
                            System.Console.WriteLine(rd1.service.ReadDataFromDataBase(Code.CODE_LIMITSET, 2, rd2._context, dateFrom, dateTo));
                            break;
                        case 5:
                            System.Console.WriteLine(rd1.service.ReadDataFromDataBase(Code.CODE_SINGLENODE, 3, rd3._context, dateFrom, dateTo));
                            break;
                        case 6:
                            System.Console.WriteLine(rd1.service.ReadDataFromDataBase(Code.CODE_MULTIPLENODE, 3, rd3._context, dateFrom, dateTo));
                            break;
                        case 7:
                            System.Console.WriteLine(rd1.service.ReadDataFromDataBase(Code.CODE_CONSUMER, 4, rd4._context, dateFrom, dateTo));
                            break;
                        case 8:
                            System.Console.WriteLine(rd1.service.ReadDataFromDataBase(Code.CODE_SOURCE, 4, rd4._context, dateFrom, dateTo));
                            break;
                        default:
                            System.Console.WriteLine("Wrong input");
                            break;
                    }
                }
                else
                {
                    System.Console.WriteLine("Wrong input!");
                }
            }

            System.Console.ReadLine();
        }
    }
}
