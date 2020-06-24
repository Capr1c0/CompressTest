using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace CompressTest
{
    public class ZipManager
    {
        private ZipArchive Archive { get; set; }
        public ZipManager(string path)
        {
            Archive = ZipFile.OpenRead(path);
        }

        public void Unpack(string ResouceParenetPath, string TargetParentPath, string WorkDirectory)
        {
            string TmpPath = Path.Combine(Environment.CurrentDirectory, "tmp");
            Debug.WriteLine("Parent=>" + ResouceParenetPath);
            foreach (ZipArchiveEntry z in Archive.Entries)
            {
                //マッチしていたら
                if (Regex.IsMatch(z.FullName, "^" + ResouceParenetPath))
                {
                    //ファイル名が空でないならばファイル
                    if (z.Name != "")
                    {
                        z.ExtractToFile(Path.Combine(TmpPath, z.FullName));
                    }
                    else
                    {
                        //ディレクトリ生成
                        string[] DirPath = z.FullName.Split('/');
                        string Path = TmpPath;
                        foreach (string d in DirPath)
                        {
                            Path += "/" + d;
                            if (!Directory.Exists(Path))
                            {
                                Directory.CreateDirectory(Path);
                            }
                        }
                    }
                }
            }
            string[] Wdir = Directory.GetDirectories(Path.Combine(WorkDirectory, ResouceParenetPath));
            foreach (string w in Wdir)
            {
                string WPath = Path.Combine(TargetParentPath, w).Replace(Path.Combine(WorkDirectory, ResouceParenetPath), string.Empty);

                Dir.DirectoryMove(w, WPath, true);
            }
            string[] Wfile = Directory.GetFiles(Path.Combine(WorkDirectory, ResouceParenetPath), "*");
            foreach (string w in Wfile)
            {
                string WPath = Path.Combine(TargetParentPath, w).Replace(Path.Combine(WorkDirectory, ResouceParenetPath), string.Empty);
                if (File.Exists(WPath))
                {
                    File.Delete(WPath);
                }
                Console.WriteLine("ファイル更新中 -> " + WPath);
                File.Move(w, WPath);
            }
        }
    }
}
