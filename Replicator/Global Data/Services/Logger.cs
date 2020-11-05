using Global_Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global_Data.Services
{
    public class Logger
    {
        private static string filename;
        private static object syncLock = new object();

        static Logger()
        {
            string path = path = "..\\Logs";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            filename = path + @"\log";

            StreamWriter sw;

            string s = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");


            try
            {
                sw = File.CreateText(filename);
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }
            while (true)
            {
                if (!File.Exists(filename + "_" + s + ".log"))
                {
                    filename += "_" + s + ".log";
                    sw = File.CreateText(filename);
                    break;
                }
            }

            sw.WriteLine(filename);
            sw.WriteLine("[{0}] Logger initialized.", DateTime.Now);

            sw.Close();
        }

        public static void Log(LogComponent component, LogComponent component2, DateTime timestamp, String message)
        {
            string line = string.Format($"[{timestamp}] {component.ToString()} TO {component2.ToString()}: {message}");

            StreamWriter sw;

            lock (syncLock)
            {
                if (!File.Exists(filename))
                {
                    sw = File.CreateText(filename);
                }
                else
                {
                    sw = File.AppendText(filename);
                }

                sw.WriteLine(line);

                sw.Close();
            }
        }
        public static void LogError(LogComponent component, DateTime timestamp)
        {
            string line = string.Format($"[{timestamp}] {component.ToString()} ERROR");

            StreamWriter sw;

            lock (syncLock)
            {
                if (!File.Exists(filename))
                {
                    sw = File.CreateText(filename);
                }
                else
                {
                    sw = File.AppendText(filename);
                }

                sw.WriteLine(line);

                sw.Close();
            }
        }
    }
}
