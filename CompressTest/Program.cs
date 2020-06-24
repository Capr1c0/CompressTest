using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IniParse ini = new IniParse(args[0]);
            string ResouceMainPath = ini.GetValue("Setting/ResouceMain");
            string ResouceSubPath = ini.GetValue("Setting/ResouceSub");
            string TargetMainPath = ini.GetValue("Setting/TargetMain");
            string TargetSubPath = ini.GetValue("Setting/TargetSub");
            Dir.DirectoryCopy(ResouceMainPath, TargetMainPath, true);
            Dir.DirectoryCopy(ResouceSubPath, TargetSubPath, true);



            Console.Read();
        }
    }
}
