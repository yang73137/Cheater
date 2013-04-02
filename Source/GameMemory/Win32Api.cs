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

        public int ReadProcessMemory(int address)
        {
            byte[] buffer = new byte[4];
            int numBytesRead;
            Win32Api.ReadProcessMemory(this._hProcess, new IntPtr(address), buffer, 2, out numBytesRead);
            return BitConverter.ToInt32(buffer, 0);
        }

        public void WriteProcessMemory(int address, int value)
        {
            byte[] buffer = BitConverter.GetBytes(value);
            int numBytesWrite;
            Win32Api.WriteProcessMemory(this._hProcess, new IntPtr(address), buffer, 2, out numBytesWrite);
        }

        public void ReadProcessMemory(int address, byte[] buffer, int size)
        {
            int numBytesRead;
            Win32Api.ReadProcessMemory(this._hProcess, new IntPtr(address), buffer, 2, out numBytesRead);
        }

        public void WriteProcessMemory(int address, byte[] buffer, int size)
        {
            int numBytesWrite;
            Win32Api.WriteProcessMemory(this._hProcess, new IntPtr(address), buffer, 2, out numBytesWrite);
        }
    }
}
