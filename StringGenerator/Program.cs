using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Win32;

namespace StringGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Usage: StringGenerator [Strings...] [filename]");
                Console.WriteLine("Example: StringGenerator \"You(are | aren't|killed|marked) a (black|green|yellow|beige|purple|pink) young great (man|woman)\" File.txt");
                return;
            }

            string Filename = args[args.Length - 1];

            StringGenerator generator = new StringGenerator(Filename, "\\(([^)]+)\\)");
            
            for (int index = 0; index < args.Length - 1; ++index)
            {
                generator.ProcessString(args[index]);
            }
        }
    }


}
