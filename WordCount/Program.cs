using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordCount
{
    class Program
    {
        private static IEnumerable<string> GetText(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        static int Main(string[] args)
        {
            if (args == null || args.Count() == 0)
            {
                Console.WriteLine("Please specify the file name to process.");
                return(1);
            }
            string filePath = args[1];
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"{filePath} doesn't exists");
                return(2);
            }
            var text = GetText(filePath);
            return (0);
        }
    }
}
