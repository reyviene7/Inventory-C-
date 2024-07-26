using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Win32;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;

namespace Inventory.Config
{
    public class GetSettings
    {

        public static string CurrentDate()
        {
            return DateTime.Today.ToString("yyyy-MM-dd");
        }
        public static string CurrentTime()
        {
            return DateTime.Now.ToString(Constant.TimeFormat);
        }
        public static string CurrentUserLogin()
        {
            return System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }
        public static string ServerRegistration()
        {
            var serverName = Registry.GetValue(Constant.RegKey, Constant.Server, null);
            return serverName?.ToString();
        }
        public static string DefaultUserName()
        {
            var serverName = Registry.GetValue(Constant.RegKey, Constant.UseKey, null);
            return serverName?.ToString();
        }
        public static string DefaultPassWord()
        {
            var serverName = Registry.GetValue(Constant.RegKey, Constant.PasKey, null);
            return serverName?.ToString();
        }

        public static string HardDiskIdRegistration()
        {
            var regHdd = Registry.GetValue(Constant.RegKey, Constant.HddKey, null);
            return regHdd?.ToString() ?? Constant.DefaultReturnNone;
        }

        public static string ProcessorIdRegistration()
        {
            var regCpu = Registry.GetValue(Constant.RegKey, Constant.CpuKey, null);
            return regCpu?.ToString() ?? Constant.DefaultReturnNone;
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

        //SPLIT LAST ID
        public static int GetLastBarcode(string barcode)
        {
            var s = barcode.Split('-')[1];
            if (barcode.Length <= 0 || s.Length <= 0) return 0;
            var number = Regex.Replace(s, @"\D", "");
            var rt = int.Parse(number);
            return rt;
        }

        public static string CurrentCell(GridView gr, string column)
        {
            if (gr.DataRowCount > 0)
            {
                return gr.GetRowCellDisplayText(gr.FocusedRowHandle, gr.Columns[column]).ToString() ?? "None";
            }
            return "None";
        }

        public static void BindData(ComboBox txt, BindingSource binSur, string properties)
        {
            if (binSur != null)
            {
                txt.DataBindings.Clear();
                txt.DataBindings.Add(new Binding("Text", binSur, properties, true, DataSourceUpdateMode.OnPropertyChanged));
            }
        }

        private static int GetLastUserId()
        {
            using (var session = new DalSession())
            {
                var unitWork = session.UnitofWrk;
                unitWork.Begin();
                var repository = new Repository<RouteLog>(unitWork);
                var result = (from b in repository.SelectAll(ServeAll.Core.Queries.Query.AllRouteLogId)
                              orderby b.RouteLogId descending
                              select b.RouteLogId).Take(1).SingleOrDefault();
                return result;
            }
        }

        public static void UpdateRouteLog(int userId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    unWork.Begin();
                    var repository = new Repository<RouteLog>(unWork);
                    var que = repository.Id(GetLastUserId());
                    que.TimeOut = DateTime.Now;
                    var result = repository.Update(que);
                    if (result)
                    {
                        unWork.Commit();
                    }
                    else
                    {
                        unWork.Rollback();
                    }

                }
                catch (Exception ex)
                {
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableUsers);

                }
            }

        }


    }
}
