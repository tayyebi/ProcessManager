using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Terminator
{
    class Program
    {
        static void Main(string[] args)
        {
            string Id;
            string file;
            try
            {
                Id = args[0];
                file = args[1];
            }
            catch
            {
                Console.WriteLine("Enter the process ID: ");
                Id = Console.ReadLine();

                Console.WriteLine("\nEnter the output filename:");
                file = Console.ReadLine();
            }

            Process[] prs = Process.GetProcesses();
            foreach (Process pr in prs)
            {
                if (pr.Id.ToString() == Id.ToLower())
                {
                    try
                    {
                        IntPtr start = Address.Start(pr.Id);
                        IntPtr end = Address.End(pr.Id, start);
                        IntPtr size = new IntPtr(end.ToInt64() - start.ToInt64());
                        end = new IntPtr(0);

                        byte[] buffer = new byte[(int)size];
                        Editor.ReadProcessMemory(Editor.getHandle(pr), start, buffer, size, 0);

                        System.IO.File.WriteAllText(file, System.Text.Encoding.UTF8.GetString(buffer));

                        Array.Clear(buffer, 0, (int)size);

                        try
                        {
                            Editor.WriteProcessMemory(Editor.getHandle(pr), start, buffer, size, 0);
                        }
                        catch { }

                        buffer = null;
                    }
                    catch { }
                    try
                    {
                        Terminator.Terminate(pr.Id);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Crash...{0}", ex.Message);
                    }
                }
            }
        }
    }
}