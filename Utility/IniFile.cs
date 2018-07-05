using System;
using System.Collections.Generic;

using System.Runtime.InteropServices;
using System.Text;

namespace Story_Crafter {
    class IniFile {
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern uint GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, string lpReturnedString, int nSize, string lpFileName);
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileStringW", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        private static extern uint WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);

        public string Path;

        public IniFile() { }
        public IniFile(string path) {
            this.Path = path;
        }
        public string Read(string section, string key, int bufferSize = 256) {
            string data = new string(' ', bufferSize);
            IniFile.GetPrivateProfileString(section, key, "", data, bufferSize, this.Path);
            return data.Substring(0, data.IndexOf('\0'));
        }
        public void Write(string section, string key, string value) {
            IniFile.WritePrivateProfileString(section, key, value, this.Path);
        }
    }
}
