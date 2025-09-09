using DevExpress.Printing.Utils.DocumentStoring;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using Inventory.Config;
using ServeAll.Core.Entities;
using ServeAll.Core.Repository;
using ServeAll.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;


namespace Inventory.MainForm
{
    public partial class FrmBranch : Form
    {
        private FirmMain _main;
        private bool _add, _edt, _del, _bra, _sto;
        private readonly int _userId;
        private readonly int _usrTyp;
        private IEnumerable<ViewBranch> listbranch;
        private IEnumerable<ViewStore> liststore;
        private int BranchId = 0;
        private int StoreId = 0;

        public FirmMain Main
        {
            get { return _main; }
            set { _main = value; }
        }

        public FrmBranch(int userId, int usrTyp)
        {
            _userId = userId;
            _usrTyp = usrTyp;
            if (_usrTyp != 1)
            {
                PopupNotification.PopUpMessages(0, Messages.AdminPrivilege, Messages.InventorySystem);

                this.DialogResult = DialogResult.Cancel;
                return;
            }
            InitializeComponent();
            this.DialogResult = DialogResult.OK;
        }

        private void FrmBranch_Load(object sender, EventArgs e)
        {

            PanelInterface.SetFullScreen(this);
            PanelInterface.SetMainPanelPosition(this, pnlMain);
            PanelInterface.SetOptionsPanelPosition(this, pnlOptions, pbHide);
            PanelInterface.SetRightOptionsPanelPosition(this, pnlRightOptions, pnlRightMain);
            Options.Start();
            RightOptions.Start();
            listbranch = EnumerableUtils.GetBranchList();
            liststore = EnumerableUtils.GetStoreList();
            _bra = true;
            _sto = false;
            BindBranch();
            BindStore();
            xtraBranch.SelectedTabPage = xtraDetails;
        }

        private void BindBranchClear()
        {
            gCON.DataBindings.Clear();
            gCON.DataSource = null;
            gCON.DataSource = "";
            gridBranch.Columns.Clear();
        }
        private void BindBranch()
        {

            gCON.Update();
            try
            {

                var list = listbranch.Select(x => new
                {
                    ID = x.branch_id,
                    CODE = x.branch_code,
                    BRANCH = x.branch_details,
                    BARANGAY = x.barangay,
                    STREET = x.street,
                    CITY = x.city,
                    PROVINCE = x.province,
                    ZIPCODE = x.zip_code,
                    TELEPHONE = x.telephone_number,
                    MOBILE = x.mobile_number,
                    EMAIL = x.email_address,
                    FAX = x.fax_number,
                    DATE = x.date_register.ToString("MM/dd/yyyy")
                });

                gCON.DataSource = list;


                gridBranch.Columns[0].Width = 30;
                gridBranch.Columns[1].Width = 50;
                gridBranch.Columns[2].Width = 100;
                gridBranch.Columns[3].Width = 120;
                gridBranch.Columns[4].Width = 100;
                gridBranch.Columns[5].Width = 100;
                gridBranch.Columns[6].Width = 120;
                gridBranch.Columns[7].Width = 60;
                gridBranch.Columns[8].Width = 100;
                gridBranch.Columns[9].Width = 100;
                gridBranch.Columns[10].Width = 100;
                gridBranch.Columns[11].Width = 100;
                gridBranch.Columns[12].Width = 100;

            }
            catch (Exception ex)
            {
                gCON.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableBranch);
            }
        }
        private void BindStore()
        {

            gridCtrlStore.Update();
            try
            {

                var list = liststore.Select(x => new
                {
                    ID = x.store_id,
                    NAME = x.store_name,
                    TIN = x.store_tin,
                    BARANGAY = x.barangay,
                    STREET = x.street,
                    CITY = x.city,
                    PROVINCE = x.province,
                    ZIPCODE = x.zip_code,
                    TELEPHONE = x.telephone_number,
                    MOBILE = x.mobile_number,
                    EMAIL = x.email_address,
                    WEB = x.web_url
                });

                gridCtrlStore.DataSource = list;


                gridStore.Columns[0].Width = 30;
                gridStore.Columns[1].Width = 100;
                gridStore.Columns[2].Width = 100;
                gridStore.Columns[3].Width = 120;
                gridStore.Columns[4].Width = 100;
                gridStore.Columns[5].Width = 100;
                gridStore.Columns[6].Width = 120;
                gridStore.Columns[8].Width = 100;
                gridStore.Columns[9].Width = 100;
                gridStore.Columns[10].Width = 100;
                gridStore.Columns[11].Width = 100;
            }
            catch (Exception ex)
            {
                gridCtrlStore.EndUpdate();
                PopupNotification.PopUpMessages(0, ex.ToString(), Messages.TableBranch);
            }
        }
        private void FrmBranch_MouseMove(object sender, MouseEventArgs e)
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

