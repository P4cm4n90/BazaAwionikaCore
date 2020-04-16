using System;
using System.IO;
using System.Text;

namespace KonsolaTest
{
    class Program
    {
        private static string path = @"d:\MyTest.txt";
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Environment.MachineName);
            WriteMachineNameToFile();
            ReadMachineNameFromFile();
            
        }

        public static void WriteMachineNameToFile()
        {
            try
            {
                using (FileStream fs = File.Create(path))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(Environment.MachineName);
                    fs.Write(info, 0, info.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Błąd {ex.Message}");
            }

        }

        public static void ReadMachineNameFromFile()
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine($"Odczytana nazwa sprzetu {s}");
                }
            }
        }
    }
}
