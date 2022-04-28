using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYDecrypt
{
    internal class Logger
    {
        public const string log_path = ".\\CYDecryptorLogs\\";
        public static void WriteError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = log_path + date + ".log";
            Console.WriteLine("[" + time + " ERROR]: " + msg);
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " ERROR]: " + msg + "\n");
            sw.Close();
            Console.ResetColor();
        }
        public static void WriteFatal(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = log_path + date + ".log";
            Console.WriteLine("[" + time + " FATAL ERROR]: " + msg);
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " FATAL ERROR]: " + msg + "\n");
            sw.Close();
            Console.ResetColor();
        }
        public static void WriteWarning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = log_path + date + ".log";
            Console.WriteLine("[" + time + " WARNING]: " + msg);
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " WARNING]: " + msg + "\n");
            sw.Close();
            Console.ResetColor();
        }
        public static void WriteInfo(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = log_path + date + ".log";
            Console.WriteLine("[" + time + " INFO]: " + msg);
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " INFO]: " + msg + "\n");
            sw.Close();
            Console.ResetColor();
        }
        public static void WriteDebug(string msg, bool displaytoconsole)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = log_path + date + ".log";
            if (displaytoconsole)
            {
                Console.WriteLine("[" + time + " DEBUG]: " + msg);
            }
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " DEBUG]: " + msg + "\n");
            sw.Close();
            Console.ResetColor();
        }
        public static void WriteVerbose(string msg, bool displaytoconsole)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = log_path + date + ".log";
            if(displaytoconsole)
            {
                Console.WriteLine("[" + time + " VERBOSE]: " + msg);
            }
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " VERBOSE]: " + msg + "\n");
            sw.Close();
            Console.ResetColor();
        }
        public static void WriteCritical(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            string date = DateTime.Now.ToString("dd-MM-yyyy");
            string time = DateTime.Now.ToString("hh\\:mm\\:ss");
            string file = log_path + date + ".log";
            Console.WriteLine("[" + time + " CRITICAL]: " + msg);
            StreamWriter sw = new StreamWriter(file, append: true);
            sw.Write("[" + time + " CRITICAL]: " + msg + "\n");
            sw.Close();
            Console.ResetColor();
        }
    }
}