        private void bntADD_Click(object sender, EventArgs e)
        {
            ButAdd();

        }

        private void bntUPD_Click(object sender, EventArgs e)
        {
            ButUpd();
        }

        private void bntSAV_Click(object sender, EventArgs e)
        {
            BindBranchClear();
            ButSav();

        }

        private void bntCLR_Click(object sender, EventArgs e)
        {
            ButClr();
        }

        private void bntCAN_Click(object sender, EventArgs e)
        {
            ButCan();
            if (_bra && _sto == false)
            {
                gridBranch.FocusedRowHandle = gridBranch.FocusedRowHandle;
            }
            if (_bra == false && _sto)
            {
                gridStore.FocusedRowHandle = gridStore.FocusedRowHandle;
            }
        }

        private void bntDEL_Click(object sender, EventArgs e)
        {
            WhtInput();
            var que =
                PopupNotification.PopUpMessageQuestion(
                    "Are you sure you want to Delete Branch Name: " + txtBranchName.Text.Trim(' ') + "?", "Branch Details");
            if (que)
            {
                ButDel();
            }
            else { ButCan(); }
        }

        private void bntHOM_Click(object sender, EventArgs e)
        {
            Main.Show();
            Close();
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

        private void ButtonAdd()
        {
            bntADD.Enabled = false;
            bntUPD.Enabled = false;
            bntDEL.Enabled = false;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
            gCON.Enabled = false;
        }

        private void ButtonUpd()
        {
            bntADD.Enabled = false;
            bntUPD.Enabled = true;
            bntDEL.Enabled = false;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
            gCON.Enabled = false;
        }

        private void ButtonDel()
        {
            bntADD.Enabled = false;
            bntUPD.Enabled = false;
            bntDEL.Enabled = true;
            bntSAV.Enabled = true;
            bntCLR.Enabled = false;
            bntCAN.Enabled = true;
            bntHOM.Enabled = false;
            pbHome.Enabled = false;
            pbLogout.Enabled = false;
            pbExit.Enabled = false;
            gCON.Enabled = false;
        }

        private void ButtonSav()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = true;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
            gCON.Enabled = true;
        }

