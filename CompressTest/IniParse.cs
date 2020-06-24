using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CompressTest
{
    //とてつもなく簡易なIniParser
    public class IniParse
    {
        [DllImport("KERNEL32.DLL")]
        public static extern uint GetPrivateProfileString(
                string lpAppName,
                string lpKeyName, string lpDefault,
                StringBuilder lpReturnedString, uint nSize,
                string lpFileName
            );
        private string FileName { get; set; }
        public IniParse(string FileName)
        {
            this.FileName = FileName;
        }
        public string GetValue(string key)
        {
            string[] SecKey = key.Split('/');
            StringBuilder value = new StringBuilder(1024);
            GetPrivateProfileString(
                    SecKey[0],
                    SecKey[1],
                    "0",
                    value,
                    Convert.ToUInt32(value.Capacity),
                    this.FileName
                );
            return value.ToString();
        }
    }
}
