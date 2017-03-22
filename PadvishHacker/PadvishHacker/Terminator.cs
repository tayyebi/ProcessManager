using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Terminator
{
    class Terminator
    {
        static public void Terminate(int Id)
        {
            Process prs = Process.GetProcessById(Id);
            try
            {
                prs.Kill();
            }
            catch
            {
                Console.WriteLine("Cannot terminate the Process: " + prs.ProcessName);
            }
        }
    }
}
