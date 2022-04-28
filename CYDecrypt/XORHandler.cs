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
        public static void DecryptAllFiles()
        {
            string[] files = Directory.GetFiles(Program.FolderPath, "*.cy");
            foreach(string file in files)
            {
                try
                {
                    byte[] filebytes;
                    filebytes = File.ReadAllBytes(file);
                    string[] fileparts = file.Split('.');
                    string filename = fileparts[0];
                    Directory.CreateDirectory(Program.FolderPath + filename);
                    byte[] decrypted = DecryptBytes(filebytes, Program.Key);
                    File.WriteAllBytes(file + ".bin", decrypted);
                    Logger.WriteInfo("Wrote file " + file + ".bin");
                }catch(Exception e)
                {
                    Logger.WriteError("Failed decrypting file: " + file + "Error: " + e.Message);
                }
            }
        }
    }
}
