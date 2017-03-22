using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Terminator
{
    class Address
    {
        static public IntPtr Start(int Id)
        {
            Process prs = Process.GetProcessById(Id);
            return prs.MainModule.BaseAddress;
        }
        static public IntPtr End(int Id, IntPtr start)
        {
            Process prs = Process.GetProcessById(Id);
            return new IntPtr(start.ToInt64() + prs.MainModule.ModuleMemorySize);
        }

    }
}
