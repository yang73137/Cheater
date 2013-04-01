using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace GameEngine
{
    internal class Win32Api
    {
        public struct MEMORY_BASIC_INFORMATION
        {
            public int BaseAddress;
            public int AllocationBase;
            public int AllocationProtect;
            public int RegionSize;
            public int State;
            public int Protect;
            public int lType;
        }

        public const int MEM_COMMIT = 0x1000;
        public const int PAGE_READWRITE = 0x04;

        [DllImport("kernel32.dll")]     //查询内存块信息  
        public static extern int VirtualQueryEx(
            IntPtr hProcess, IntPtr lpAddress, out MEMORY_BASIC_INFORMATION lpBuffer, int dwLength);
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int size, out int numBytesRead);
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(
            IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int size, out int numBytesWrite);  
    }

    internal class Win32ApiHelper
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
    }
}
