using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CYDecrypt
{
    public class XORHandler
    {
        public static string DecryptString(string input, string key)
        {
            string output = "";
            for (int i = 0; i < input.Length; i++)
            {
                output += (char)(input[i] ^ key[i % key.Length]);
            }
            return output;
        }
        public static byte[] DecryptBytes(byte[] text, byte[] key)
        {
            byte[] xor = new byte[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                xor[i] = (byte)(text[i] ^ key[i % key.Length]);
            }
            return xor;
        }
        public static void DecryptFile(string inputFile)
        {
            string fileParsed;
            string[] files = Directory.GetFiles(Program.FolderPath, "*.cy");
            //cant find the file.
            if (!File.Exists(Program.FolderPath + inputFile))
            {
                //try adding .cy suffix
                if (!File.Exists(Program.FolderPath + inputFile + ".cy"))
                {
                    Program.WriteLineColor("File not found.", ConsoleColor.Red);
                    return;
                }
                else
                {
                    fileParsed = Program.FolderPath + inputFile + ".cy";
                }
            }
            else
            {
                fileParsed = Program.FolderPath + inputFile;
            }
            
            try
            {
                if (File.Exists(fileParsed + ".bin"))
                {
                    Logger.WriteWarning("File: " + fileParsed + ".bin" + " already exists. overwriting...");
                    File.Delete(fileParsed + ".bin");
                }
                byte[] filebytes;
                filebytes = File.ReadAllBytes(fileParsed);
                string[] fileparts = fileParsed.Split('\\');
                string filename = fileparts.Last();
                Logger.WriteInfo("Decrypting " + filename + "...");
                byte[] decrypted = DecryptBytes(filebytes, Program.Key);
                File.WriteAllBytes(fileParsed + ".bin", decrypted);
                Logger.WriteInfo("Wrote new file " + fileParsed + ".bin");
            }
            catch (Exception e)
            {
                Logger.WriteError("Failed decrypting file: " + fileParsed + " Error: " + e.Message);
            }

        }
        public static void DecryptAllFiles()
        {
            string[] files = Directory.GetFiles(Program.FolderPath, "*.cy");
            foreach(string file in files)
            {
                try
                {
                    if (File.Exists(file + ".bin"))
                    {
                        Logger.WriteWarning("File: " + file + ".bin" + " already exists. overwriting...");
                        File.Delete(file + ".bin");
                    }
                    byte[] filebytes;
                    filebytes = File.ReadAllBytes(file);
                    string[] fileparts = file.Split('\\');
                    string filename = fileparts.Last();
                    Logger.WriteInfo("Decrypting " + filename + "...");
                    byte[] decrypted = DecryptBytes(filebytes, Program.Key);
                    File.WriteAllBytes(file + ".bin", decrypted);
                    Logger.WriteInfo("Wrote new file " + file + ".bin");
                }catch(Exception e)
                {
                    Logger.WriteError("Failed decrypting file: " + file + " Error: " + e.Message);
                }
            }
        }
    }
}
