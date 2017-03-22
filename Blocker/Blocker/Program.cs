using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blocker
{
    class Program
    {
        // enable
        // enable block path
        // enable allow path
        // disable

        // tf tf string

        static void Main(string[] args)
        {
            string FilePath = null;
            bool Allow = false;
            bool Enable = false;

            string strKeyExplorer = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\";
            string strKeyRestrictRun = strKeyExplorer + "RestrictRun";

            RegistryKey keyExplorer, keyRestrictRun;

            keyExplorer = Registry.CurrentUser.OpenSubKey(strKeyExplorer, true);

            try
            {
                string res = args[0];
                if (res == "t")
                    Enable = true;
                else if (res == "f")
                    Enable = false;
            }
            catch
            {
                try
                {
                    Console.WriteLine("Enable protection? (t / f): ");
                    string enable = Console.ReadLine();
                    if (enable == "t")
                        Enable = true;
                    else if (enable == "f")
                        Enable = false;
                }
                catch
                {
                    Environment.Exit(0);
                }
            }
            if (Enable)
            {
                keyExplorer.SetValue("RestrictRun", 1, RegistryValueKind.DWord);

                try
                {
                    string allow = args[1];
                    if (allow == "t")
                        Allow = true;
                    else if (allow == "f")
                        Allow = false;
                }
                catch
                {
                    Console.WriteLine("Allow or block the app? (t/ f): ");
                    string allow = Console.ReadLine();
                    if (allow == "t")
                        Allow = true;
                    else if (allow == "f")
                        Allow = false;
                    else Environment.Exit(0);
                }
                try
                {
                    keyRestrictRun = Registry.CurrentUser.CreateSubKey(strKeyRestrictRun, RegistryKeyPermissionCheck.ReadWriteSubTree);

                    try
                    {
                        FilePath = args[2];
                    }
                    catch
                    {
                        Console.WriteLine("Enter file path: ");
                        FilePath = Console.ReadLine();
                    }

                    string strExists = Convert.ToString(keyRestrictRun.GetValue(FilePath, "None"));
                    string[] splitted = FilePath.Split('\\');

                    if (strExists == "None" && Allow)
                    {
                        keyRestrictRun.SetValue(/*FilePath*/ splitted[splitted.Length - 1], splitted[splitted.Length - 1], RegistryValueKind.String);
                    }


                    else if (!Allow)
                    {
                        keyRestrictRun.DeleteValue(splitted[splitted.Length - 1]);
                    }
                    else Environment.Exit(0);
                }
                catch
                {
                    Environment.Exit(0);
                }
            }
            else if (!Enable)
            {
                keyExplorer.SetValue("RestrictRun", 0, RegistryValueKind.DWord);
            }
        }
    }
}