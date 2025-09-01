using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using Inventory.Config;
using Inventory.Entities;
using ServeAll.Core.Entities;
using ServeAll.Core.Entities.request;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using ServeAll.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Inventory.MainForm
{
    public partial class FrmServices : Form
    {
        private int _deliver;
        private readonly int _userId;
        private readonly int _userTyp;
        private readonly string _userName;
        private int breakdownId;
        private IEnumerable<ServeAll.Entities.ViewReportProductList> _products;
        private IEnumerable<ViewRequestCategory> _category;
        private IEnumerable<ViewRequestStaff> _staff;
        private IEnumerable<ViewProfileEnt> _profile;
        private IEnumerable<ServiceStatus> _service_statuses;
        private IEnumerable<ViewServices> _services_list;
        private IEnumerable<ViewCashBreakdown> _breakdown_list;
        private IEnumerable<ViewServiceImages> _service_image_list;
        private IEnumerable<Warehouse> _warehouse;
        public int Deliver
        {
            get { return _deliver; }
            set
            {
                _deliver = value;
                if (_deliver > 0)
                {

                }
            }
        }
        private bool _extInvent;
        public bool ExiInven
        {
            get { return _extInvent; }
            set
            {
                _extInvent = value;
                if (_extInvent)
                    Close();
                FirmMain main = new FirmMain(_userId, _userTyp, _userName);
                main.Show();
            }
        }
        private FirmMain _main;
        private bool _add, _edt, _del, _serv, cash;
        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }
        public FrmServices(int userId, int userTy, string username)
        {
            _userName = username;
            _userId = userId;
            _userTyp = userTy;
            if (_userTyp != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
            _services_list = EnumerableUtils.getServicesList();
            _service_image_list = EnumerableUtils.getServiceImgList();
            _breakdown_list = EnumerableUtils.getBreakdownList();
            gridServices.FocusedRowChanged += gridInventory_FocusedRowChanged;
            gridServices.Click += gridInventory_Click;
        }

        private void FirmWarehouseInvetory_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            _products = EnumerableUtils.getProductWarehouseList();
            _category = EnumerableUtils.getRequestCategoryList();
            _staff = EnumerableUtils.getStaffList();
            _profile = EnumerableUtils.getProfileEntity();
            _service_statuses = EnumerableUtils.getServiceStatusList();
            _warehouse = EnumerableUtils.getWarehouse();
            _services_list = EnumerableUtils.getServicesList();
            xInventory.SelectedTabPage = tabServices;
            _serv = true;
            cash = false;
            bindServices();
            RefreshBreakdown();
        }
        private ViewServiceImages searchServiceImg(string param)
        {
            return _service_image_list.FirstOrDefault(img => img.image_code == param);
        }

        private void gridInventory_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridServices.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                    if (id.Length > 0)
                    {
                        var barcode = ((GridView)sender).GetFocusedRowCellValue("BARCODE").ToString();
                        cmbOperator.Text = _userName;
                        txtServiceId.Text = id;
                        txtServiceName.Text = ((GridView)sender).GetFocusedRowCellValue("SERVICE").ToString();
                        txtServiceDescription.Text = ((GridView)sender).GetFocusedRowCellValue("DETAILS").ToString();
                        cmbServiceCategory.Text = ((GridView)sender).GetFocusedRowCellValue("CATEGORY").ToString();
                        txtServiceCharges.Text = ((GridView)sender).GetFocusedRowCellValue("CHARGES").ToString();
                        txtServiceCommision.Text = ((GridView)sender).GetFocusedRowCellValue("COMMISSION").ToString();
                        cmbOperator.Text = ((GridView)sender).GetFocusedRowCellValue("USER").ToString();
                        cmbStaff.Text = ((GridView)sender).GetFocusedRowCellValue("STAFF").ToString();
                        cmbServiceStatus.Text = ((GridView)sender).GetFocusedRowCellValue("STATUS").ToString();
                        txtBarcode.Text = barcode;
                        txtServiceImgBarcode.Text = barcode;
                        txtServiceImgTitle.Text = ((GridView)sender).GetFocusedRowCellValue("SERVICE").ToString();
                        dpkServiceDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("DATE");
                        dpkCreatedDate.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("CREATED");
                        dpkUpdated.Value = (DateTime)((GridView)sender).GetFocusedRowCellValue("UPDATED");

                        var img = searchServiceImg(barcode);
                        var imgLocation = img?.img_location;

                        if (img == null || string.IsNullOrEmpty(imgLocation))
                        {
                            imgProduct.ImageLocation = ConstantUtils.defaultImgEmpty;
                            imgServiceImages.ImageLocation = ConstantUtils.defaultImgEmpty;
                        }
                        else
                        {
                            var location = ConstantUtils.defaultImgLocation + imgLocation;
                            imgProduct.BackColor = Color.White;
                            imgServiceImages.BackColor = Color.White;
                            imgProduct.ImageLocation = location;
                            imgServiceImages.ImageLocation = location;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private void gridInventory_Click(object sender, EventArgs e)
        {
            if (gridServices.RowCount > 0)
                InputWhit();
            bntCancel.Enabled = true;
        }

        private void addInventory()
        {
            var category = cmbServiceCategory.Text.Trim(' ');
            var staff = cmbStaff.Text.Trim(' ');
            var operators = cmbOperator.Text.Trim(' ');
            var statusId = FetchUtils.getServiceStatusId(cmbServiceStatus.Text.Trim(' '));
            var staffId = FetchUtils.getProfileId(staff);
            if (staffId > 0 || statusId > 0)
            {
                var categoryId = FetchUtils.getCategoryId(category);
                var operatorId = FetchUtils.getUserId(operators);
                ServeAll.Core.Entities.Services services = new ServeAll.Core.Entities.Services
                {
                    service_code = txtBarcode.Text.Trim(' '),
                    service_name = txtServiceName.Text.Trim(' '),
                    service_details = txtServiceDescription.Text.Trim(' '),
                    service_charges = decimal.Parse(txtServiceCharges.Text.Trim(' ')),
                    category_id = categoryId,
                    service_commission = decimal.Parse(txtServiceCommision.Text.Trim(' ')),
                    user_id = operatorId,
                    profile_id = staffId,
                    status_id = statusId,
                    service_date = dpkServiceDate.Value.Date,
                    created_date = dpkCreatedDate.Value.Date,
                    updated_date = dpkUpdated.Value.Date
                };
                var result = RepositoryEntity.AddEntity<ServeAll.Core.Entities.Services>(services);
                if (result > 0L)
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Service Name: " + txtServiceName.Text.Trim(' ') + " " + Messages.SuccessInsert,
                         Messages.TitleSuccessInsert);
                }
                else
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Service Name: " + txtServiceName.Text.Trim(' ') + " " + Messages.ErrorInsert,
                            Messages.TitleFailedInsert);
                }
            }
            else
            {
                splashScreen.CloseWaitForm();
                PopupNotification.PopUpMessages(0, "Status Id and Staff Id must not be null!",
                            Messages.TitleFailedInsert);
            }
        }

        private void addBreakdown()
        {
            try
            {
                int profileId = FetchUtils.getProfileIdByUserId(_userId);
                if (profileId <= 0)
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, "Unable to resolve profile for the current user.",
                                Messages.TitleFailedInsert);
                    return;
                }

                int b1000 = int.TryParse(txtThousand.Text.Trim(), out var v1000) ? v1000 : 0;
                int b500 = int.TryParse(txtFive.Text.Trim(), out var v500) ? v500 : 0;
                int b200 = int.TryParse(txtTwo.Text.Trim(), out var v200) ? v200 : 0;
                int b100 = int.TryParse(txtHundred.Text.Trim(), out var v100) ? v100 : 0;
                int b50 = int.TryParse(txtFifty.Text.Trim(), out var v50) ? v50 : 0;
                int b20 = int.TryParse(txtTwenty.Text.Trim(), out var v20) ? v20 : 0;

                decimal coins = decimal.TryParse(txtCoins.Text.Trim(), out var vCoins) ? vCoins : 0m;
                decimal total = decimal.TryParse(txtTotal.Text.Trim(), out var vTotal) ? vTotal : 0m;

                var breakdown = new ServeAll.Core.Entities.CashBreakdown
                {
                    b1000 = b1000,
                    b500 = b500,
                    b200 = b200,
                    b100 = b100,
                    b50 = b50,
                    b20 = b20,
                    coins = coins,
                    total = total,
                    profile_id = profileId,
                    date_register = DateTime.Now,
                    date_update = DateTime.Now
                };

                var result = RepositoryEntity.AddEntity<ServeAll.Core.Entities.CashBreakdown>(breakdown);

                splashScreen.CloseWaitForm();

                if (result > 0L)
                {
                    PopupNotification.PopUpMessages(1,
                        $"Cash breakdown saved successfully. Total = {total:C}",
                         Messages.TitleSuccessInsert);
                }
                else
                {
                    PopupNotification.PopUpMessages(0,
                        "Failed to insert cash breakdown.",
                        Messages.TitleFailedInsert);
                }
            }
            catch (Exception ex)
            {
                splashScreen.CloseWaitForm();
                PopupNotification.PopUpMessages(0,
                    $"Error while saving cash breakdown: {ex.Message}",
                    Messages.TitleFailedInsert);
            }
        }


        private void editInventory()
        {
            var serviceId = int.Parse(txtServiceId.Text.Trim(' '));
            if (serviceId > 0)
            {
                int result = RepositoryEntity.UpdateEntity<ServeAll.Core.Entities.Services>(serviceId, entity =>
                {
                    entity.service_code = txtBarcode.Text.Trim(' ');
                    entity.service_name = txtServiceName.Text.Trim(' ');
                    entity.service_details = txtServiceDescription.Text.Trim(' ');
                    entity.service_charges = decimal.Parse(txtServiceCharges.Text);
                    entity.category_id = FetchUtils.getCategoryId(cmbServiceCategory.Text.Trim(' '));
                    entity.service_commission = decimal.Parse(txtServiceCommision.Text);
                    entity.user_id = FetchUtils.getUserId(cmbOperator.Text);
                    entity.profile_id = FetchUtils.getProfileId(cmbStaff.Text);
                    entity.status_id = FetchUtils.getServiceStatusId(cmbServiceStatus.Text);
                    entity.service_date = dpkServiceDate.Value.Date;
                    entity.created_date = dpkCreatedDate.Value.Date;
                    entity.updated_date = dpkUpdated.Value.Date;
                });
                if (result > 0)
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Service Name: " + txtServiceName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                           Messages.TitleSuccessUpdate);
                }
                else
                {
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, "Service Name: " + txtServiceName.Text.Trim(' ') + " " + Messages.ErrorUpdate,
                            Messages.TitleFialedUpdate);
                }
            }
        }

        private void editBreakdown()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<CashBreakdown>(unWork);
                    var que = repository.Id(breakdownId);

                    if (que == null)
                    {
                        PopupNotification.PopUpMessages(0,
                            "Cash Breakdown record not found!",
                            Messages.TitleFialedUpdate);
                        return;
                    }

                    que.b1000 = int.TryParse(txtThousand.Text.Trim(), out var v1000) ? v1000 : 0;
                    que.b500 = int.TryParse(txtFive.Text.Trim(), out var v500) ? v500 : 0;
                    que.b200 = int.TryParse(txtTwo.Text.Trim(), out var v200) ? v200 : 0;
                    que.b100 = int.TryParse(txtHundred.Text.Trim(), out var v100) ? v100 : 0;
                    que.b50 = int.TryParse(txtFifty.Text.Trim(), out var v50) ? v50 : 0;
                    que.b20 = int.TryParse(txtTwenty.Text.Trim(), out var v20) ? v20 : 0;
                    que.coins = decimal.TryParse(txtCoins.Text.Trim(), out var vCoins) ? vCoins : 0m;

                    que.total = (que.b1000 * 1000) + (que.b500 * 500) + (que.b200 * 200) +
                                (que.b100 * 100) + (que.b50 * 50) + (que.b20 * 20) + que.coins;

                    que.profile_id = FetchUtils.getProfileIdByUserId(_userId);

                    que.date_update = DateTime.Now;

                    var result = repository.Update(que);

                    if (result)
                    {
                        splashScreen.CloseWaitForm();
                        PopupNotification.PopUpMessages(1,
                            $"Cash Breakdown updated successfully. Total = {que.total:C}",
                            Messages.TitleSuccessUpdate);

                        unWork.Commit();

                        bindBreakdown();
                    }
                }
                catch (Exception ex)
                {
                    splashScreen.CloseWaitForm();
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0,
                        ex.ToString(),
                        Messages.TitleFialedUpdate);
                }
            }
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            var que = PopupNotification.PopUpMassageLogOff();
            if (que <= 0) return;
            var log = new FirmLogin();
            log.Show();
            Close();
        }
        private void pbHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }
        private void pbExit_Click(object sender, EventArgs e)
        {
            PopupNotification.PopUpMessageExit();
        }

        private void InputWhit()
        {
            txtServiceId.BackColor = Color.White;
            txtServiceName.BackColor = Color.White;
            txtServiceDescription.BackColor = Color.White;
            txtServiceCharges.BackColor = Color.White;
            cmbServiceCategory.BackColor = Color.White;
            txtServiceCommision.BackColor = Color.White;
            txtBarcode.BackColor = Color.White;
            cmbOperator.BackColor = Color.White;
            cmbStaff.BackColor = Color.White;
            cmbServiceStatus.BackColor = Color.White;
        }
        private void InputEnab()
        {
            txtServiceName.Enabled = true;
            txtServiceDescription.Enabled = true;
            txtServiceCharges.Enabled = true;
            cmbServiceCategory.Enabled = true;

            txtServiceCommision.Enabled = true;

            dpkServiceDate.Enabled = true;
            dpkCreatedDate.Enabled = true;
            dpkUpdated.Enabled = true;
            cmbOperator.Enabled = false;
            cmbStaff.Enabled = true;
            cmbServiceStatus.Enabled = true;
        }
        private void InputDisb()
        {
            txtServiceName.Enabled = false;
            txtServiceDescription.Enabled = false;
            txtServiceCharges.Enabled = false;
            cmbServiceCategory.Enabled = false;
            txtServiceCommision.Enabled = false;
            txtBarcode.Enabled = false;
            dpkServiceDate.Enabled = false;
            dpkCreatedDate.Enabled = false;
            dpkUpdated.Enabled = false;
            cmbOperator.Enabled = false;
            cmbStaff.Enabled = false;
            cmbServiceStatus.Enabled = false;
        }
        private void InputClea()
        {
            txtServiceId.Clear();
            txtServiceName.Clear();
            txtServiceDescription.Clear();
            txtServiceCharges.Clear();
            cmbServiceCategory.Text = "";
            txtServiceCommision.Clear();
            txtBarcode.Text = "";
            dpkServiceDate.Value = DateTime.Now.Date;
            dpkCreatedDate.Value = DateTime.Now.Date;
            dpkUpdated.Value = DateTime.Now.Date;
            cmbOperator.Text = "";
            cmbStaff.Text = "";
            cmbServiceStatus.Text = "";
            dpkServiceDate.Value = DateTime.Now.Date;
            cmbOperator.Text = "";
        }
        private void InputDimG()
        {
            txtServiceId.BackColor = Color.DimGray;
            txtServiceName.BackColor = Color.DimGray;
            txtServiceDescription.BackColor = Color.DimGray;
            txtServiceCharges.BackColor = Color.DimGray;
            cmbServiceCategory.BackColor = Color.DimGray;
            txtServiceCommision.BackColor = Color.DimGray;
            txtBarcode.BackColor = Color.DimGray;
            cmbOperator.BackColor = Color.DimGray;
            cmbStaff.BackColor = Color.DimGray;
            cmbServiceStatus.BackColor = Color.DimGray;
        }

        private void InputWhitBreak()
        {
            txtThousand.BackColor = Color.White;
            txtFive.BackColor = Color.White;
            txtTwo.BackColor = Color.White;
            txtHundred.BackColor = Color.White;
            txtFifty.BackColor = Color.White;
            txtTwenty.BackColor = Color.White;
            txtCoins.BackColor = Color.White;
            txtTotal.BackColor = Color.White;
        }
        private void InputEnabBreak()
        {
            txtThousand.Enabled = true;
            txtFive.Enabled = true;
            txtTwo.Enabled = true;
            txtHundred.Enabled = true;
            txtFifty.Enabled = true;
            txtTwenty.Enabled = true;
            txtCoins.Enabled = true;
            txtTotal.Enabled = false;
        }
        private void InputDisbBreak()
        {
            txtThousand.Enabled = false;
            txtFive.Enabled = false;
            txtTwo.Enabled = false;
            txtHundred.Enabled = false;
            txtFifty.Enabled = false;
            txtTwenty.Enabled = false;
            txtCoins.Enabled = false;
            txtTotal.Enabled = false;
        }
        private void InputCleaBreak()
        {
            txtThousand.Clear();
            txtFive.Clear();
            txtTwo.Clear();         
            txtHundred.Clear();
            txtFifty.Clear();
            txtTwenty.Clear();
            txtCoins.Clear();
            txtTotal.Clear();
        }
        private void InputDimGBreak()
        {
            txtThousand.BackColor = Color.DimGray;
            txtFive.BackColor = Color.DimGray;
            txtTwo.BackColor = Color.DimGray;
            txtHundred.BackColor = Color.DimGray;
            txtFifty.BackColor = Color.DimGray;
            txtTwenty.BackColor = Color.DimGray;
            txtCoins.BackColor = Color.DimGray;
            txtTotal.BackColor = Color.DimGray;
        }

        private void DataDelete()
        {
            var ctrlId = Convert.ToInt32(txtServiceId.Text);
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.Services>(unWork);
                    var query = repository.Id(ctrlId);
                    var result = repository.Delete(query);
                    if (!result) return;
                    PopupNotification.PopUpMessages(1, Messages.TableServices + Messages.CodeName +
                                                    txtServiceName.Text.Trim(' ')
                                                    + " " + Messages.SuccessDelete,
                                                    Messages.TitleSuccessDelete);

                    unWork.Commit();
                    splashScreen.CloseWaitForm();
                }
                catch (Exception)
                {

                    unWork.Rollback();
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(0, Messages.ErrorDelete + Messages.TableServices + Messages.ErrorOccurred, Messages.TitleFialedDelete);

                }
            }
        }

        private void DeleteBreakdown()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<CashBreakdown>(unWork);
                    var entity = repository.Id(breakdownId); // get by ID
                    if (entity == null)
                    {
                        PopupNotification.PopUpMessages(0,
                            "Breakdown record not found.",
                            Messages.TitleFialedDelete);
                        return;
                    }

                    var result = repository.Delete(entity);
                    if (!result) return;
                    splashScreen.CloseWaitForm();
                    PopupNotification.PopUpMessages(1,
                        "Cash breakdown with ID " + breakdownId + " deleted successfully.",
                        Messages.TitleSuccessDelete);

                    unWork.Commit();
                }
                catch (Exception)
                {
                    splashScreen.CloseWaitForm();
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0,
                        "Error deleting breakdown record.",
                        Messages.TitleFialedDelete);
                }
            }
        }


        private void clearGrid()
        {
            gridController.DataSource = null;
            gridController.DataSource = "";
            gridServices.Columns.Clear();
        }
        private void clearGridBreak()
        {
            gridCtrlBreakdown.DataSource = null;
            gridCtrlBreakdown.DataSource = "";
            gridBreakdown.Columns.Clear();
        }

        private void ButAdd()
        {
            ButtonAdd();
            cmbStaff.Text = Constant.DefaultSource;
            _add = true;
            _edt = false;
            _del = false;
            InputClea();
            gridController.Enabled = false;
            imgProduct.DataBindings.Clear();
            imgProduct.Image = null;
            imgServiceImages.DataBindings.Clear();
            imgServiceImages.Image = null;
            if (_serv && cash == false)
            {
                InputEnab();
                InputWhit();
                InputClea();
                generateLastServiceCode();
                GenerateNewServiceId();
                txtServiceName.Focus();
                cmbServiceCategory.DataSource = _category.Select(p => p.category_details).ToList();
                cmbStaff.DataSource = _profile.Select(p => p.name).ToList();
                cmbServiceStatus.DataSource = _service_statuses.Select(p => p.status_name).ToList();
            }
            if (_serv == false && cash)
            {
                InputEnabBreak();
                InputWhitBreak();
                InputCleaBreak();
                txtThousand.Focus();
            }
            cmbOperator.Text = _userName;
        }
        private void ButtonAdd()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = false;
            bntDelete.Enabled = false;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonUpd()
        {
            bntAdd.Enabled = false;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = false;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonDel()
        {
            bntAdd.Enabled = false;
            bntUpdate.Enabled = false;
            bntDelete.Enabled = true;
            bntSave.Enabled = true;
            bntClear.Enabled = false;
            bntCancel.Enabled = true;
            bntHome.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
        }
        private void ButtonSav()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = true;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonClr()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = false;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButtonCan()
        {
            bntAdd.Enabled = true;
            bntUpdate.Enabled = true;
            bntDelete.Enabled = true;
            bntSave.Enabled = false;
            bntClear.Enabled = true;
            bntCancel.Enabled = false;
            bntHome.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
        }
        private void ButUpd()
        {
            ButtonUpd();
            _add = false;
            _edt = true;
            _del = false;
            if (_serv && cash == false)
            {
                InputEnab();
                InputWhit();
                gridController.Enabled = false;
                txtServiceName.Focus();
            }
            else if (_serv == false && cash)
            {
                InputEnabBreak();
                InputWhitBreak();
                gridCtrlBreakdown.Enabled = false;
                txtThousand.Focus();
            }
        }
        private void ButDel()
        {
            ButtonDel();
            InputDisb();
            InputWhit();
            InputDisbBreak();
            InputWhitBreak();
            _add = false;
            _edt = false;
            _del = true;
            gridController.Enabled = false;
            gridCtrlBreakdown.Enabled = false;
        }
        private void ButSav()
        {
            splashScreen.ShowWaitForm();
            if (_add && _edt == false && _del == false && cash == false)
            {
                addInventory();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            if (_add == false && _edt && _del == false && cash == false)
            {

                editInventory();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            if (_add == false && _edt == false && _del && cash == false)
            {
                DataDelete();
                ButtonSav();
                InputDisb();
                InputDimG();
                InputClea();
            }
            if (_add && _edt == false && _del == false && _serv == false)
            {
                addBreakdown();
                ButtonSav();
                InputDisbBreak();
                InputDimGBreak();
                InputCleaBreak();
            }
            if (_add == false && _edt && _del == false && _serv == false)
            {

                editBreakdown();
                ButtonSav();
                InputDisbBreak();
                InputDimGBreak();
                InputCleaBreak();
            }
            if (_add == false && _edt == false && _del && _serv == false)
            {
                DeleteBreakdown();
                ButtonSav();
                InputDisbBreak();
                InputDimGBreak();
                InputCleaBreak();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridController.Enabled = true;
            gridCtrlBreakdown.Enabled = true;
            imgProduct.DataBindings.Clear();
            imgProduct.Image = null;
            imgServiceImages.DataBindings.Clear();
            imgServiceImages.Image = null;
            _services_list = EnumerableUtils.getServicesList();
            bindServices();
            RefreshBreakdown();
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisb();
            InputDimG();
            InputClea();
            InputDisbBreak();
            InputDimGBreak();
            InputCleaBreak();
            gridController.Enabled = true;
            gridCtrlBreakdown.Enabled = true;
            imgProduct.DataBindings.Clear();
            imgProduct.Image = null;
            _services_list = EnumerableUtils.getServicesList();
            bindServices();
            RefreshBreakdown();
        }
        private void ButClr()
        {
            bindServices();
            RefreshBreakdown();
            ButtonClr();
            InputClea();
            InputWhit();
            InputDisb();
            InputCleaBreak();
            InputWhitBreak();
            InputDisbBreak();
            gridController.Enabled = true;
            gridController.Update();
            gridCtrlBreakdown.Enabled = true;
            gridCtrlBreakdown.Update();
            if (_serv && cash == false)
            {
                int focusedRowHandle = gridServices.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    gridInventory_FocusedRowChanged(
                        gridServices,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(
                            focusedRowHandle,
                            focusedRowHandle
                        )
                    );
                }
            }
            else if (_serv == false && cash)
            {
                int focusedRowHandle = gridBreakdown.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    gridBreakdown_FocusedRowChanged(
                        gridBreakdown,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(
                            focusedRowHandle,
                            focusedRowHandle
                        )
                    );
                }
            }
        }
        private void bntHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void bntAdd_Click(object sender, EventArgs e)
        {
            ButAdd();
        }

        private void bntUpdate_Click(object sender, EventArgs e)
        {
            ButUpd();
        }

        private void bntSave_Click(object sender, EventArgs e)
        {
            ButSav();
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            ButClr();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            ButCan();
            if (_serv && cash == false)
            {
                gridServices.FocusedRowHandle = gridServices.FocusedRowHandle;
            }
            if (_serv == false && cash)
            {
                gridBreakdown.FocusedRowHandle = gridBreakdown.FocusedRowHandle;
            }
        }
        private void bntDelete_Click(object sender, EventArgs e)
        {
            InputWhit();
            var que =
                PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Service Name: " + txtServiceName.Text.Trim(' ') + "?", "Service Details");
            if (que)
            {
                ButDel();
            }
            else { ButCan(); }
        }

        private void FirmWarehouseInvetory_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
        }

        private void txtServiceName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtServiceName, txtServiceDescription, "Service Name",
                Messages.TitleServices);
            }
        }

        private void txtServiceDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(txtServiceDescription, txtServiceCharges, "Service Description",
                Messages.TitleServices);
            }
        }

        private void txtServiceCharges_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtServiceCharges.Text.Length;
                if (len > 0)
                {
                    txtServiceCharges.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtServiceCharges, cmbServiceCategory, "Service Charges",
                    Messages.TitleServices);
                }
                else
                {
                    txtServiceCharges.Text = @"0";
                    txtServiceCharges.BackColor = Color.Yellow;
                    txtServiceCharges.Focus();
                }
                if (txtServiceCharges.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtServiceCharges, cmbServiceCategory, "Service Charges",
                        Messages.TitleProducts);
                }
            }
        }

        private void cmbOperator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbOperator, txtServiceCommision, "Service Operator",
                Messages.TitleServices);
            }
        }

        private void txtServiceCommision_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtServiceCommision.Text.Length;
                if (len > 0)
                {
                    txtServiceCommision.BackColor = Color.White;
                    InputManipulation.InputBoxLeave(txtServiceCommision, cmbStaff, "Service Commission",
                    Messages.TitleServices);
                }
                else
                {
                    txtServiceCommision.Text = @"0";
                    txtServiceCommision.BackColor = Color.Yellow;
                    txtServiceCommision.Focus();
                }
                if (txtServiceCommision.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtServiceCommision, cmbStaff, "Service Commission",
                        Messages.TitleProducts);
                }
            }
        }
        private void cmbServiceStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbServiceStatus.DataBindings.Clear();
                cmbServiceStatus.DataSource = _service_statuses.Select(p => p.status_name).ToList();
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbServiceStatus, bntSave, "Service Status",
                Messages.TitleServices);
            }
        }
        private void cmbServiceCategory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbServiceCategory.DataBindings.Clear();
                cmbServiceCategory.DataSource = _category.Select(p => p.category_details).ToList();
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbServiceCategory, txtServiceCommision, "Service Category",
                Messages.TitleServices);
            }
        }

        private void cmbStaff_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                cmbStaff.DataBindings.Clear();
                cmbStaff.DataSource = _profile.Select(p => p.name).ToList();
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                InputManipulation.InputBoxLeave(cmbStaff, cmbServiceStatus, "Service Staff",
                Messages.TitleServices);
            }
        }

        private void pcUser_Click(object sender, EventArgs e)
        {
            ButUpd();
        }

        private void bntBrowseImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png;*.gif)|*.bmp;*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    string fileNameAndExtension = getfileExntesion(selectedFilePath);
                    txtServiceImgFileName.Text = fileNameAndExtension;

                    if (imgServiceImages.Image != null)
                    {
                        imgServiceImages.Image.Dispose();
                        imgServiceImages.Image = null;
                    }

                    try
                    {
                        using (FileStream fs = new FileStream(selectedFilePath, FileMode.Open, FileAccess.Read))
                        {
                            using (Image temp = Image.FromStream(fs))
                            {
                                imgServiceImages.Image?.Dispose();
                                imgServiceImages.Image = new Bitmap(temp);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        PopupNotification.PopUpMessages(0, "Image Load Failed: " + ex.Message, "Load Error");
                        imgServiceImages.Image = null;
                        return;
                    }

                    bntSaveImages.Enabled = true;
                }
            }
        }

        private string getfileExntesion(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void bntSaveImages_Click(object sender, EventArgs e)
        {
            var code = txtServiceImgBarcode.Text.Trim();
            var title = txtServiceImgTitle.Text.Trim();
            var imgType = cmbServiceImgType.Text.Trim();
            var imgLocation = txtServiceImgFileName.Text.Trim();

            if (code.Length > 0 && title.Length > 0 && imgType.Length > 0 && imgLocation.Length > 0)
            {
                var result = saveServiceImage();
                if (result > 0)
                {
                    if (imgServiceImages.Image != null)
                    {
                        imgServiceImages.Image.Dispose();
                        imgServiceImages.Image = null;
                    }

                    bntSaveImages.Enabled = false;
                    bntBrowseImage.Enabled = true;

                    txtServiceImgFileName.Text = "";
                    txtServiceImgTitle.Text = "";
                    cmbServiceImgType.SelectedIndex = -1;

                    _service_image_list = EnumerableUtils.getServiceImgList();
                }
            }
            else
            {
                PopupNotification.PopUpMessages(0, "Please fill all the entries!", Messages.TitleFailedInsert);
            }
        }


        private string ExtractFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }
        
        private int saveServiceImage()
        {
            var returnValue = 0;

            using (var session = new DalSession())
            {
                var unitWorks = session.UnitofWrk;
                unitWorks.Begin();

                try
                {
                    var filePathLocation = txtServiceImgFileName.Text.Trim();
                    var filePath = ExtractFileName(filePathLocation);
                    var imageCode = txtServiceImgBarcode.Text.Trim();

                    var repository = new Repository<ServiceImages>(unitWorks);
                    var existingImg = repository.FindBy(x => x.image_code == imageCode);

                    if (existingImg != null)
                    {
                        // Update existing
                        existingImg.title = txtServiceImgTitle.Text.Trim();
                        existingImg.img_type = cmbServiceImgType.Text.Trim();
                        existingImg.img_location = filePath;
                        existingImg.updated_on = DateTime.Now;

                        var updated = repository.Update(existingImg);
                        if (updated)
                        {
                            unitWorks.Commit();
                            PopupNotification.PopUpMessages(1, "Service image updated: " + existingImg.title + " " + Messages.SuccessUpdate,
                                Messages.TitleSuccessUpdate);
                            returnValue = 1;
                        }
                    }
                    else
                    {
                        // Add new
                        var img = new ServiceImages()
                        {
                            image_code = imageCode,
                            title = txtServiceImgTitle.Text.Trim(),
                            img_type = cmbServiceImgType.Text.Trim(),
                            img_location = filePath,
                            created_on = DateTime.Now,
                            updated_on = DateTime.Now
                        };

                        var result = repository.Add(img);
                        if (result > 0)
                        {
                            unitWorks.Commit();
                            PopupNotification.PopUpMessages(1, "Service image added: " + img.title + " " + Messages.SuccessInsert,
                                Messages.TitleSuccessInsert);
                            returnValue = 1;
                        }
                    }
                }
                catch (Exception ex)
                {
                    unitWorks.Rollback();
                    PopupNotification.PopUpMessages(0, ex.Message, Messages.TitleFailedInsert);
                }
            }

            return returnValue;
        }


        private void GridServices_RowClick(object sender, RowClickEventArgs e)
        {
            InputWhit();
            bntCancel.Enabled = true;
        }

        private void GridServices_LostFocus(object sender, EventArgs e)
        {
            InputDimG();
        }

        private void generateLastServiceCode()
        {
            var lastProductId = FetchUtils.getLastServiceId();
            var alphaNumeric = new GenerateAlpaNum("S", 3, lastProductId);
            alphaNumeric.Increment();
            txtBarcode.Text = alphaNumeric.ToString();
        }

        private void GenerateNewServiceId()
        {
            int lastId = FetchUtils.getLastServiceId();
            int newId = lastId + 1;

            txtServiceId.Text = newId.ToString();
        }

        private void xInventory_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == tabServices)
            {
                _serv = true;
                cash = false;
                lblMainTitle.Text = "Services";
                _services_list = EnumerableUtils.getServicesList();
                bindServices();
            }
            if (e.Page == tabImage && e.PrevPage == tabServices)
            {
                _add = false;
                _edt = false;
                _del = false;

                bntAdd.Enabled = false;
                bntUpdate.Enabled = false;
                bntDelete.Enabled = false;
                bntSave.Enabled = false;
                bntClear.Enabled = false;
                bntCancel.Enabled = false;
            }
            if (e.Page == tabImage && e.PrevPage == tabBreakdown)
            {
                _add = false;
                _edt = false;
                _del = false;
                txtServiceImgFileName.Text = string.Empty;
                imgServiceImages.Image = null;
                bntAdd.Enabled = false;
                bntUpdate.Enabled = false;
                bntDelete.Enabled = false;
                bntSave.Enabled = false;
                bntClear.Enabled = false;
                bntCancel.Enabled = false;
            }
            if (e.Page == tabServices && e.PrevPage == tabImage)
            {
                txtServiceImgFileName.Text = string.Empty;
                imgServiceImages.Image = null;
                bntAdd.Enabled = true;
                bntUpdate.Enabled = true;
                bntDelete.Enabled = true;
                bntSave.Enabled = false;
                bntClear.Enabled = false;
                bntCancel.Enabled = true;
            }
            if (e.Page == tabBreakdown && e.PrevPage == tabImage)
            {
                lblMainTitle.Text = "Breakdown";
                txtServiceImgFileName.Text = string.Empty;
                imgServiceImages.Image = null;
                bntAdd.Enabled = true;
                bntUpdate.Enabled = true;
                bntDelete.Enabled = true;
                bntSave.Enabled = false;
                bntClear.Enabled = false;
                bntCancel.Enabled = true;
            }
            else if (e.Page == tabBreakdown)
            {
                _serv = false;
                cash = true;
                lblMainTitle.Text = "Breakdown";
            }
        }

        private void bindServices()
        {
            clearGrid();
            var list = _services_list.Select(p => new {
                ID = p.service_id,
                BARCODE = p.service_code,
                SERVICE = p.service_name,
                DETAILS = p.service_details,
                CATEGORY = p.category,
                CHARGES = p.service_charges,
                COMMISSION = p.service_commission,
                USER = p.username,
                STAFF = p.staff,
                STATUS = p.status,
                DATE = p.service_date,
                CREATED = p.created_date,
                UPDATED = p.updated_date
            }).ToList();
            gridController.DataSource = list;
            gridController.Update();
            if (gridServices.RowCount > 0)
            gridServices.Columns[0].Width = 40;
            gridServices.Columns[1].Width = 90;
            gridServices.Columns[2].Width = 200;
            gridServices.Columns[3].Width = 140;
            gridServices.Columns[4].Width = 90;
            gridServices.Columns[5].Width = 100;
            gridServices.Columns[6].Width = 100;
            gridServices.Columns[7].Width = 90;
            gridServices.Columns[8].Width = 90;
            gridServices.Columns[9].Width = 100;
            gridServices.Columns[10].Width = 100;
            gridServices.Columns[11].Width = 100;
            gridServices.Columns[12].Width = 100;
        }

        private void CalculateTotal()
        {
            int thousand = int.TryParse(txtThousand.Text, out int t) ? t : 0;
            int five = int.TryParse(txtFive.Text, out int f) ? f : 0;
            int two = int.TryParse(txtTwo.Text, out int tw) ? tw : 0;
            int hundred = int.TryParse(txtHundred.Text, out int h) ? h : 0;
            int fifty = int.TryParse(txtFifty.Text, out int fi) ? fi : 0;
            int twenty = int.TryParse(txtTwenty.Text, out int twt) ? twt : 0;
            decimal coins = decimal.TryParse(txtCoins.Text, out decimal c) ? c : 0;

            decimal totalValue =
                (1000 * thousand) +
                (500 * five) +
                (200 * two) +
                (100 * hundred) +
                (50 * fifty) +
                (20 * twenty) +
                coins;

            txtTotal.Text = totalValue.ToString("N2");
        }

        private void txtCoins_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtCoins.Text.Length;
                if (len > 0)
                {
                    InputManipulation.InputBoxLeave(txtCoins, bntSave, "Cash Breakdown Coins",
                    Messages.TitleBreakdown);
                    CalculateTotal();
                }
                else
                {
                    txtCoins.Text = @"0";
                    txtCoins.BackColor = Color.Yellow;
                    txtCoins.Focus();
                }
                if (txtCoins.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtCoins, bntSave, "Cash Breakdown Coins",
                        Messages.TitleBreakdown);
                }
            }
        }

        private void txtThousand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtThousand.Text.Length;
                if (len > 0)
                {
                    InputManipulation.InputBoxLeave(txtThousand, txtFive, "Cash Breakdown Thousand",
                    Messages.TitleBreakdown);
                    CalculateTotal();
                }
                else
                {
                    txtThousand.Text = @"0";
                    txtThousand.BackColor = Color.Yellow;
                    txtThousand.Focus();
                }
                if (txtThousand.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtThousand, txtFive, "Cash Breakdown Thousand",
                        Messages.TitleBreakdown);
                }
            }
        }

        private void txtFive_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtFive.Text.Length;
                if (len > 0)
                {
                    InputManipulation.InputBoxLeave(txtFive, txtTwo, "Cash Breakdown Five Hundred",
                    Messages.TitleBreakdown);
                    CalculateTotal();
                }
                else
                {
                    txtFive.Text = @"0";
                    txtFive.BackColor = Color.Yellow;
                    txtFive.Focus();
                }
                if (txtFive.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtFive, txtTwo, "Cash Breakdown Five Hundred",
                        Messages.TitleBreakdown);
                }
            }
        }

        private void txtTwo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtTwo.Text.Length;
                if (len > 0)
                {
                    InputManipulation.InputBoxLeave(txtTwo, txtHundred, "Cash Breakdown Two Hundred",
                    Messages.TitleBreakdown);
                    CalculateTotal();
                }
                else
                {
                    txtTwo.Text = @"0";
                    txtTwo.BackColor = Color.Yellow;
                    txtTwo.Focus();
                }
                if (txtTwo.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtTwo, txtHundred, "Cash Breakdown Two Hundred",
                        Messages.TitleBreakdown);
                }
            }
        }

        private void txtHundred_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtHundred.Text.Length;
                if (len > 0)
                {
                    InputManipulation.InputBoxLeave(txtHundred, txtFifty, "Cash Breakdown Hundred",
                    Messages.TitleBreakdown);
                    CalculateTotal();
                }
                else
                {
                    txtHundred.Text = @"0";
                    txtHundred.BackColor = Color.Yellow;
                    txtHundred.Focus();
                }
                if (txtHundred.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtHundred, txtFifty, "Cash Breakdown Hundred",
                        Messages.TitleBreakdown);
                }
            }
        }

        private void txtFifty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtFifty.Text.Length;
                if (len > 0)
                {
                    InputManipulation.InputBoxLeave(txtFifty, txtTwenty, "Cash Breakdown Fifty",
                    Messages.TitleBreakdown);
                    CalculateTotal();
                }
                else
                {
                    txtFifty.Text = @"0";
                    txtFifty.BackColor = Color.Yellow;
                    txtFifty.Focus();
                }
                if (txtCoins.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtFifty, txtTwenty, "Cash Breakdown Fifty",
                        Messages.TitleBreakdown);
                }
            }
        }

        private void txtTwenty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtTwenty.Text.Length;
                if (len > 0)
                {
                    InputManipulation.InputBoxLeave(txtTwenty, txtCoins, "Cash Breakdown Twenty",
                    Messages.TitleBreakdown);
                    CalculateTotal();
                }
                else
                {
                    txtTwenty.Text = @"0";
                    txtTwenty.BackColor = Color.Yellow;
                    txtTwenty.Focus();
                }
                if (txtTwenty.Text == "0" && e.KeyCode == Keys.Enter)
                {
                    InputManipulation.InputBoxLeave(txtTwenty, txtCoins, "Cash Breakdown Twenty",
                        Messages.TitleBreakdown);
                }
            }
        }

        private void gridBreakdown_RowClick(object sender, RowClickEventArgs e)
        {
            if (gridBreakdown.RowCount > 0)
                InputWhitBreak();
            bntCancel.Enabled = true;
        }

        private ViewCashBreakdown searchBreakdownId(int id)
        {
            return _breakdown_list.FirstOrDefault(breakdown => breakdown.breakdown_id == id);
        }

        private void gridBreakdown_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridBreakdown.RowCount <= 0) return;

            try
            {
                var view = sender as GridView;
                if (view == null) return;

                var idObj = view.GetFocusedRowCellValue("ID");
                if (idObj == null) return;

                var id = idObj.ToString();
                if (string.IsNullOrEmpty(id)) return;

                breakdownId = int.Parse(id);

                var breakdown = searchBreakdownId(breakdownId);
                if (breakdown == null)
                {
                    PopupNotification.PopUpMessages(0, "Cash Breakdown", "No breakdown found for this ID.");
                    return;
                }

                txtThousand.Text = breakdown.b1000.ToString();
                txtFive.Text = breakdown.b500.ToString();
                txtTwo.Text = breakdown.b200.ToString();
                txtHundred.Text = breakdown.b100.ToString();
                txtFifty.Text = breakdown.b50.ToString();
                txtTwenty.Text = breakdown.b20.ToString();
                txtCoins.Text = breakdown.coins.ToString("F2");
                txtTotal.Text = breakdown.total.ToString("F2");
                dpkCreatedDate.Value = breakdown.date_register;
                dpkUpdated.Value = breakdown.date_update;
            }
            catch (Exception ex)
            {
                PopupNotification.PopUpMessages(0, ex.Message, "Cash Breakdown Table");
            }
        }

        private void bindBreakdown()
        {
            clearGridBreak();
            var list = _breakdown_list.Select(p => new {
                ID = p.breakdown_id,
                THOUSAND = p.b1000,
                FIVE_HUNDRED = p.b500,
                TWO_HUNDRED = p.b200,
                HUNDRED = p.b100,
                FIFTY = p.b50,
                TWENTY = p.b20,
                COINS = p.coins,
                TOTAL = p.total,
                STAFF = p.User,
                CREATED = p.date_register,
                UPDATED = p.date_update
            }).ToList();
            gridCtrlBreakdown.DataSource = list;
            gridCtrlBreakdown.Update();
            if (gridBreakdown.RowCount > 0)
                gridBreakdown.Columns[0].Width = 40;
            gridBreakdown.Columns[1].Width = 100;
            gridBreakdown.Columns[2].Width = 100;
            gridBreakdown.Columns[3].Width = 100;
            gridBreakdown.Columns[4].Width = 100;
            gridBreakdown.Columns[5].Width = 100;
            gridBreakdown.Columns[6].Width = 100;
            gridBreakdown.Columns[7].Width = 100;
            gridBreakdown.Columns[8].Width = 100;
            gridBreakdown.Columns[9].Width = 210;
            gridBreakdown.Columns[10].Width = 100;
            gridBreakdown.Columns[11].Width = 100;
        }
        private void RefreshBreakdown()
        {
            _breakdown_list = EnumerableUtils.getBreakdownList();
            bindBreakdown();
        }
    }
}