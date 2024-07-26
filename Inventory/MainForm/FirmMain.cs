using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using Inventory.PopupForm;
using Inventory.Report;
using Inventory.Services;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using Inventory.Config;

namespace Inventory.MainForm
{
    public partial class FirmMain : Form
    {
        public FirmMain Main;
        private readonly int _userId;
        private readonly int _usrTyp;
       
        private   string _optionsDirection = "down";
        private   string _toastDirection = "down";
        private   string _rightDirection = "right";

        //For animated panels timeout
        private int _optionsTimeOut = 0;

        private readonly int toastTimeOut = 0;
        private int _rightTimeOut = 0;
        //For animated panels position
        private readonly int _optionsX;

        private int optionsY;
        private int rightX;
        private readonly int _rightY;
        public FirmMain(int userId, int usrTyp)
        {
            _userId = userId;
            _usrTyp = usrTyp;
            InitializeComponent();
        }

        private void FirmMain_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            // PanelInterface.SetMainPanelPosition(this, pnlMain);
            SetMainPanelPosition();
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            FirstColumn.Start();
            pnlOptions.Focus();
        }
        private void Options_Tick(object sender, EventArgs e)
        {
            if (_optionsTimeOut < 1000)
            {
                _optionsTimeOut++;
            }
            if (_optionsTimeOut == 1000)
            {
                if (_optionsDirection == "up")
                {
                    _optionsDirection = "down";
                }
            }
            if (_optionsDirection == "up")
            {
                if (optionsY > Height - pnlOptions.Height + 3)
                {
                    optionsY -= 3;
                    pnlOptions.Location = new Point(_optionsX, optionsY);
                }
            }
            else
            {
                if (optionsY < Height)
                {
                    optionsY += 3;
                }
                pnlOptions.Location = new Point(_optionsX, optionsY);
            }
        }
        private void FirmMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y >= Height - 15 && e.X < (Width - pnlRightOptions.Width))
            {
                _optionsDirection = "up";
                _rightDirection = "right";
                _optionsTimeOut = 0;
            }
            if (e.X >= Width - 15)
            {
                _rightDirection = "left";
                _rightTimeOut = 0;
                _optionsDirection = "down";


            }
            if (e.X < (Width - pnlRightOptions.Width))
            {
                _rightDirection = "Left";

            }
        }

        private void SetMainPanelPosition()
        {
            var mX = (Width - tileMain.Width) / 2;
            var mY = (Height - tileMain.Height) / 2;
            tileMain.Location = new Point(mX, mY);
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            if (_rightTimeOut < 1000)
            {
                _rightTimeOut++;
            }
            if (_rightTimeOut == 1000)
            {
                if (_rightDirection == "left")
                {
                    _rightDirection = "right";
                }
            }
            if (_rightDirection == "left")
            {
                if (rightX > Width - pnlRightOptions.Width)
                {
                    rightX -= 2;
                    pnlRightOptions.Location = new Point(rightX, _rightY);
                }
            }
            else
            {
                if (rightX < Width)
                {
                    rightX += 2;
                }
                pnlRightOptions.Location = new Point(rightX, _rightY);
            }
        }

        private void pbExit_Click(object sender, EventArgs e)
        {
            Constant.ApplicationExit();
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMessageQuestion("Are you sure you want to Logoff?", Messages.GasulPos);
            if (que)
            {
                var log = new FirmLogin();
                Close();
                log.Show();
            }
        }

        private void tileCAT_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var cat = new FirmCategory()
            {
                Main = this
            };
            Hide();
            cat.Show();
        }

        private void tilePRO_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var proc = new FirmProducts()
            {
                Main = this
            };
            Hide();
            proc.Show();
        }

        private void tileDEP_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var dep = new FirmDepot(_userId, _usrTyp)
            {
                Main = this
            };
            Hide();
            dep.Show();
        }

        private void tileWAR_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var dep = new FirmWarehouse(_userId, _usrTyp)
            {
                Main = this
            };
            Hide();
            dep.Show();
        }

        private void tileDFB_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var bra = new FirmWareHouseDelivery(_userId, _usrTyp)
            {
                Main = this
            };
            Hide();
            bra.Show();
        }

        private void tileDEV_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var dep = new FirmDepotReturn(_userId, _usrTyp)
            {
                Main = this
            };
            Hide();
            dep.Show();
        }

        private void tileDTW_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var ret = new FirmWareHouseReturn(_userId, _usrTyp)
            {
                Main=this
            };
            Hide();
            ret.Show();
        }

       

        private void tileDEL_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            const int type = Config.Constant.ReportDepotDelivery;
            var view = new FirmPopDateEntries(name, type)
            {
                Main = this
            };
            view.ShowDialog();
        }

        private string GetUseFullName(int userId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewUserEmployees>(unWork);
                    return repository.FindBy(x => x.UserId == userId).Name;
                }
                catch (Exception e)
                {
                    
                  Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }

        private void tileINV_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            const int type = Config.Constant.ReportWareHouseItem;
            var view = new FirmPopDateEntries(name, type)
            {
                Main = this
            };
            view.ShowDialog();
        }

        private void tileWDL_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            const int type = Config.Constant.ReportWareHouseDelr;
            var view = new FirmPopCategoryReport(name, type)
            {
                Main = this
            };
            view.ShowDialog();
        }

        private void tileRET_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            const int type = Config.Constant.ReportReturnWarehos;
            var view = new FirmPopCategoryReport(name, type)
            {
                Main = this
            };
            view.ShowDialog();
        }

        private void tileRDP_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            const int type = Constant.ReportReturnDepotDl;
            var view = new FirmPopDateEntries(name, type)
            {
                Main = this
            };
            view.ShowDialog();
        }

        private void tilePlist_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofProductItem(name);
        }
        private void tileLPG_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofProductLpgs(name);

        }

        private void tileSBD_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            const int type = Constant.ReportSummarWareBra;
            var view = new FirmPopCategoryReport(name, type)
            {
                Main = this
            };
            view.ShowDialog();

        }
    }
}