        private void ButtonClr()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = false;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
            gCON.Enabled = false;
        }

        private void ButtonCan()
        {
            bntADD.Enabled = true;
            bntUPD.Enabled = true;
            bntDEL.Enabled = true;
            bntSAV.Enabled = false;
            bntCLR.Enabled = true;
            bntCAN.Enabled = false;
            bntHOM.Enabled = true;
            pbHome.Enabled = true;
            pbLogout.Enabled = true;
            pbExit.Enabled = true;
            gCON.Enabled = true;
        }

        private void CleInput()
        {
            txtBranchId.Clear();
            txtBranchCode.Clear();
            txtBranchName.Clear();
            txtBranchBarangay.Clear();
            txtBranchStreet.Clear();
            txtBranchCity.Clear();
            cmbProvincialAddress.Text = "";
            txtBranchZip.Clear();
            txtBranchCountry.Clear();
            txtBranchTel.Clear();
            txtBranchMobile.Clear();
            txtBranchEmail.Clear();
            txtBranchFax.Clear();
        }
        private void CleInputStor()
        {
            txtStoreId.Clear();
            txtStoreName.Clear();
            txtStoreTIN.Clear();
            txtStoreBRGY.Clear();
            txtStoreCity.Clear();
            cmbStoreProv.Text = "";
            txtStoreZIP.Clear();
            txtStoreTel.Clear();
            txtStoreMob.Clear();
            txtStoreEmail.Clear();
            txtStoreWeb.Clear();
        }
        private void DimInputStor()
        {
            txtStoreId.BackColor = Color.DimGray;
            txtStoreName.BackColor = Color.DimGray;
            txtStoreTIN.BackColor = Color.DimGray;
            txtStoreBRGY.BackColor = Color.DimGray;
            txtStoreCity.BackColor = Color.DimGray;
            cmbStoreProv.BackColor = Color.DimGray;
            txtStoreZIP.BackColor = Color.DimGray;
            txtStoreTel.BackColor = Color.DimGray;
            txtStoreMob.BackColor = Color.DimGray;
            txtStoreEmail.BackColor = Color.DimGray;
            txtStoreWeb.BackColor = Color.DimGray;
            dkpStoreReg.BackColor = Color.DimGray;
        }
        private void DimInput()
        {
            txtBranchId.BackColor = Color.DimGray;
            txtBranchCode.BackColor = Color.DimGray;
            txtBranchName.BackColor = Color.DimGray;
            txtBranchBarangay.BackColor = Color.DimGray;
            txtBranchStreet.BackColor = Color.DimGray;
            txtBranchCity.BackColor = Color.DimGray;
            cmbProvincialAddress.BackColor = Color.DimGray;
            txtBranchZip.BackColor = Color.DimGray;
            txtBranchTel.BackColor = Color.DimGray;
            txtBranchMobile.BackColor = Color.DimGray;
            txtBranchEmail.BackColor = Color.DimGray;
            txtBranchFax.BackColor = Color.DimGray;
            dkpDateRegister.BackColor = Color.DimGray;
        }
        private void WhtInputStor()
        {
            txtStoreId.BackColor = Color.White;
            txtStoreName.BackColor = Color.White;
            txtStoreTIN.BackColor = Color.White;
            txtStoreBRGY.BackColor = Color.White;
            txtStoreCity.BackColor = Color.White;
            cmbStoreProv.BackColor = Color.White;
            txtStoreZIP.BackColor = Color.White;
            txtStoreTel.BackColor = Color.White;
            txtStoreMob.BackColor = Color.White;
            txtStoreEmail.BackColor = Color.White;
            txtStoreWeb.BackColor = Color.White;
            dkpStoreReg.BackColor = Color.White;
        }
        private void WhtInput()
        {
            txtBranchId.BackColor = Color.White;
            txtBranchCode.BackColor = Color.White;
            txtBranchName.BackColor = Color.White;
            txtBranchBarangay.BackColor = Color.White;
            txtBranchStreet.BackColor = Color.White;
            txtBranchCity.BackColor = Color.White;
            cmbProvincialAddress.BackColor = Color.White;
            txtBranchZip.BackColor = Color.White;
            txtBranchCountry.BackColor = Color.White;
            txtBranchTel.BackColor = Color.White;
            txtBranchMobile.BackColor = Color.White;
            txtBranchEmail.BackColor = Color.White;
            txtBranchFax.BackColor = Color.White;
        }
        private void EnbInputStor()
        {
            txtStoreId.Enabled = false;
            txtStoreName.Enabled = true;
            txtStoreTIN.Enabled = true;
            txtStoreBRGY.Enabled = true;
            txtStoreCity.Enabled = true;
            cmbStoreProv.Enabled = true;
            txtStoreZIP.Enabled = true;
            txtStoreTel.Enabled = true;
            txtStoreMob.Enabled = true;
            txtStoreEmail.Enabled = true;
            txtStoreWeb.Enabled = true;
            dkpStoreReg.Enabled = true;
        }
        private void EnbInput()
        {
            txtBranchId.Enabled = false;
            txtBranchCode.Enabled = true;
            txtBranchName.Enabled = true;
            txtBranchBarangay.Enabled = true;
            txtBranchStreet.Enabled = true;
            txtBranchCity.Enabled = true;
            cmbProvincialAddress.Enabled = true;
            txtBranchZip.Enabled = true;
            txtBranchCountry.Enabled = true;
            txtBranchTel.Enabled = true;
            txtBranchMobile.Enabled = true;
            txtBranchEmail.Enabled = true;
            txtBranchFax.Enabled = true;
            dkpDateRegister.Enabled = true;
        }
        private void DisInputStor()
        {
            txtStoreId.Enabled = false;
            txtStoreName.Enabled = false;
            txtStoreTIN.Enabled = false;
            txtStoreBRGY.Enabled = false;
            txtStoreCity.Enabled = false;
            cmbStoreProv.Enabled = false;
            txtStoreZIP.Enabled = false;
            txtStoreTel.Enabled = false;
            txtStoreMob.Enabled = false;
            txtStoreEmail.Enabled = false;
            txtStoreWeb.Enabled = false;
            dkpStoreReg.Enabled = false;
        }
        private void DisInput()
        {
            txtBranchId.Enabled = false;
            txtBranchCode.Enabled = false;
            txtBranchName.Enabled = false;
            txtBranchBarangay.Enabled = false;
            txtBranchStreet.Enabled = false;
            txtBranchCity.Enabled = false;
            cmbProvincialAddress.Enabled = false;
            txtBranchZip.Enabled = false;
            txtBranchCountry.Enabled = false;
            txtBranchTel.Enabled = false;
            txtBranchMobile.Enabled = false;
            txtBranchEmail.Enabled = false;
            txtBranchFax.Enabled = false;
            dkpDateRegister.Enabled = false;
        }

        private void ButAdd()
        {
            gCON.Enabled = false;
            gridCtrlStore.Enabled = false;
            _add = true;
            _edt = false;
            _del = false;
            ButtonAdd();
            txtBranchName.Focus();
            if (_bra && _sto == false)
            {
                WhtInput();
                EnbInput();
                CleInput();
                GenerateBranchCode();
                GenerateBranchId();
            }
            if (_bra == false && _sto)
            {
                WhtInputStor();
                EnbInputStor();
                CleInputStor();
                txtStoreName.Focus();
                GenerateStoreId();
            }
        }

        private void ButUpd()
        {
            ButtonUpd();
            _add = false;
            _edt = true;
            _del = false;
            if (_bra && _sto == false)
            {
                WhtInput();
                EnbInput();
                gCON.Enabled = false;
                txtBranchName.Focus();
            }
            else if (_bra == false && _sto)
            {
                WhtInputStor();
                EnbInputStor();
                gridCtrlStore.Enabled = false;
                txtStoreName.Focus();
            }
        }

        private void ButDel()
        {
            ButtonDel();
            WhtInput();
            DisInput();
            WhtInputStor();
            DisInputStor();
            _add = false;
            _edt = false;
            _del = true;
            gCON.Enabled = false;
            gridCtrlStore.Enabled = false;
        }

        private void ButSav()
        {
            if (_add && _edt == false && _del == false && _sto == false)
            {
                DataAdd();
                ButtonSav();
                DimInput();
                CleInput();
                DisInput();

            }
            if (_add == false && _edt && _del == false && _sto == false)
            {
                DataUpdate();
                ButtonSav();
                DimInput();
                CleInput();
                DisInput();

            }
            if (_add == false && _edt == false && _del && _sto == false)
            {
                DataDelete();
                ButtonSav();
                DimInput();
                CleInput();
                DisInput();

            }
            if (_add == false && _edt && _del == false && _bra == false)
            {
                DataUpdateStore();
                ButtonSav();
                DimInputStor();
                CleInputStor();
                DisInputStor();
            }
            _add = false;
            _edt = false;
            _del = false;
            listbranch = EnumerableUtils.GetBranchList();
            BindBranch();
            liststore = EnumerableUtils.GetStoreList();
            BindStore();
            gCON.Enabled = true;
            gridCtrlStore.Enabled = true;
        }

        private void ButClr()
        {
            BindBranch();
            BindStore();
            ButtonClr();
            WhtInput();
            CleInput();
            DisInput();
            WhtInputStor();
            CleInputStor();
            DisInputStor();
            gridCtrlStore.Enabled = true;
            gridCtrlStore.Update();
            gCON.Enabled = true;
            gCON.Update();
            if (_bra && _sto == false)
            {
                int focusedRowHandle = gridBranch.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    gridBranch_FocusedRowChanged(
                        gridBranch,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(
                            focusedRowHandle,
                            focusedRowHandle
                        )
                    );
                }
            }
            else if (_bra == false && _sto)
            {
                int focusedRowHandle = gridStore.FocusedRowHandle;
                if (focusedRowHandle >= 0)
                {
                    gridStore_FocusedRowChanged(
                        gridStore,
                        new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(
                            focusedRowHandle,
                            focusedRowHandle
                        )
                    );
                }
            }
        }

        private void ButCan()
        {
            ButtonCan();
            DimInput();
            CleInput();
            DisInput();
            DimInputStor();
            CleInputStor();
            DisInputStor();
            gCON.Enabled = true;
            gridCtrlStore.Enabled = true;
            listbranch = EnumerableUtils.GetBranchList();
            liststore = EnumerableUtils.GetStoreList();
        }

        private void pcAdd_Click(object sender, EventArgs e)
        {
            ButAdd();
        }

        private void pcUser_Click(object sender, EventArgs e)
        {
            ButUpd();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ButDel();
        }

        private void pcChangePassword_Click(object sender, EventArgs e)
        {
            ButClr();
        }

        private void pcBL_Click(object sender, EventArgs e)
        {
            ButSav();
        }
        private void GenerateStoreId()
        {
            int laststoreId = liststore.Any() ? liststore.Max(x => x.store_id) : 0;
            int newstoreId = laststoreId + 1;

            txtStoreId.Text = newstoreId.ToString();
            txtStoreId.Focus();
        }
        private void GenerateBranchId()
        {
            int lastbranchId = listbranch.Any() ? listbranch.Max(x => x.branch_id) : 0;
            int newbranchId = lastbranchId + 1;

            txtBranchId.Text = newbranchId.ToString();
            txtBranchId.Focus();
        }
        private void GenerateBranchCode()
        {
            var lastBranchCode = FetchUtils.GetLastBarcode();
            int lastBranchNumber;

            if (string.IsNullOrEmpty(lastBranchCode) || !int.TryParse(lastBranchCode.Replace("BR", ""), out lastBranchNumber))
            {
                lastBranchNumber = 0;
            }

            var alphaNumeric = new GenerateAlpaNum("BR", 3, lastBranchNumber);
            alphaNumeric.Increment();
            txtBranchCode.Text = alphaNumeric.ToString();
            txtBranchCode.Focus();
        }

        private void DataAdd()
        {
            if (string.IsNullOrWhiteSpace(txtBranchCode.Text) ||
                string.IsNullOrWhiteSpace(txtBranchName.Text) ||
                string.IsNullOrWhiteSpace(txtBranchBarangay.Text) ||
                string.IsNullOrWhiteSpace(txtBranchStreet.Text) ||
                string.IsNullOrWhiteSpace(txtBranchCity.Text) ||
                string.IsNullOrWhiteSpace(cmbProvincialAddress.Text) ||
                string.IsNullOrWhiteSpace(txtBranchZip.Text) ||
                string.IsNullOrWhiteSpace(txtBranchCountry.Text) ||
                string.IsNullOrWhiteSpace(txtBranchTel.Text) ||
                string.IsNullOrWhiteSpace(txtBranchMobile.Text) ||
                string.IsNullOrWhiteSpace(txtBranchEmail.Text) ||
                string.IsNullOrWhiteSpace(txtBranchFax.Text))
            {
                PopupNotification.PopUpMessages(0, "Please fill in all required fields.", "Incomplete Input");
                return;
            }
            var branch = new ServeAll.Core.Entities.Branch()
            {
                branch_code = txtBranchCode.Text.Trim(),
                branch_details = txtBranchName.Text.Trim(),
                date_register = dkpDateRegister.Value.Date
            };

            using (var session = new DalSession())
            {
                var unit = session.UnitofWrk;
                unit.Begin();
                try
                {
                    // Handle Address
                    var addressRepository = new Repository<Address>(unit);
                    var address = new Address()
                    {
                        barangay = txtBranchBarangay.Text.Trim(),
                        street = txtBranchStreet.Text.Trim(),
                        city = txtBranchCity.Text.Trim(),
                        province = cmbProvincialAddress.Text.Trim(), // Province is a string
                        zip_code = txtBranchZip.Text.Trim(), // Zip code is a string
                        country = txtBranchCountry.Text.Trim()
                    };

                    addressRepository.Add(address);
                    branch.address_id = address.address_id;

                    // Handle Contact
                    var contactRepository = new Repository<Contact>(unit);
                    var contact = new Contact()
                    {
                        telephone_number = txtBranchTel.Text.Trim(),
                        mobile_number = txtBranchMobile.Text.Trim(),
                        email_address = txtBranchEmail.Text.Trim(),
                        fax_number = txtBranchFax.Text.Trim()
                    };

                    contactRepository.Add(contact);
                    branch.contact_id = contact.contact_id;

                    // Add the new branch
                    var repository = new Repository<ServeAll.Core.Entities.Branch>(unit);
                    var que = repository.Add(branch);
                    if (que <= 0) return;

                    // Update the branch list and bind
                    listbranch = EnumerableUtils.GetBranchList();
                    BindBranch();

                    // Show success notification
                    PopupNotification.PopUpMessages(1, $"{Messages.TableBranch}{Messages.CodeName}{txtBranchName.Text.Trim()} {Messages.SuccessInsert}", Messages.TitleSuccessInsert);

                    unit.Commit();
                }
                catch (Exception)
                {
                    unit.Rollback();
                    PopupNotification.PopUpMessages(0, $"{Messages.ErrorInsert}{Messages.TableBranch}{Messages.ErrorOccurred}", Messages.TitleFailedInsert);
                }
            }
        }
        private void DataUpdateStore()
        {
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    if (!int.TryParse(txtStoreId.Text, out int storeId) || storeId <= 0)
                    {
                        PopupNotification.PopUpMessages(0, "Invalid store ID.", Messages.TitleFialedUpdate);
                        return;
                    }

                    var storeRepo = new Repository<Store>(unWork);
                    var store = storeRepo.Id(storeId);
                    if (store == null)
                    {
                        PopupNotification.PopUpMessages(0, "Store not found.", Messages.TitleFialedUpdate);
                        return;
                    }

                    // === Update Contact ===
                    var contactRepo = new Repository<Contact>(unWork);
                    var contact = contactRepo.Id(store.contact_id);
                    if (contact != null)
                    {
                        contact.position = "Supervisor/Authorized Person";
                        contact.telephone_number = txtStoreTel.Text.Trim();
                        contact.mobile_number = txtStoreMob.Text.Trim();
                        contact.mobile_secondary = txtStoreMob.Text.Trim();
                        contact.email_address = txtStoreEmail.Text.Trim();
                        contact.web_url = txtStoreWeb.Text.Trim();
                        contact.date_register = DateTime.Now;
                        contactRepo.Update(contact);
                    }

                    // === Update Address ===
                    var addressRepo = new Repository<Address>(unWork);
                    var address = addressRepo.Id(store.address_id);
                    if (address != null)
                    {
                        address.barangay = txtStoreBRGY.Text.Trim();
                        address.city = txtStoreCity.Text.Trim();
                        address.province = cmbStoreProv.Text.Trim();
                        address.zip_code = int.TryParse(txtStoreZIP.Text.Trim(), out var zip) ? zip.ToString() : "0";
                        address.country = "Philippines";
                        addressRepo.Update(address);
                    }

                    // === Update Supplier ===
                    store.store_name = txtStoreName.Text.Trim();
                    store.store_tin = txtStoreTIN.Text.Trim();

                    var result = storeRepo.Update(store);

                    if (result)
                    {
                        unWork.Commit();
                        PopupNotification.PopUpMessages(1, $"Store: {store.store_name} successfully updated!", Messages.TitleSuccessUpdate);
                        BindStore();
                        liststore = EnumerableUtils.GetStoreList();
                    }
                    else
                    {
                        unWork.Rollback();
                        PopupNotification.PopUpMessages(0, "Update failed. Please check the input.", Messages.TitleFialedUpdate);
                    }
                }
                catch (Exception ex)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, $"Update failed due to an error: {ex.Message}", Messages.TitleFialedUpdate);
                }
            }
        }

        private void DataUpdate()
        {
            var branchId = Convert.ToInt32(txtBranchId.Text);
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var branchRepository = new Repository<ServeAll.Core.Entities.Branch>(unWork);
                    var branch = branchRepository.Id(branchId);

                    if (branch != null)
                    {
                        branch.branch_code = txtBranchCode.Text;
                        branch.branch_details = txtBranchName.Text;
                        var addressRepository = new Repository<Address>(unWork);
                        var address = branch.address_id > 0 ? addressRepository.Id(branch.address_id) : new Address();

                        address.barangay = txtBranchBarangay.Text;
                        address.street = txtBranchStreet.Text;
                        address.city = txtBranchCity.Text;
                        address.province = cmbProvincialAddress.Text;
                        address.zip_code = txtBranchZip.Text;

                        if (branch.address_id > 0)
                        {
                            addressRepository.Update(address);
                        }
                        else
                        {
                            addressRepository.Add(address);
                            branch.address_id = address.address_id;
                        }

                        // Handle Contact
                        var contactRepository = new Repository<Contact>(unWork);
                        var contact = branch.contact_id > 0 ? contactRepository.Id(branch.contact_id) : new Contact();

                        contact.telephone_number = txtBranchTel.Text;
                        contact.mobile_number = txtBranchMobile.Text;
                        contact.email_address = txtBranchEmail.Text;
                        contact.fax_number = txtBranchFax.Text;

                        if (branch.contact_id > 0)
                        {
                            contactRepository.Update(contact);
                        }
                        else
                        {
                            contactRepository.Add(contact);
                            branch.contact_id = contact.contact_id;
                        }

                        // Update branch details
                        branch.date_register = dkpDateRegister.Value.Date;


                        var result = branchRepository.Update(branch);
                        if (result)
                        {
                            // Add the new lines here
                            listbranch = EnumerableUtils.GetBranchList();
                            BindBranch();

                            PopupNotification.PopUpMessages(1, $"{Messages.TableBranch} {Messages.CodeName} {txtBranchName.Text.Trim()} {Messages.SuccessUpdate}", Messages.TitleSuccessUpdate);

                            unWork.Commit();
                        }
                    }
                    else
                    {
                        throw new Exception("Branch not found.");
                    }
                }
                catch (Exception)
                {
                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, $"{Messages.ErrorUpdate} {Messages.TableBranch} {Messages.ErrorOccurred}", Messages.TitleFialedUpdate);
                }
            }
        }
        private void DataDelete()
        {
            var ctrlId = Convert.ToInt32(txtBranchId.Text);
            using (var session = new DalSession())
            {
                var unWork = session.UnitofWrk;
                unWork.Begin();
                try
                {
                    var repository = new Repository<ServeAll.Core.Entities.Branch>(unWork);
                    var query = repository.Id(ctrlId);
                    var result = repository.Delete(query);
                    if (!result) return;
                    PopupNotification.PopUpMessages(1, Messages.TableBranch + Messages.CodeName +
                                                    txtBranchName.Text.Trim(' ')
                                                    + " " + Messages.SuccessDelete,
                                                    Messages.TitleSuccessDelete);

                    unWork.Commit();
                }
                catch (Exception)
                {

                    unWork.Rollback();
                    PopupNotification.PopUpMessages(0, Messages.ErrorDelete + Messages.TableBranch + Messages.ErrorOccurred, Messages.TitleFialedDelete);

                }
            }
        }

        private void gridBranch_RowClick(object sender, RowClickEventArgs e)
        {
            WhtInput();
            bntCAN.Enabled = true;
        }

        private void gridBranch_LostFocus(object sender, EventArgs e)
        {
            DimInput();
        }

        private void gridStore_RowClick(object sender, RowClickEventArgs e)
        {
            WhtInputStor();
            bntCAN.Enabled = true;
        }

        private void gridStore_LostFocus(object sender, EventArgs e)
        {
            DimInputStor();
        }

        private void gridStore_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridStore.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                    if (id.Length > 0)
                    {
                        StoreId = int.Parse(id);
                        var ent = searchStoreId(StoreId);
                        txtStoreId.Text = ent.store_id.ToString();
                        txtStoreName.Text = ent.store_name;
                        txtStoreTIN.Text = ent.store_tin;
                        txtStoreBRGY.Text = ent.barangay;
                        txtStoreCity.Text = ent.city;
                        cmbStoreProv.Text = ent.province;
                        txtStoreZIP.Text = ent.zip_code.ToString(CultureInfo.InvariantCulture);
                        txtStoreTel.Text = ent.telephone_number;
                        txtStoreMob.Text = ent.mobile_number;
                        txtStoreEmail.Text = ent.email_address;
                        txtStoreWeb.Text = ent.web_url;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private void gridBranch_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridBranch.RowCount > 0)
                try
                {
                    var id = ((GridView)sender).GetFocusedRowCellValue("ID").ToString();
                    if (id.Length > 0)
                    {
                        BranchId = int.Parse(id);
                        var ent = searchBranchId(BranchId);
                        txtBranchId.Text = ent.branch_id.ToString();
                        txtBranchCode.Text = ent.branch_code;
                        txtBranchName.Text = ent.branch_details;
                        txtBranchBarangay.Text = ent.barangay;
                        txtBranchStreet.Text = ent.street;
                        txtBranchCity.Text = ent.city;
                        cmbProvincialAddress.Text = ent.province;
                        txtBranchZip.Text = ent.zip_code.ToString(CultureInfo.InvariantCulture);
                        txtBranchCountry.Text = ent.country;
                        txtBranchTel.Text = ent.telephone_number;
                        txtBranchMobile.Text = ent.mobile_number;
                        txtBranchEmail.Text = ent.email_address;
                        txtBranchFax.Text = ent.fax_number;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
        }

        private ViewBranch searchBranchId(int id)
        {
            return listbranch.FirstOrDefault(Branch => Branch.branch_id == id);
        }
        private ViewStore searchStoreId(int id)
        {
            return liststore.FirstOrDefault(Store => Store.store_id == id);
        }

        private void txtBAC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchCode, txtBranchName, "Branch Code", Messages.TitleBranch);
            }
        }

        private void txtBAD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchName, txtBranchBarangay, "Branch Name", Messages.TitleBranch);
            }
        }

        private void txtBAA_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchBarangay, txtBranchStreet, "Branch Barangay", Messages.TitleBranch);
            }
        }
        private void txtBranchStreet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchStreet, txtBranchCity, "Branch Street", Messages.TitleBranch);
            }
        }
        private void txtBranchCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchCity, cmbProvincialAddress, "Branch City", Messages.TitleBranch);
            }
        }

        private void cmbPRV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(cmbProvincialAddress, txtBranchZip, "Provincial Address", Messages.TitleBranch);
            }
        }
        private void txtBranchZip_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchZip, txtBranchCountry, "Branch Zip Code", Messages.TitleBranch);
            }
        }
        private void txtBranchCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchCountry, txtBranchTel, "Branch Country", Messages.TitleBranch);
            }
        }
        private void txtBAT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchTel, txtBranchMobile, "Branch Telephone Number", Messages.TitleBranch);
            }
        }

        private void txtBAM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchMobile, txtBranchEmail, "Branch Mobile Number", Messages.TitleBranch);
            }
        }

        private void txtBranchEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchEmail, txtBranchFax, "Branch Email", Messages.TitleBranch);
            }
        }

        private void txtFAX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(txtBranchFax, dkpDateRegister, "Branch Fax Number", Messages.TitleBranch);
            }
        }

        private void xtraBranch_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (xtraBranch.SelectedTabPage == xtraDetails)
            {
                _bra = true;
                _sto = false;
                bntADD.Enabled = true;
                bntDEL.Enabled = true;
                lblMainTitle.Text = "BRANCH";
            }
            else if (xtraBranch.SelectedTabPage == xtraStore)
            {
                _bra = false;
                _sto = true;
                bntADD.Enabled = false;
                bntDEL.Enabled = false;
                lblMainTitle.Text = "STORE";
            }
        }

        private void dkpREG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InputManipulation.InputEmpLeave(dkpDateRegister, bntSAV, "Date Register", Messages.TitleBranch);
            }
        }
    }
}
