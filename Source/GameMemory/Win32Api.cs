using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GameEngine
{
    public interface IMemoryManager
    {
        void ReadProcessMemory(int address, byte[] buffer, int size);
        void WriteProcessMemory(int address, byte[] buffer, int size);  
    }

    internal class Win32Api
    {
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int size, out int numBytesRead);
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(
            IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int size, out int numBytesWrite);  
    }

    public class Win32ApiHelper : IMemoryManager
    {
        private IntPtr _hProcess;

        public Win32ApiHelper(IntPtr hProcess)
        {
            if (hProcess == null)
            {
                throw new ArgumentNullException();
            }
            this._hProcess = hProcess;
        }

        public void ReadProcessMemory(int address, byte[] buffer, int size = 2)
        {
            int numBytesRead;
            Win32Api.ReadProcessMemory(this._hProcess, new IntPtr(address), buffer, size, out numBytesRead);
        }

        public void WriteProcessMemory(int address, byte[] buffer, int size = 2)
        {
            int numBytesWrite;
            Win32Api.WriteProcessMemory(this._hProcess, new IntPtr(address), buffer, size, out numBytesWrite);
        }
    }
}
