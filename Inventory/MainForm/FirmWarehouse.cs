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
        private int _deliver;
        private string _deliveryBranches;
        private int _close;
        private readonly int _userId;
        private readonly int _userTyp;
        private readonly string _userName;
        private IEnumerable<ViewWarehouse> _warehouse_list;
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
            if (_userTyp != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
            _warehouse_list = EnumerableUtils.getWarehouseList();
        }
        private void FirmWarehouse_Load(object sender, EventArgs e)
        {
            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            wareWet.ShowWaitForm();
            _warehouse_list = EnumerableUtils.getWarehouseList();
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
                var list = _warehouse_list.Select(x => new
                {
                    ID = x.warehouse_id,
                    CODE = x.warehouse_code,
                    WAREHOUSE = x.warehouse_name,
                    ADDRESS = x.street + ", " + x.barangay + ", " + x.city + ", " + x.zip_code + ", " + x.country,
                    TELEPHONE = x.telephone_number,
                    MOBILE = x.mobile_number,
                    EMAIL = x.email_address,
                    FAX = x.fax_number,
                    DATE = x.date_added
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
                    "Are you sure you want to Delete Warehouse: " + txtWarehouseCode.Text.Trim(' ') + " " + "?", "Warehouse Details");
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
        private void ButAdd()
        {
            ButtonAdd();
            InputClear();
            InputWhite();
            InputEnable();
            GenerateWarehouseCode();
            GenerateNewWarehouseId();
            _add = true;
            _edt = false;
            _del = false;
            gridControl.Enabled = false;
            txtWarehouseId.Enabled = false;
            txtWarehouseCode.Enabled = false;
            txtWarehouseName.Focus();
        }

        private void ButUpd()
        {
            ButtonUpd();
            InputEnable();
            InputWhite();

            txtWarehouseId.Enabled = false;
            txtWarehouseCode.Enabled = false;
            txtWarehouseName.Focus();
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
        }
        private void ButClr()
        {
            BindWarehouse();
            ButtonClr();
            InputDisable();
            InputWhite();
            InputClear();
            gridControl.Enabled = true;
            gridControl.Update();
            int focusedRowHandle = gridWarehouse.FocusedRowHandle;
            if (focusedRowHandle >= 0)
            {
                gridWarehouse_FocusedRowChanged(
                    gridWarehouse,
                    new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(
                        focusedRowHandle,
                        focusedRowHandle
                    )
                );
            }
        }
        private void ButCan()
        {
            ButtonCan();
            InputDisable();
            InputDimGray();
            InputClear();
        }
        private void ButSav()
        {

            if (_add && _edt == false && _del == false)
            {
                addWarehouse();
                ButtonSav();
                InputDimGray();
                InputDisable();
                InputClear();
                BindWarehouse();
            }
            if (_add == false && _edt && _del == false)
            {
                UpdateWarehouse();
                ButtonSav();
                InputDimGray();
                InputDisable();
                InputClear();
            }
            if (_add == false && _edt == false && _del)
            {
                DeleteWarehouse();
                ButtonSav();
                InputDisable();
                InputDimGray();
                InputClear();
            }
            _add = false;
            _edt = false;
            _del = false;
            gridControl.Enabled = true;
            BindWarehouse();
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
        private void GenerateNewWarehouseId()
        {
            int lastId = FetchUtils.getNumberOfWarehouses();
            int newId = lastId + 1;

            txtWarehouseId.Text = newId.ToString();
        }
        private void GenerateWarehouseCode()
        {
            var lastWarehouseId = FetchUtils.getNumberOfWarehouses();
            var alphaNumeric = new GenerateAlpaNum("WH", 3, lastWarehouseId);
            alphaNumeric.Increment();
            txtWarehouseCode.Text = alphaNumeric.ToString();
        }
        private void addWarehouse()
        {
            var warehouse = new Warehouse()
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
                    warehouse.address_id = address.address_id;

                    var contactRepository = new Repository<Contact>(unit);
                    var contact = new Contact()
                    {
                        telephone_number = txtTelephone.Text.Trim(' '),
                        mobile_number = txtMobile.Text.Trim(' '),
                        email_address = txtEmail.Text.Trim(' '),
                        fax_number = txtFax.Text.Trim(' ')
                    };
                    contactRepository.Add(contact);
                    warehouse.contact_id = contact.contact_id;

                    var repository = new Repository<Warehouse>(unit);
                    var que = repository.Add(warehouse);

                    if (que > 0)
                    {
                        wareWet.ShowWaitForm();
                        unit.Commit();
                        _warehouse_list = EnumerableUtils.getWarehouseList();
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
                catch
                {
                    wareWet.ShowWaitForm();
                    unit.Rollback();
                    PopupNotification.PopUpMessages(0, $"{Messages.ErrorInsert}{Messages.TableWarehouse}{Messages.ErrorOccurred}", Messages.TitleFailedInsert);
                    wareWet.CloseWaitForm();
                }
            }
        }
        private void UpdateWarehouse()
        {
            var warehouseId = Convert.ToInt32(txtWarehouseId.Text);
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var warehouseRepository = new Repository<Warehouse>(unWork);
                    var warehouse = warehouseRepository.Id(warehouseId);

                    if (warehouse != null)
                    {
                        bool isUpdated = false;

                        if (warehouse.warehouse_code != txtWarehouseCode.Text.Trim(' '))
                        {
                            warehouse.warehouse_code = txtWarehouseCode.Text.Trim(' ');
                            isUpdated = true;
                        }

                        if (warehouse.warehouse_name != txtWarehouseName.Text.Trim(' '))
                        {
                            warehouse.warehouse_name = txtWarehouseName.Text.Trim(' ');
                            isUpdated = true;
                        }

                        var addressRepository = new Repository<Address>(unWork);
                        var address = warehouse.address_id > 0 ? addressRepository.Id(warehouse.address_id) : new Address();

                        if (address.street != txtStreet.Text.Trim(' ') ||
                            address.barangay != txtBarangay.Text.Trim(' ') ||
                            address.city != txtCity.Text.Trim(' ') ||
                            address.province != cmbProvincialAddress.Text.Trim(' ') ||
                            address.zip_code != txtZipCode.Text.Trim(' ') ||
                            address.country != txtCountry.Text.Trim(' '))
                        {
                            address.street = txtStreet.Text.Trim(' ');
                            address.barangay = txtBarangay.Text.Trim(' ');
                            address.city = txtCity.Text.Trim(' ');
                            address.province = cmbProvincialAddress.Text.Trim(' ');
                            address.zip_code = txtZipCode.Text.Trim(' ');
                            address.country = txtCountry.Text.Trim(' ');
                            isUpdated = true;
                        }

                        var contactRepository = new Repository<Contact>(unWork);
                        var contact = warehouse.contact_id > 0 ? contactRepository.Id(warehouse.contact_id) : new Contact();

                        if (contact.telephone_number != txtTelephone.Text.Trim(' ') ||
                            contact.mobile_number != txtMobile.Text.Trim(' ') ||
                            contact.email_address != txtEmail.Text.Trim(' ') ||
                            contact.fax_number != txtFax.Text.Trim(' '))
                        {
                            contact.telephone_number = txtTelephone.Text.Trim(' ');
                            contact.mobile_number = txtMobile.Text.Trim(' ');
                            contact.email_address = txtEmail.Text.Trim(' ');
                            contact.fax_number = txtFax.Text.Trim(' ');
                            isUpdated = true;
                        }

                        if (warehouse.date_added != dkpDateRegister.Value.Date)
                        {
                            warehouse.date_added = dkpDateRegister.Value.Date;
                            isUpdated = true;
                        }

                        if (!isUpdated)
                        {
                            PopupNotification.PopUpMessages(1, "No Changes", "Fields Error");
                            return;
                        }

                        try
                        {
                            if (warehouse.address_id > 0)
                            {
                                addressRepository.Update(address);
                            }
                            else
                            {
                                addressRepository.Add(address);
                                warehouse.address_id = address.address_id;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error updating address: " + ex.Message);
                        }

                        try
                        {
                            if (warehouse.contact_id > 0)
                            {
                                contactRepository.Update(contact);
                            }
                            else
                            {
                                contactRepository.Add(contact);
                                warehouse.contact_id = contact.contact_id;
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Error updating contact: " + ex.Message);
                        }

                        var result = warehouseRepository.Update(warehouse);
                        if (result)
                        {
                            wareWet.ShowWaitForm();
                            unWork.Commit();
                            _warehouse_list = EnumerableUtils.getWarehouseList();
                            BindWarehouse();
                            wareWet.CloseWaitForm();
                            PopupNotification.PopUpMessages(1, $"{Messages.TableWarehouse} {Messages.CodeName} {txtWarehouseName.Text.Trim()} {Messages.SuccessUpdate}", Messages.TitleSuccessUpdate);
                        }
                    }
                    else
                    {
                        throw new Exception("Warehouse not found.");
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, $"{Messages.ErrorUpdate}Warehouse: " + txtWarehouseName.Text + $" {Messages.ErrorOccurred} : {ex.Message}", Messages.TitleFialedUpdate);
                }
            }
        }
        private void DeleteWarehouse()
        {
            var ctrlId = Convert.ToInt32(txtWarehouseId.Text);
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var warehouseRepository = new Repository<Warehouse>(unWork);
                    var warehouse = warehouseRepository.Id(ctrlId);
                    if (warehouse == null) return;

                    var contactId = warehouse.contact_id;
                    var addressId = warehouse.address_id;

                    var result = warehouseRepository.Delete(warehouse);
                    if (!result) return;

                    if (contactId > 0)
                    {
                        var contactRepository = new Repository<Contact>(unWork);
                        var contact = contactRepository.Id(contactId);
                        if (contact != null)
                        {
                            contactRepository.Delete(contact);
                        }
                    }

                    if (addressId > 0)
                    {
                        var addressRepository = new Repository<Address>(unWork);
                        var address = addressRepository.Id(addressId);
                        if (address != null)
                        {
                            addressRepository.Delete(address);
                        }
                    }
                    wareWet.ShowWaitForm();
                    unWork.Commit();
                    _warehouse_list = EnumerableUtils.getWarehouseList();
                    BindWarehouse();
                    wareWet.CloseWaitForm();
                    PopupNotification.PopUpMessages(1, Messages.TableBranch + Messages.CodeName + txtWarehouseName.Text.Trim(' ') + " " + Messages.SuccessDelete, Messages.TitleSuccessDelete);
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorDelete + Messages.TableBranch + Messages.ErrorOccurred, Messages.TitleFialedDelete);
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
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
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
            InputWhite();
            bntCancel.Enabled = true;
        }

        private void GridWarehouse_LostFocus(object sender, EventArgs e)
        {
            InputDimGray();
        }

        private ViewWarehouse searchWarehouseId(int id)
        {
            return _warehouse_list.FirstOrDefault(Branch => Branch.warehouse_id == id);
        }

        //KeyDown
        private void txtWarehouseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var len = txtWarehouseName.Text.Length;
                if (len > 0)
                {
                    txtWarehouseName.BackColor = Color.White;
                    txtStreet.Focus();
                    txtStreet.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Warehouse Name must not be empty!", Messages.TableWarehouse);
                    txtWarehouseName.BackColor = Color.Yellow;
                    txtWarehouseName.Focus();
                }
            }
        }
        private void txtStreet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtStreet.Text.Length;
                if (len > 0)
                {
                    txtStreet.BackColor = Color.White;
                    txtBarangay.Focus();
                    txtBarangay.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Street must not be empty!", Messages.TableWarehouse);
                    txtStreet.BackColor = Color.Yellow;
                    txtStreet.Focus();
                }
            }
        }
        private void txtBarangay_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtBarangay.Text.Length;
                if (len > 0)
                {
                    txtBarangay.BackColor = Color.White;
                    txtCity.Focus();
                    txtCity.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Barangay must not be empty!", Messages.TableWarehouse);
                    txtBarangay.BackColor = Color.Yellow;
                    txtBarangay.Focus();
                }
            }
        }
        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtCity.Text.Length;
                if (len > 0)
                {
                    txtCity.BackColor = Color.White;
                    cmbProvincialAddress.Focus();
                    cmbProvincialAddress.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "City to deliver must not be empty!", Messages.TableWarehouse);
                    txtCity.BackColor = Color.Yellow;
                    txtCity.Focus();
                }
            }
        }
        private void cmbProvincialAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = cmbProvincialAddress.Text.Length;
                if (len > 0)
                {
                    cmbProvincialAddress.BackColor = Color.White;
                    txtZipCode.Focus();
                    txtZipCode.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Provincial Address must not be empty!", Messages.TableWarehouse);
                    cmbProvincialAddress.BackColor = Color.Yellow;
                    cmbProvincialAddress.Focus();
                }
            }
        }
        private void txtZipCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtZipCode.Text.Length;
                if (len > 0)
                {
                    txtZipCode.BackColor = Color.White;
                    txtCountry.Focus();
                    txtCountry.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Zip Code must not be empty!", Messages.TableWarehouse);
                    txtZipCode.BackColor = Color.Yellow;
                    txtZipCode.Focus();
                }
            }
        }
        private void txtCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtCountry.Text.Length;
                if (len > 0)
                {
                    txtCountry.BackColor = Color.White;
                    dkpDateRegister.Focus();
                    dkpDateRegister.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Country must not be empty!", Messages.TableWarehouse);
                    txtCountry.BackColor = Color.Yellow;
                    txtCountry.Focus();
                }
            }
        }
        private void dkpDateRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = dkpDateRegister.Text.Length;
                if (len > 0)
                {
                    dkpDateRegister.BackColor = Color.White;
                    txtTelephone.Focus();
                    txtTelephone.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Date Register must not be empty!", Messages.TableWarehouse);
                    dkpDateRegister.BackColor = Color.Yellow;
                    dkpDateRegister.Focus();
                }
            }
        }
        private void txtTelephone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtTelephone.Text.Length;
                if (len > 0)
                {
                    txtTelephone.BackColor = Color.White;
                    txtMobile.Focus();
                    txtMobile.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Telephone must not be empty!", Messages.TableWarehouse);
                    txtTelephone.BackColor = Color.Yellow;
                    txtTelephone.Focus();
                }
            }
        }
        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtMobile.Text.Length;
                if (len > 0)
                {
                    txtMobile.BackColor = Color.White;
                    txtEmail.Focus();
                    txtEmail.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Mobile Number must not be empty!", Messages.TableWarehouse);
                    txtMobile.BackColor = Color.Yellow;
                    txtMobile.Focus();
                }
            }
        }

        private void FirmWarehouse_MouseMove(object sender, MouseEventArgs e)
        {
            PanelInterface.MouseMOve(this, pnlRightOptions, e);
        }

        private void Options_Tick(object sender, EventArgs e)
        {
            PanelInterface.OptionTick(this, pnlOptions);
        }

        private void RightOptions_Tick(object sender, EventArgs e)
        {
            PanelInterface.RightOptionTick(this, pnlRightOptions);
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtEmail.Text.Length;
                if (len > 0)
                {
                    txtEmail.BackColor = Color.White;
                    txtFax.Focus();
                    txtFax.BackColor = Color.Yellow;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Email must not be empty!", Messages.TableWarehouse);
                    txtEmail.BackColor = Color.Yellow;
                    txtEmail.Focus();
                }
            }
        }
        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                var len = txtFax.Text.Length;
                if (len > 0)
                {
                    txtFax.BackColor = Color.White;
                }
                else
                {
                    PopupNotification.PopUpMessages(0, "Fax must not be empty!", Messages.TableWarehouse);
                    txtFax.BackColor = Color.Yellow;
                    _ = txtFax.Focus();
                }
            }
        }
    }
}