using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace Terminator
{
    class Editor
    {
        public const uint DELETE = 0x00010000;
        public const uint READ_CONTROL = 0x00020000;
        public const uint WRITE_DAC = 0x00040000;
        public const uint WRITE_OWNER = 0x00080000;
        public const uint SYNCHRONIZE = 0x00100000;
        public const uint END = 0xFFF;
        public const uint PROCESS_ALL_ACCESS = (DELETE | READ_CONTROL | WRITE_DAC | WRITE_OWNER | SYNCHRONIZE | END);

        static public Process targetedProcess;

        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll",CallingConvention=CallingConvention.Winapi, SetLastError=true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReadProcessMemory(int hProcess, IntPtr lpBaseAddress, byte[] buffer, IntPtr size, int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(int hProcess, IntPtr lpBaseAddress, byte[] buffer, IntPtr size, int lpNumberOfBytesWritten);

        static public Process targetProcess(string name, int index = 0)
        {
            return (targetedProcess = Process.GetProcessesByName(name)[index]);
        }

        static public int getHandle(Process proc, uint access = PROCESS_ALL_ACCESS)
        {
            return OpenProcess(access, false, proc.Id);
        }

        public byte[] getBytesFromString(string str)
        {
            return Encoding.Unicode.GetBytes(str);
        }

        static public string getStringFromBytes(byte[] byteArr)
        {
            return Encoding.Unicode.GetString(byteArr);
        }

        public int makeHex(string str)
        {
            return (int.Parse(str, System.Globalization.NumberStyles.HexNumber));
        }

        static public byte[] ReadMemory(IntPtr address, IntPtr processSize)
        {
            byte[] buffer = new byte[(int)processSize];
            ReadProcessMemory(getHandle(targetedProcess), address, buffer, processSize, 0);
            return buffer;
        }

        public List<int> GetAddress(byte[] memory, int index = 0)
        {
            List<int> buf = new List<int>();

            for (int i = 0; i < int.MaxValue; i++)
            {
                IntPtr hex = new IntPtr(makeHex(i.ToString()));
                if (ReadMemory(hex, new IntPtr(1)) == memory)
                    buf.Add(i);

            }
            return buf;
        }

        public void WriteMemory(IntPtr address, byte[] processBytes, IntPtr size)
        {
            WriteProcessMemory(getHandle(targetedProcess), address, processBytes, size, 0);
        }
    }
}
