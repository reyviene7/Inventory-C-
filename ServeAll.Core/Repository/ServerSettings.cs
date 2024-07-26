using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using System.Windows.Forms;
namespace ServeAll.Core.Repository
{
    public class ServerSettings
    {
        public static string CurrentDate()
        {
            return DateTime.Today.ToString("yyyy-MM-dd");
        }

        public static string CurrentTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string CurrentUserLogin()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }
        public static string ServerRegistration()
        {
            var serverName = Registry.GetValue(@"HKEY_CURRENT_USER\Software\iJRT-Software\Serve-All Marketing\System Key", "SERVER", null);
            return serverName?.ToString();
        }

        public static string HardDiskIdRegistration()
        {
            var regHdd = Registry.GetValue(@"HKEY_CURRENT_USER\Software\iJRT Software\Payroll System", "HDD_ID", null);
            return regHdd?.ToString() ?? "None";
        }

        public static string ProcessorIdRegistration()
        {
            var regCpu = Registry.GetValue(@"HKEY_CURRENT_USER\Software\iJRT Software\Payroll System", "CPU_ID", null);
            return regCpu?.ToString() ?? "None";
        }

        //RETURN Drive List 
        public static List<string> HardDiskListing()
        {
            var st = new List<string>();
            var drv = DriveInfo.GetDrives();
            st.AddRange(drv.Select(dv => dv.Name));
            return st;
        }

        public static string YearEnding(string chars)
        {
            var date = CurrentDate();
            var lastD = int.Parse(date.Split('-')[0]).ToString();
            const string rem = "20";
            return lastD.Replace(rem, chars);
        }
        public static void PopUpMessages(int rn, string msgs, string title)
        {
            switch (rn)
            {
                case 0:
                    MessageBox.Show(msgs, title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    break;

                case 1:
                    MessageBox.Show(msgs, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }
}