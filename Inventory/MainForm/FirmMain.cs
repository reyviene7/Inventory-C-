using System;
using System.Drawing;
using System.Windows.Forms;
using Inventory.PopupForm;
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
        private readonly string _userName;
        private   string _optionsDirection = "down";
        private   string _toastDirection = "down";
        private   string _rightDirection = "right";
        const int type = Config.Constant.ReportDepotDelivery;
        //For animated panels timeout
        private int _optionsTimeOut;
        private int _rightTimeOut;
        //For animated panels position
        private readonly int _optionsX;

        private int optionsY;
        private int rightX;
        private readonly int _rightY;

        public string ToastDirection { get => _toastDirection; set => _toastDirection = value; }

        public FirmMain(int userId, int usrTyp, string username)
        {
            _userName = username;
            _userId = userId;
            _usrTyp = usrTyp;
            InitializeComponent();
        }

        private void FirmMain_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            // PanelInterface.SetMainPanelPosition(this, pnlMain);
            SetMainPanelPosition();
            PanelInterface.SetMainPanelPosition(this, tileControl);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            pnlRightOptions.BringToFront();
            pnlOptions.BringToFront();
            Options.Start();
            RightOptions.Start();
            FirstColumn.Start();
            pnlOptions.Focus();
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            if (_rightTimeOut < 500)
            {
                _rightTimeOut++;
            }
            if (_rightTimeOut == 500)
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
        private void Options_Tick(object sender, EventArgs e)
        {
            if (_optionsTimeOut < 500)
            {
                _optionsTimeOut++;
            }
            if (_optionsTimeOut == 500)
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

        private void pbExit_Click(object sender, EventArgs e)
        {
            Constant.ApplicationExit();
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMessageQuestion("Are you sure you want to Logoff?", Messages.InventorySystem);
            if (que)
            {
                var log = new FirmLogin();
                Close();
                log.Show();
            }
        }

        private void tileCAT_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var cat = new FirmCategory(_userId, _usrTyp)
            {
                Main = this
            };
            if (cat.DialogResult == DialogResult.OK)
            {
                cat.Show();
                Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void tilePRO_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var proc = new FirmProducts(_userId, _usrTyp)
            {
                Main = this
            };
            if (proc.DialogResult == DialogResult.OK)
            {
                Hide();
                proc.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void tileDEP_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var warehouseInventory = new FirmWarehouseInvetory(_userId, _usrTyp, _userName)
            {
                Main = this
            };
            if (warehouseInventory.DialogResult == DialogResult.OK)
            {
                warehouseInventory.Show();
                Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void tileWAR_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var dep = new FirmWarehouse(_userId, _usrTyp, _userName)
            {
                Main = this
            };
            if (dep.DialogResult == DialogResult.OK)
            {
                Hide();
                dep.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void tileDFB_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var bra = new FirmWareHouseDelivery(_userId, _usrTyp)
            {
                Main = this
            };
            if (bra.DialogResult == DialogResult.OK)
            {
                Hide();
                bra.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void tileDEV_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var dep = new FrmBranch(_userId, _usrTyp)
            {
                Main = this
            };
            if (dep.DialogResult == DialogResult.OK)
            {
                Hide();
                dep.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void tileDTW_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var ret = new FirmWareHouseReturn(_userId, _usrTyp)
            {
                Main=this
            };
            if (ret.DialogResult == DialogResult.OK)
            {
                Hide();
                ret.Show();
            }
            else
            {
                this.Show();
            }
        }

        private string GetUseFullName(int userId)
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                try
                {
                    var repository = new Repository<ViewUserEmployees>(unWork);
                    return repository.FindBy(x => x.user_id == userId).name;
                }
                catch (Exception e)
                {
                    
                  Console.WriteLine(e.ToString());
                    return null;
                }
            }
        }
        private void tileRDP_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            var view = new FirmPopDateEntries(name, type)
            {
                Main = this
            };
            view.ShowDialog();
        }
        private void tileReportInventoryList_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofInventoryProducts(name);
        }
        private void tileReportProducts_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofProductItem(name);
        }
        private void tileReportWarehouseINV_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);

            var view = new FirmPopDateEntries(name, 1)
            {
                Main = this
            };
            view.ShowDialog();
        }
        private void tileReportWarehouseDEL_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);

            var view = new FirmPopCategoryReport(name, 1)
            {
                Main = this
            };
            view.ShowDialog();
        }
        private void tileReportReturnWare_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            var view = new FirmPopCategoryReport(name, 2)
            {
                Main = this
            };
            view.ShowDialog();
        }
        private void tileReportSales_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var name = GetUseFullName(_userId);
            ReportSetting.ListofSalesItem(name);
        }

        private void tileInventory_itemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var ret = new FrmInventory(_userId, _usrTyp, _userName)
            {
                Main = this
            };
            if (ret.DialogResult == DialogResult.OK)
            {
                ret.Show();
                Hide();
            }
            else
            {
                this.Show();
            }
        }

        private void tileManagement_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            splashScreen.ShowWaitForm();
            var view = new FrmManagement(_userId, _usrTyp, _userName)
            {
                Main = this
            };
            splashScreen.CloseWaitForm();
            if (view.DialogResult == DialogResult.OK)
            {
                view.ShowDialog();
            }
            else
            {
                this.Show();
            }
        }

        private void tileServices_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
 
            var view = new FrmServices(_userId, _usrTyp, _userName)
            {
                Main = this
            };
            if (view.DialogResult == DialogResult.OK)
            {
                view.ShowDialog();
            }
            else
            {
                this.Show();
            }
        }

        private void tileStaffRegistration_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            var view = new FrmRegistration(_userId, _usrTyp)
            {
                Main = this
            };
            if (view.DialogResult == DialogResult.OK)
            {
                view.ShowDialog();
            }
            else
            {
                this.Show();
            }
        }
    }
}