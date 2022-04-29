using System;
using System.IO;
#nullable disable

namespace CYDecrypt
{
    internal static class Program
    {
        public static string Version = "1.0.0";
        public static byte[] Key = { 0x28 };
        //yes, this can cause issues.
        public static string FolderPath = @".\Doki Doki Literature Club Plus_Data\StreamingAssets\AssetBundles\Windows\";
        [STAThread]
        internal static void Main()
        {
            Console.WriteLine("CYDecrypt v" + Version);
            Console.WriteLine("Hello, this was meant to decrypt DDLC+ .cy files.");
            Console.WriteLine("Please place the application into the same folder as the 'Doki Doki Literature Club Plus!.exe' file.");
            if (!Directory.Exists(Logger.log_path))
            {
                Directory.CreateDirectory(Logger.log_path);
            }
            if (!Directory.Exists(FolderPath))
            {
                Logger.WriteFatal("Can't find the folder with the .cy files.");
                ReadKey("Press any key to exit....");
                Environment.Exit(0);
            }
            Console.WriteLine("Looks like all check have been passed.");
            Logger.WriteInfo("Using key: " + BitConverter.ToString(Key));
            while (true)
            {
                Console.WriteLine("Decrypt \"all\" or \"single\"?");
                string input = ReadInput("> ");
                Logger.WriteVerbose("Input: " + input, false);
                switch (input)
                {
                    case "all":
                        XORHandler.DecryptAllFiles();
                        break;
                    case "single":
                        Console.WriteLine("Please enter the name of the file you want to decrypt.");
                        string file_name = ReadInput("> ");
                        XORHandler.DecryptFile(file_name);
                        break;
                    default:
                        WriteLineColor("Invalid Input", ConsoleColor.Red);
                        break;
                }
            }
        }

        public static string ReadInput(string carrot)
        {
            Console.Write(carrot);
            return Console.ReadLine();
        }
        public static string ReadKey(string carrot)
        {
            Console.Write(carrot);
            return Console.ReadKey().ToString();
        }
        public static void WriteLineColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
