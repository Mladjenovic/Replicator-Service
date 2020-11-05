using Global_Data.Models;
using Global_Data.Services;
using ReplicatorSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Writer.Interfaces;

namespace Writer.Services
{
    public class WriterSvc : IWriter
    {
        private Random ran = new Random();
        private int value;
        private Code code;
        private Thread t;


        public void GenerateRandomValue()
        {
            code = (Code)ran.Next(Enum.GetNames(typeof(Code)).Length);

            // Codes
            if (code == Code.CODE_DIGITAL)
                value = GetRandomValue() % 2;

            else if (code == Code.CODE_ANALOG)
                value = GetRandomValue() + 1000;

            else if (code == Code.CODE_CONSUMER)
                value = GetRandomValue() + 2000;

            else if (code == Code.CODE_CUSTOM)
                value = GetRandomValue() + 3000;

            else if (code == Code.CODE_LIMITSET)
                value = GetRandomValue() + 4000;

            else if (code == Code.CODE_MULTIPLENODE)
                value = GetRandomValue() + 5000;

            else if (code == Code.CODE_SINGLENODE)
                value = GetRandomValue() + 6000;

            else //if (code == Code.CODE_SOURCE)
                value = GetRandomValue() + 7000;
        }

        public void SendData(ReplicatorSender.ReplicatorSender replicatorSender)
        {
            while (true)
            {
                lock (this)
                {
                    try
                    {
                        GenerateRandomValue();
                        replicatorSender.Data.ReceiverPropertyArray.Add(new ReceiverProperty(code, value));

                        Logger.Log(LogComponent.WRITER, LogComponent.REPLICATOR_SENDER, DateTime.Now, code.ToString() + "_" + value);
                    }
                    catch (Exception)
                    {
                        Logger.LogError(LogComponent.WRITER, DateTime.Now);
                    }
                    

                    Thread.Sleep(2000);
                }
            }
        }

        public void StartSendingData(ReplicatorSender.ReplicatorSender replicatorSender)
        {
            t = new Thread(() => SendData(replicatorSender));
            t.IsBackground = true;
            t.Start();
            Thread.Sleep(15);
        }

        public void StopSendingData()
        {
            t.Abort();
        }

        public static int GetRandomValue()
        {
            //child klasa od RandomNumberGenerator 
            //Implements a cryptographic Random Number Generator (RNG) 
            //  using the implementation provided by the cryptographic service provider (CSP). 
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[4];
                //fills an array of bytes with a cryptographically strong sequence of random values
                rg.GetBytes(rno);
                int randomvalue = BitConverter.ToInt32(rno, 0);
                return Math.Abs(randomvalue % 1000);
            }
            //When the lifetime of an IDisposable object is limited to a single method, 
            //  you should declare and instantiate it in a using statement. 
            //  The using statement calls the Dispose method on the object in the correct way, 
            //  and (when you use it as shown earlier) it also causes the object itself to go out of scope as soon as Dispose is called. 
        }
    }
}
