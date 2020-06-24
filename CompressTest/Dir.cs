using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressTest
{
    public static class Dir
    {
        public static void DirectoryCopy(string srcDirName, string dstDirName, bool OverWrite)
        {
            // コピー元ディレクリが存在しない場合、終了します。
            if (!Directory.Exists(srcDirName)) return;


            // コピー先ディレクトリが存在しない場合
            if (!Directory.Exists(dstDirName))
            {
                // コピー先ディレクトリを作成します。
                Directory.CreateDirectory(dstDirName);
            }

            // コピー元ディレクトリ内のファイルを取得します。
            var srcDir = new DirectoryInfo(srcDirName);
            var srcFiles = srcDir.GetFiles();
            foreach (var srcFile in srcFiles)
            {
                // コピー元ディレクトリ内のファイルをコピー先ディレクトリにコピーします。
                var dstFile = Path.Combine(dstDirName, srcFile.Name);

                // コピー先に対象のファイルが存在する場合、次のファイルへ。
                if (!OverWrite) continue;

                // ファイルをコピーします。
                srcFile.CopyTo(dstFile, OverWrite);
            }

            // サブディレクトリもコピーする場合
            if (true)
            {
                // コピー元ディレクトリのサブディレクトリを取得します。
                var srcSubDirs = srcDir.GetDirectories();
                foreach (var srcSubDir in srcSubDirs)
                {
                    // このメソッドを再帰呼出しして、サブディレクトリをコピーします。
                    var dstDirPath = Path.Combine(dstDirName, srcSubDir.Name);
                    DirectoryCopy(srcSubDir.FullName, dstDirPath, OverWrite);
                }
            }
        }
    }
}
