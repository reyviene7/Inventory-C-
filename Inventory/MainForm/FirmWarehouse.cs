using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using Inventory.Config;
using Inventory.Entities;
using Inventory.PopupForm;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using Query = ServeAll.Core.Queries.Query;

namespace Inventory.MainForm
{
    public partial class FirmWarehouse : Form
    {
        private int _branchId;
        private int _warehouseId;
        private int _deliver;
        private string _deliveryBranches;
        private string _branch;
        private int _close;
        private readonly int _userId;
        private readonly int _userTyp;
        private readonly string _userName;
        private IEnumerable<ViewWarehouse> _warehousel_list;
        private bool _add, _edt, _del;
        public string DeliveryBranches
        {
            get { return _deliveryBranches; }
            set
            {
                _deliveryBranches = value;
                if (_deliveryBranches.Length > 0)
                {
                    BindBranchDeliverList(_deliveryBranches);
                }
            }
        }
        public new int Close
        {
            get { return _close; }
            set
            {
                _close = value;
                if (_close > 0)
                    XtraWarehouse.SelectedTabPage = XtabWHdetails;
            }
        }
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
                var main = new FirmMain(_userId, _userTyp, _userName);
                main.Show();
            }
        } 
      
        public FirmMain Main { get; set; }
        public FirmWarehouse(int userId, int userTy, string userName)
        {
            _userName = userName;
            _userId = userId;
            _userTyp = userTy;
            InitializeComponent();
            _warehousel_list = EnumerableUtils.getWarehouseList();   
        }
        private void FirmWarehouseInvetory_Load(object sender, EventArgs e)
        {
            wareWet.ShowWaitForm();
            PanelInterface.SetFullScreen(this); 
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            _warehousel_list = EnumerableUtils.getWarehouseList();
            BindWarehouse();
            wareWet.CloseWaitForm();
        } 
        private void BindWarehouseClear()
        {
            gridControl.DataBindings.Clear();
            gridControl.DataSource = null;
            gridControl.DataSource = "";
            gridWarehouse.Columns.Clear();
        }
        private void BindWarehouse()
        { 
            gridControl.Update();
            try
            { 
                var list = _warehousel_list.Select(x => new
                {
                    Id = x.warehouse_id,
                    Code = x.warehouse_code,
                    Warehouse = x.warehouse_name,
                    Address = x.street + ", " + x.barangay + ", " + x.city + ", " + x.zip_code + ", " + x.country,
                    Telephone = x.telephone_number,
                    Mobile = x.mobile_number,
                    Email = x.email_address,
                    Fax = x.fax_number,
                    Date = x.date_added
                });

                gridControl.DataSource = list; 

                gridWarehouse.Columns[0].Width = 30;
                gridWarehouse.Columns[1].Width = 50;
                gridWarehouse.Columns[2].Width = 100;
                gridWarehouse.Columns[3].Width = 200;
                gridWarehouse.Columns[4].Width = 100;
                gridWarehouse.Columns[5].Width = 100;
                gridWarehouse.Columns[6].Width = 90;
                gridWarehouse.Columns[8].Width = 80;  
            }
            catch (Exception ex)
            {
                gridControl.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableSupplier);
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
            BindWarehouseClear();
            ButSav();
        }

        private void bntClear_Click(object sender, EventArgs e)
        {
            ButClr();
        }

        private void bntCancel_Click(object sender, EventArgs e)
        {
            ButCan();
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            InputWhite();
            var que =
                PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Inventory: " + txtWarehouseCode.Text.Trim(' ') + " " + "?", "Inventory Details");
            if (que)
            {
                ButDel();
            }
            else { ButCan(); }
        }
        private void bntHome_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
        }

        private void gridInventory_Click(object sender, EventArgs e)
        {
            if (gridWarehouse.RowCount > 0)
                InputWhite();
                bntClear.Enabled = true;
        }
        private void InputWhite()
        {
            txtWarehouseId.BackColor = Color.White;
            txtWarehouseCode.BackColor = Color.White;
            txtWarehouseName.BackColor = Color.White;
            txtStreet.BackColor = Color.White;
            txtBarangay.BackColor = Color.White;
            txtCity.BackColor = Color.White;
            cmbProvincialAddress.BackColor = Color.White;
            txtZipCode.BackColor = Color.White;
            txtCountry.BackColor = Color.White;
            dkpDateRegister.BackColor = Color.White;
            txtTelephone.BackColor = Color.White;
            txtMobile.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtFax.BackColor = Color.White;
        }
        private void InputEnable()
        {
            txtWarehouseId.Enabled = true;
            txtWarehouseCode.Enabled = true;
            txtWarehouseName.Enabled = true;
            txtStreet.Enabled = true;
            txtBarangay.Enabled = true;
            txtCity.Enabled = true;
            cmbProvincialAddress.Enabled = true;
            txtZipCode.Enabled = true;
            txtCountry.Enabled = true;
            dkpDateRegister.Enabled = true;
            txtTelephone.Enabled = true;
            txtMobile.Enabled = true;
            txtEmail.Enabled = true;
            txtFax.Enabled = true;
        }
        private void InputDisable()
        {
            txtWarehouseId.Enabled = false;
            txtWarehouseCode.Enabled = false;
            txtWarehouseName.Enabled = false;
            txtStreet.Enabled = false;
            txtBarangay.Enabled = false;
            txtCity.Enabled = false;
            cmbProvincialAddress.Enabled = false;
            txtZipCode.Enabled = false;
            txtCountry.Enabled = false;
            dkpDateRegister.Enabled = false;
            txtTelephone.Enabled = false;
            txtMobile.Enabled = false;
            txtEmail.Enabled = false;
            txtFax.Enabled = false;
        }
        private void InputClear()
        {
            txtWarehouseId.Clear();
            txtWarehouseCode.Clear();
            txtWarehouseName.Clear();
            txtStreet.Clear();
            txtBarangay.Clear();
            txtCity.Clear();
            cmbProvincialAddress.Text = "";
            txtZipCode.Clear();
            txtCountry.Clear();  
            dkpDateRegister.Value = DateTime.Now.Date;
            txtTelephone.Clear();
            txtMobile.Clear();
            txtEmail.Clear();
            txtFax.Clear();
        }
        private void InputDimGray()
        {
            txtWarehouseId.BackColor = Color.DimGray;
            txtWarehouseCode.BackColor = Color.DimGray;
            txtWarehouseName.BackColor = Color.DimGray;
            txtStreet.BackColor = Color.DimGray;
            txtBarangay.BackColor = Color.DimGray;
            txtCity.BackColor = Color.DimGray;
            cmbProvincialAddress.BackColor = Color.DimGray;
            txtZipCode.BackColor = Color.DimGray;
            txtCountry.BackColor = Color.DimGray;
            dkpDateRegister.BackColor = Color.DimGray;
            txtTelephone.BackColor = Color.DimGray;
            txtMobile.BackColor = Color.DimGray;
            txtEmail.BackColor = Color.DimGray;
            txtFax.BackColor = Color.DimGray;
        } 
        private void ButAdd()
        {
            gridControl.Enabled = false;
            ButtonAdd();
            InputWhite();
            InputEnable();
            InputClear();
            BindWarehouse();
            GenerateWarehouseCode();
            GenerateNewWarehouseId();
            txtWarehouseName.Focus();
            _add = true;
            _edt = false;
            _del = false;
        }

        private void ButUpd()
        {
            ButtonUpd();
            InputEnable();
            InputWhite();
            _add = false;
            _edt = true;
            _del = false;
            gridControl.Enabled = false;

        }
        private void ButDel()
        {
            ButtonDel();
            InputEnable();
            InputWhite();
            _add = false;
            _edt = false;
            _del = true;
            gridControl.Enabled = false;

        }
        private void ButClr()
        {
            ButtonClr();
            InputEnable();
            InputDimGray();
            InputClear();
            gridControl.Enabled = true;
        }
        private void ButSav()
        {

            if (_add && _edt == false && _del == false)
            {
                addWarehouse();
                ButtonSav();
                InputDisable();
                InputDimGray();
                InputClear();
                BindWarehouse();
            }
            if (_add == false && _edt && _del == false)
            {

                DataUpdate();
                ButtonSav();
                InputDisable();
                InputDimGray();
                InputClear();

            }
            if (_add == false && _edt == false && _del)
            {

                DataDelete();
                ButtonSav();
                InputDisable();
                InputDimGray();
                InputClear();

            }
            _add = false;
            _edt = false;
            _del = false;
            gridControl.Enabled = true;
            //cmbProductName.DataBindings.Clear();
            //imgPreview.DataBindings.Clear();
            //imgPreview.Image = null;
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisable();
            InputDimGray();
            InputClear();
            gridControl.Enabled = true;
            //cmbProductName.DataBindings.Clear();
            //imgPreview.DataBindings.Clear();
            //imgPreview.Image = null;
        }
        private void ButtonAdd()
        {
            bntAdd.Enabled = false;
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
            bntClear.Enabled = true;
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

        private void GenerateNewWarehouseId()
        {
            int lastId = _warehousel_list.Any() ? _warehousel_list.Max(x => x.warehouse_id) : 0;
            int newId = lastId + 1;

            txtWarehouseId.Text = newId.ToString();
        }

        private void GenerateWarehouseCode()
        {
            var lastWarehouseId = FetchUtils.getLastWarehouseId();
            var alphaNumeric = new GenerateAlpaNum("WH", 3, lastWarehouseId);
            alphaNumeric.Increment();
            txtWarehouseCode.Text = alphaNumeric.ToString();
        }
        /*
        private static int addAddress(string street, string barangay, string city, string province, string zipcode, string country)
        {
            if (street.Length > 0)
            {
                Address address = new Address
                {
                    
                }
            }
        }*/

        private void addWarehouse()
        {
            var wh = new Warehouse()
            {
                warehouse_id = int.Parse(txtWarehouseId.Text.Trim(' ')),
                warehouse_code = txtWarehouseCode.Text.Trim(' '),
                warehouse_name = txtWarehouseName.Text.Trim(' '),
                date_added = dkpDateRegister.Value.Date
            };
            using (var session = new DalSession())
            {
                var unit = session.UnitofWrk;
                unit.Begin();
                try
                {
                    var addressRepository = new Repository<Address>(unit);
                    var address = new Address()
                    {
                        street = txtStreet.Text.Trim(' '),
                        barangay = txtBarangay.Text.Trim(' '),
                        city = txtCity.Text.Trim(' '),
                        province = cmbProvincialAddress.Text.Trim(' '),
                        zip_code = txtZipCode.Text.Trim(' '),
                        country = txtCountry.Text.Trim(' ')
                    };

                    addressRepository.Add(address);
                    wh.address_id = address.address_id;

                    var contactRepository = new Repository<Contact>(unit);
                    var contact = new Contact()
                    {
                        telephone_number = txtTelephone.Text.Trim(' '),
                        mobile_number = txtMobile.Text.Trim(' '),
                        email_address = txtEmail.Text.Trim(' '),
                        fax_number = txtFax.Text.Trim(' ')
                    };
                    contactRepository.Add(contact);
                    wh.contact_id = contact.contact_id;

                    var repository = new Repository<Warehouse>(unit);
                    var que = repository.Add(wh); 

                    if (que > 0)
                    {
                        wareWet.ShowWaitForm();
                        unit.Commit();
                        _warehousel_list = EnumerableUtils.getWarehouseList();
                        BindWarehouse();
                        wareWet.CloseWaitForm();
                        PopupNotification.PopUpMessages(1, "Warehouse Name: " + txtWarehouseName.Text.Trim() + " " + Messages.SuccessInsert, Messages.TitleSuccessInsert);
                        
                    }
                    else
                    {
                        wareWet.ShowWaitForm();
                        unit.Rollback();
                        PopupNotification.PopUpMessages(1, "Warehouse Name: " + txtWarehouseName.Text.Trim() + " " + Messages.ErrorInsert + " in the Database.", Messages.TitleFailedInsert);
                        wareWet.CloseWaitForm();
                    }
                }
                catch (Exception ex)
                {
                    wareWet.ShowWaitForm();
                    unit.Rollback();
                    PopupNotification.PopUpMessages(0, $"{Messages.ErrorInsert}{Messages.TableWarehouse}{Messages.ErrorOccurred}", Messages.TitleFailedInsert);
                    wareWet.CloseWaitForm();
                }
            }
        }
        private void DataUpdate()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {/*
                    var proId       = Convert.ToInt32(txtWarehouseId.Text);
                    var repository  = new Repository<WareHouse>(unWork);
                    var que         = repository.Id(proId);
                    que.Code        = txtWarehouseCode.Text;
                    que.ProductId   = GetProductId(cmbProductName.Text);
                    que.DeliveryNo  = txtDeliveryNo.Text;
                    que.ReceiptNo   = txtReceiptNo.Text;
                    que.QtyStock    = Convert.ToDecimal(txtWarehouseQty.Text);
                    que.BranchId    = GetBranchId(cmbWarehouseBranch.Text);
                    que.LastCost    = Convert.ToDecimal(txtLastCost.Text);
                    que.OnOrder     = Convert.ToInt32(txtOnOrder.Text);
                    que.PurDate     = dkpDepotDelivery.Value.Date;
                    que.InvDate     = dkpInputDate.Value.Date;
                    que.WarrantyId  = GetWarrantyId(cmbProductWarranty.Text);
                    que.StatusId    = GetProductStatus(cmbProductStatus.Text);
                    que.DepotId     = int.Parse(txtDepotControl.Text);
                    var result      = repository.Update(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessUpdate,
                         Messages.TitleSuccessUpdate);
                        unWork.Commit();
                    }
                    */
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedUpdate);

                }
            }
        }
        private void DataDelete()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    /*
                    var proId = Convert.ToInt32(txtWarehouseId.Text);
                    var repository = new Repository<WareHouse>(unWork);
                    var que = repository.Id(proId);
                    var result = repository.Delete(que);
                    if (result)
                    {
                        PopupNotification.PopUpMessages(1, "Product Name: " + cmbProductName.Text.Trim(' ') + " " + Messages.SuccessDelete,
                         Messages.TitleSuccessDelete);
                        unWork.Commit();
                    }
                    */
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TitleFialedDelete);

                }
            }
        }
        private void BindBranchDeliverList(string branch)
        {
            /*
            gDEL.Update();
            try
            {
                weWet.ShowWaitForm();
                gDEL.DataBindings.Clear();
                gDEL.DataSource = null;
                gDEL.DataSource = BindBranchDeliver(branch);
                if (gridDEL.RowCount > 0)
                {
                    gridDEL.Columns[0].Width = 40;
                }
                weWet.CloseWaitForm();
            }
            catch (Exception ex)
            {
                gDEL.EndUpdate();
                Console.Write(ex.ToString());
            }
            */
        } 
         
        private void gridWarehouse_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridWarehouse.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("Id").ToString();
                    if (id.Length > 0)
                    {
                        var ent = searchWarehouseId(int.Parse(id));
                        txtWarehouseId.Text = ent.warehouse_id.ToString();
                        txtWarehouseCode.Text = ent.warehouse_code;
                        txtWarehouseName.Text = ent.warehouse_name;
                        txtStreet.Text = ent.street;
                        txtBarangay.Text = ent.barangay;
                        txtCity.Text = ent.city;
                        cmbProvincialAddress.Text = ent.province;
                        txtZipCode.Text = ent.zip_code;
                        txtCountry.Text = ent.country;
                        txtTelephone.Text = ent.telephone_number;
                        txtMobile.Text = ent.mobile_number;
                        txtEmail.Text = ent.email_address;
                        txtFax.Text = ent.fax_number;
                        dkpDateRegister.Value = ent.date_added; 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }
        private void gridWarehouse_Click(object sender, EventArgs e)
        {
            if (gridWarehouse.RowCount > 0)
                InputWhite();
            bntClear.Enabled = true;
        }
        private ViewWarehouse searchWarehouseId(int id)
        {
            return _warehousel_list.FirstOrDefault(Branch => Branch.warehouse_id == id);
        } 
    }
}
