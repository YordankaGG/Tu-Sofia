using System;
using System.IO;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream fs = new FileStream("Myfile.txt", FileMode.Create)) 
            {
                using (StreamWriter wr = new StreamWriter(fs))
                {
                    for (int i = 0; i <= 1000; i++)
                    {
                        string s = i + "." + "Shte programiram po 6 chasa na sedmica!";
                        Console.WriteLine(s);
                        wr.WriteLine(s);
                    }
                }
            }
        }
    }
}
