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
            Console.WriteLine("ファイル更新を開始します。よろしいですか?");
            if(Console.ReadLine() == "1")
            {
                Console.WriteLine("開始します");
            }
            else
            {
                Environment.Exit(0);
            }
            IniParse ini = new IniParse("./Setting.ini");
            string ResouceMainPath = ini.GetValue("Setting/ResouceMain");
            string ResouceSubPath = ini.GetValue("Setting/ResouceSub");
            string TargetMainPath = ini.GetValue("Setting/TargetMain");
            string TargetSubPath = ini.GetValue("Setting/TargetSub");
            string WorkPath = ini.GetValue("Setting/WorkDirectory");

            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, WorkPath)))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, WorkPath));
            }
            else
            {
                WorkDirInit(WorkPath);
            }


            ZipManager zipmgr = new ZipManager(args[0]);
            zipmgr.Unpack(ResouceMainPath, TargetMainPath, WorkPath);
            WorkDirInit(WorkPath);
            zipmgr.Unpack(ResouceSubPath, TargetSubPath, WorkPath);
            Directory.Delete(Path.Combine(Environment.CurrentDirectory, WorkPath), true);
            Console.WriteLine("ファイル更新が完了しました。");
            Console.Read();
        }

        static void WorkDirInit(string WorkPath)
        {
            Directory.Delete(Path.Combine(Environment.CurrentDirectory, WorkPath), true);
            Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, WorkPath));
        }
    }
}
