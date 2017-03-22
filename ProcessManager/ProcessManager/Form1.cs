using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;

namespace ProcessManager
{
    public partial class MainForm : Form
    {
        private string strKeyRestrictRun = @"Software\Microsoft\Windows\CurrentVersion\Policies\Explorer\RestrictRun";

        public MainForm()
        {
            InitializeComponent();
        }

        private void Details(int Id)
        {
            if (pl)
            {
                Process process = Process.GetProcessById(Id);
                PathTextBox.Text = process.Modules[0].FileName;
            }
            else
            {
                PathTextBox.Text = "";
            }
        }
        private bool pl = true;

        private void RefreshProcess()
        {
            pl = true;

            Process[] allProcess = Process.GetProcesses();

            List.Items.Clear();
            List.Columns.Clear();

            List.View = View.Details;
            List.Columns.Add("Index", 40, HorizontalAlignment.Left);
            List.Columns.Add("Id", 80, HorizontalAlignment.Left);
            List.Columns.Add("Start Time", 100, HorizontalAlignment.Left);
            List.Columns.Add("Name", 125, HorizontalAlignment.Left);

            int x = 0;
            foreach (Process process in allProcess)
            {
                x++;
                try
                {
                    string[] prcdetails = new string[] {
                        x.ToString(),
                        process.Id.ToString(),
                        process.StartTime.ToShortTimeString(),
                        (process.ProcessName.Split('.')[0])
                    };
                    ListViewItem proc = new ListViewItem(prcdetails);
                    List.Items.Add(proc);
                }
                catch { }
            }

            List.Columns[3].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshProcess();
        }
        public int ProcessId = -1;
        private void ProcessList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem i in List.SelectedItems)
            {
                try
                {
                    if (pl)
                    {
                        ProcessId = Convert.ToInt32(i.SubItems[1].Text);
                        Details(ProcessId);
                    }
                    else
                    {
                        PathTextBox.Text = i.SubItems[0].Text;
                    }
                }
                catch
                {

                }
            }
        }
        private void Terminate(int PID)
        {
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.StartInfo.FileName = Path.GetDirectoryName(Application.ExecutablePath).ToString() + "\\Terminator.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.Arguments = PID.ToString() + " \"buffer.txt\"";
            if (System.Environment.OSVersion.Version.Major >= 6)
            {
                p.StartInfo.Verb = "runas";
            }
            p.Start();
        }
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RefreshProcess();
        }
        private void CheckRegistry()
        {
            using (Microsoft.Win32.RegistryKey key = Registry.CurrentUser.OpenSubKey(strKeyRestrictRun, true))
            {
                if (key.GetValue("regedit.exe") == null)
                    key.SetValue("regedit.exe", "regedit.exe", RegistryValueKind.String);

                if (key.GetValue(Path.GetFileName(Application.ExecutablePath)) == null)
                    key.SetValue(Path.GetFileName(Application.ExecutablePath), Path.GetFileName(Application.ExecutablePath), RegistryValueKind.String);
            }
        }
        private void EnableButton_Click(object sender, EventArgs e)
        {
            try
            {
                CheckRegistry();
            }
            catch
            {
                Microsoft.Win32.RegistryKey key = Registry.CurrentUser.CreateSubKey(strKeyRestrictRun, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }

            Blocker("t");

            CheckRegistry();
            MessageBox.Show("Protection enabled!");
        }
        private void Blocker(string Params)
        {
            Process p = new Process();
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.FileName = Path.GetDirectoryName(Application.ExecutablePath).ToString() + "\\Blocker.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.Arguments = Params;
            if (System.Environment.OSVersion.Version.Major >= 6)
            {
                p.StartInfo.Verb = "runas";
            }
            p.Start();
        }

        private void DisableButton_Click(object sender, EventArgs e)
        {
            try
            {
                CheckRegistry();
            }
            catch
            {
                Microsoft.Win32.RegistryKey key = Registry.CurrentUser.CreateSubKey(strKeyRestrictRun, RegistryKeyPermissionCheck.ReadWriteSubTree);
            }
            Blocker("f");
            CheckRegistry();
            MessageBox.Show("Protection disabled!");
        }
        private void AllowedList()
        {
            try
            {
                pl = false;
                using (Microsoft.Win32.RegistryKey key = Registry.CurrentUser.OpenSubKey(strKeyRestrictRun))
                {
                    List.Items.Clear();
                    List.Columns.Clear();

                    List.View = View.Details;
                    List.Columns.Add("Name");

                    foreach (String subkeyName in key.GetValueNames())
                    {
                        ListViewItem item = new ListViewItem(new string[] {
                            subkeyName
                        });
                        List.Items.Add(item);
                    }
                    List.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                }
            }
            catch
            {
                MessageBox.Show("Cannot access windows settings.");
                Refresh();
            }
        }
        private void ListButton_Click(object sender, EventArgs e)
        {
            AllowedList();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (File.Exists(PathTextBox.Text))
            {
                CheckRegistry();
                Blocker("t t \"" + PathTextBox.Text + "\"");
                CheckRegistry();
            }
            MessageBox.Show("Added to allowed list.");
            AllowedList();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            CheckRegistry();
            Blocker("t f \"" + PathTextBox.Text + "\"");
            CheckRegistry();
            MessageBox.Show("Removed from allowed list.");
            AllowedList();
        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                PathTextBox.Text = dialog.FileName;
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            Process[] explorer = Process.GetProcessesByName("explorer");
            foreach (Process pros in explorer)
            {
                Terminate(pros.Id);
            }
            Process.Start(Path.Combine(Environment.GetEnvironmentVariable("windir"), "explorer.exe"));
        }

        private void TerminateButton_Click(object sender, EventArgs e)
        {
            Terminate(ProcessId);
        }
    }
}
