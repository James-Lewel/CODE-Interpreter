using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterGrp7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
            Console.WriteLine(path);

            Console.ReadLine();
        }
    }
}
